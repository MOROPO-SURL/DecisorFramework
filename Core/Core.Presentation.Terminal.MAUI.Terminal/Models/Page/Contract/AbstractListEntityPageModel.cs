namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract
{
    public abstract class AbstractListEntityPageModel<T> : Caney.MVVM.Core.Models.Page.BasePageModel
    {
        private bool hasMoreItems;

        public System.Collections.ObjectModel.ObservableCollection<T> Items { get; set; } = new System.Collections.ObjectModel.ObservableCollection<T>();

        public bool HasMoreItems { get => hasMoreItems; set => SetProperty(ref hasMoreItems, value); }
    }
}
