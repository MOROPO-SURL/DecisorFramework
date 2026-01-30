namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract
{
    public abstract class AbstractManageEntityPageModel<T> : AbstractListEntityPageModel<T>
    {
        // TODO Remove deprecated field
        private T presentedItem;

        // TODO Remove deprecated property
        public T PresentedItem { get => presentedItem; set => SetProperty(ref presentedItem, value); }
    }
}
