namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Views.Card;

public partial class OcupationManageOrganizationalStructuringUnitLeafCardView : Microsoft.Maui.Controls.ContentView
{
	public OcupationManageOrganizationalStructuringUnitLeafCardView()
	{
		InitializeComponent();
	}

    public event System.EventHandler OcupationCreationButtonClick;

    public event System.EventHandler RemoveOcupationButtonClick;

    public event System.EventHandler EmployeeDetailButtonClick;

    private void OcupationCreationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        OcupationCreationButtonClick(sender, eventArgs);
    }

    private void RemoveOcupationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        RemoveOcupationButtonClick(sender, eventArgs);
    }

    private void EmployeeDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        EmployeeDetailButtonClick(sender, eventArgs);
    }
}