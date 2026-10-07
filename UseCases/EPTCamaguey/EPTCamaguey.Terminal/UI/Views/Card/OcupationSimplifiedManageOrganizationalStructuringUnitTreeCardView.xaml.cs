namespace MOROPO.EPTCamaguey.Decisor.Terminal.UI.Views.Card;

public partial class OcupationSimplifiedManageOrganizationalStructuringUnitTreeCardView : Microsoft.Maui.Controls.ContentView
{
	public OcupationSimplifiedManageOrganizationalStructuringUnitTreeCardView()
	{
		InitializeComponent();
    }

    public event System.EventHandler ContactPickButtonClick;

    public event System.EventHandler RemoveOcupationButtonClick;

    public event System.EventHandler EmployeeDetailButtonClick;

    private void ContactPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ContactPickButtonClick(sender, eventArgs);
    }

    private void RemoveOcupationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        RemoveOcupationButtonClick((object)sender, eventArgs);
    }

    private void EmployeeDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        EmployeeDetailButtonClick(sender, eventArgs);
    }
}