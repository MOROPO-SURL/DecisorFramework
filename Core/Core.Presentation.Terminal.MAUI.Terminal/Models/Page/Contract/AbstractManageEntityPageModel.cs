namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract
{
    public abstract class AbstractManageEntityPageModel<T> : AbstractListEntityPageModel<T>
    {
        private T presentedItem;

        public T PresentedItem { get => presentedItem; set => SetProperty(ref presentedItem, value); }
    }
}
