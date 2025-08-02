using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class WorkPositionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<WorkPositionDisplayModel, WorkPositionConfigurationPageModel, WorkPositionConfigurationPage>
    {
        public WorkPositionConfigurationPage Build(System.Action<WorkPositionDisplayModel> configurationSuccessAction, WorkPositionConfigurationPageModel model)
        {
            return new WorkPositionConfigurationPage(configurationSuccessAction, model);
        }
    }
}
