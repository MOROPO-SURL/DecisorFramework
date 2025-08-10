using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base
{
    public class ListBaseContentPage<TModel, TListPageModel, TDetailContentPage> : Caney.MVVM.Core.Pages.ContentPage
        where TModel : class
        where TListPageModel : Models.Page.Contract.AbstractListEntityPageModel<TModel>, new()
        where TDetailContentPage : DetailBaseContentPage<TModel>
    {
        public ListBaseContentPage()
        {
            BindingContext = new TListPageModel();
        }

        protected int CurrentItemsPageNumber { get; private set; }

        protected int CurrentItemsPageLimit { get; private set; }

        protected virtual Microsoft.Maui.Controls.CollectionView GetItemsCollectionView() { throw new System.NotImplementedException(); }

        protected virtual double ItemViewRequestWidth { get => 320; }

        protected virtual double MeasureCollectionViewCellHeight(double width) { return width; }

        protected virtual void ItemDetailRequestControl_Invoked(object sender, System.EventArgs eventArgs)
        {
            if (((TListPageModel)BindingContext).IsBusy) return;

            FillItemDataAsync((sender as Microsoft.Maui.Controls.BindableObject).BindingContext as TModel).ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    var factory = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<UI.Factories.Facade.IDetailContentPageFactoryFacade<TModel, TDetailContentPage>>();

                    this.NavigationPushModalPageAsync(factory.Build(task.Result));
                });
            });
        }

        protected void OnReload(object sender, System.EventArgs eventArgs)
        {
            if (((TListPageModel)BindingContext).IsBusy) return;

            LoadItems(true);
        }

        protected void OnLoadMore(object sender, System.EventArgs eventArgs)
        {
            LoadItems();
        }

        protected void OnItemsCollectionViewLayoutResize(object sender, System.EventArgs eventArgs)
        {
            if (GetItemsCollectionView().ItemsLayout is Microsoft.Maui.Controls.GridItemsLayout)
            {
                var itemsCollectionViewItemsLayout = GetItemsCollectionView().ItemsLayout as Microsoft.Maui.Controls.GridItemsLayout;

                var itemsCollectionViewLayout = sender as Microsoft.Maui.Controls.Layout;

                if (itemsCollectionViewLayout.Width < 0 || itemsCollectionViewLayout.Height < 0) return;

                if ((BindingContext as TListPageModel).IsBusy) return;

                var reazon = itemsCollectionViewLayout.Width / (ItemViewRequestWidth + itemsCollectionViewItemsLayout.HorizontalItemSpacing);

                int columnCount = System.Convert.ToInt32(System.Math.Round(reazon, System.MidpointRounding.ToEven));

                if (columnCount > reazon)
                {
                    columnCount--;
                }

                if (columnCount <= 0)
                {
                    columnCount = 1;
                }

                itemsCollectionViewItemsLayout.Span = columnCount;
            }

            LoadItems(true);
        }

        protected void LoadItems(bool restart = false)
        {
            var concreteBindingContext = (TListPageModel)BindingContext;

            concreteBindingContext.IsBusy = true;

            if (restart)
            {
                CalculateCollectionViewPagingMetrics();

                CurrentItemsPageNumber = 0;

                foreach (var item in concreteBindingContext.Items)
                {
                    if (item == null || item is not System.IDisposable) continue;

                    (item as System.IDisposable).Dispose();
                }

                concreteBindingContext.Items.Clear();
            }

            CurrentItemsPageNumber++;

            FetchItemsAsync().ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    if (concreteBindingContext == null) return;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        CurrentItemsPageNumber--;

                        Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                    }
                    else
                    {
                        foreach (var model in task.Result.List)
                        {
                            concreteBindingContext.Items.Add(model);
                        }

                        concreteBindingContext.HasMoreItems = task.Result.HasNext && task.Result.List.Count > 0;
                    }

                    concreteBindingContext.IsBusy = false;
                });
            });
        }

        protected virtual System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<TModel>> FetchItemsAsync() { throw new System.NotImplementedException(); }

        protected virtual System.Threading.Tasks.Task<TModel> FillItemDataAsync(TModel model)
        {
            return System.Threading.Tasks.Task.FromResult(model);
        }

        private void CalculateCollectionViewPagingMetrics()
        {
            var itemsCollectionViewLayout = GetItemsCollectionView().Parent as Microsoft.Maui.Controls.Layout;

            var columnCount = 1;

            double itemsCollectionViewItemsLayoutHorizontalItemSpacing;

            if (GetItemsCollectionView().ItemsLayout is Microsoft.Maui.Controls.GridItemsLayout)
            {
                var itemsCollectionViewItemsLayout = GetItemsCollectionView().ItemsLayout as Microsoft.Maui.Controls.GridItemsLayout;

                columnCount = itemsCollectionViewItemsLayout.Span;

                itemsCollectionViewItemsLayoutHorizontalItemSpacing = itemsCollectionViewItemsLayout.HorizontalItemSpacing;
            }
            else
            {
                itemsCollectionViewItemsLayoutHorizontalItemSpacing = (GetItemsCollectionView().ItemsLayout as Microsoft.Maui.Controls.LinearItemsLayout).ItemSpacing;
            }

            var collectionViewCellWidth = (itemsCollectionViewLayout.Width - ((columnCount - 1) * itemsCollectionViewItemsLayoutHorizontalItemSpacing)) / columnCount;

            var collectionViewCellHeight = MeasureCollectionViewCellHeight(collectionViewCellWidth);

            var availableVerticalHeight = itemsCollectionViewLayout.Height;

            var rowCount = 0;

            while (availableVerticalHeight > 0)
            {
                rowCount++;

                availableVerticalHeight -= collectionViewCellHeight + itemsCollectionViewItemsLayoutHorizontalItemSpacing;
            }

            CurrentItemsPageLimit = columnCount * rowCount;
        }
    }
}
