using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Pick
{
    public class WorkPositionPickPageModel: Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractListEntityPageModel<Interop.API.Common.Models.Display.WorkPositionDisplayModel>
    {
        public WorkPositionDisplayModel PresentedItem { get; set; }
    }
}
