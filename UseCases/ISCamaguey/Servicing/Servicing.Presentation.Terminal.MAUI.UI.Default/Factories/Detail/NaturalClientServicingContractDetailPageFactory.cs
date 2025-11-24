namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class NaturalClientServicingContractDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel> Build(Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.NaturalClientServicingContractDetailPage(model, delegationAction);
    }
}
