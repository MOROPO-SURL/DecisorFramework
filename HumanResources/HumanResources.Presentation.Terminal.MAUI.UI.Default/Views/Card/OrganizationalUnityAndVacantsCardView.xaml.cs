namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Views.Card;

public partial class OrganizationalUnityAndVacantsCardView : Microsoft.Maui.Controls.ContentView
{
	public OrganizationalUnityAndVacantsCardView()
	{
		InitializeComponent();
	}

	public event System.EventHandler AddVacantButtonClick;

    public event System.EventHandler VacantEditionButtonClick;

    public event System.EventHandler VacantRemoveButtonClick;

    private void AddVacantButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        AddVacantButtonClick.Invoke(sender, eventArgs);
    }

    private void VacantEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        VacantEditionButtonClick.Invoke(sender, eventArgs);
    }

    private void VacantRemoveButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        VacantRemoveButtonClick.Invoke(sender, eventArgs);
    }
}