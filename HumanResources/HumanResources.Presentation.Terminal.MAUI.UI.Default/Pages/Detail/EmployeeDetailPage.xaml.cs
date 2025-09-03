namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class EmployeeDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel>
{
    public EmployeeDetailPage(Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel bindingContextModel) : base(bindingContextModel)
    {
        InitializeComponent();
    }
}