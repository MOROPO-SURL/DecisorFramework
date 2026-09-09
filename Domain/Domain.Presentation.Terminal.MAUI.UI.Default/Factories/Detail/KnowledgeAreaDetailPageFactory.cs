namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class KnowledgeAreaDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel> Build(Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel model, System.Action<Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.KnowledgeAreaDetailPage(model, delegationAction);
    }
}