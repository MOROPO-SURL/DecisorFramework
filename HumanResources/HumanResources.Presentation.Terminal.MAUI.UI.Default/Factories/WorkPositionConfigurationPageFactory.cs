using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class WorkPositionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.WorkPositionDisplayModel, Models.Page.Configuration.WorkPositionConfigurationPageModel, Pages.Configuration.WorkPositionConfigurationPage>
    {
        public WorkPositionConfigurationPage Build(Action<WorkPositionDisplayModel> configurationSuccessAction, WorkPositionConfigurationPageModel model)
        {
            return new Pages.Configuration.WorkPositionConfigurationPage(configurationSuccessAction, model);
        }
    }
}
