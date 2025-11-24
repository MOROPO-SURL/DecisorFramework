namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class LegalClientServicingContractDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel> Build(Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.LegalClientServicingContractDetailPage(model, delegationAction);
    }
}