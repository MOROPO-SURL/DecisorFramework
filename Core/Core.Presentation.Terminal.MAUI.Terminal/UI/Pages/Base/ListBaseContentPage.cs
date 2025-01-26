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
            IsEnabled = false;

            BindingContext = new TListPageModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            LoadItems();

            IsEnabled = true;
        }

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

        private void ReloadControl_Invoked(object sender, System.EventArgs eventArgs)
        {
            if (((TListPageModel)BindingContext).IsBusy) return;

            LoadItems();
        }

        protected void LoadItems()
        {
            var concreteBindingContext = (TListPageModel)BindingContext;

            concreteBindingContext.IsBusy = true;

            concreteBindingContext.Items.Clear();

            FetchItemsAsync().ContinueWith(task =>
            {
                Dispatcher.Dispatch(() =>
                {
                    concreteBindingContext.IsBusy = false;

                    if (task.Exception != null || task.IsCanceled)
                    {
                        Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Helpers.Facade.IExceptionHandlingHelperFacade>().HandleException(task.Exception, this);
                    }
                    else
                    {
                        foreach (var model in task.Result.List)
                        {
                            concreteBindingContext.Items.Add(model);
                        }
                    }
                });
            });
        }

        protected virtual System.Threading.Tasks.Task<Guama.Core.Presentation.Models.PaginationModel<TModel>> FetchItemsAsync() { throw new System.NotImplementedException(); }

        protected virtual System.Threading.Tasks.Task<TModel> FillItemDataAsync(TModel model)
        {
            return System.Threading.Tasks.Task.FromResult(model);
        }
    }
}
