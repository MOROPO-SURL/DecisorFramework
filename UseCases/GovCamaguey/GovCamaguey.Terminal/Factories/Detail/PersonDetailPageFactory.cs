namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Detail
{
    public class PersonDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PersonDisplayModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.PersonDisplayModel> Build(Interop.API.Common.Models.Display.PersonDisplayModel model, System.Action<Interop.API.Common.Models.Display.PersonDisplayModel, int?> delegationAction = null)
        {
            return new UI.Pages.Detail.PersonDetailPage(model, delegationAction);
        }
    }
}