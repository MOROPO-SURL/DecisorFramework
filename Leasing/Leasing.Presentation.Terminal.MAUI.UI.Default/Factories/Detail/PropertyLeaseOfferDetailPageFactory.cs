namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail
{
    public class PropertyLeaseOfferDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel, Pages.Detail.PropertyLeaseOfferDetailPage>
    {
        public Pages.Detail.PropertyLeaseOfferDetailPage Build(Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel model, System.Action<Interop.API.Common.Models.Display.PropertyLeaseOfferDisplayModel, int?> delegationAction = null)
        {
            return new Pages.Detail.PropertyLeaseOfferDetailPage(model, delegationAction);
        }
    }
}
