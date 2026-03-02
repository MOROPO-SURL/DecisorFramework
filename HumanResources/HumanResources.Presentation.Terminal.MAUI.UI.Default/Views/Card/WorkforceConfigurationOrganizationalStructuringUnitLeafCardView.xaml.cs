namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Views.Card;

public partial class WorkforceConfigurationOrganizationalStructuringUnitLeafCardView : Microsoft.Maui.Controls.ContentView
{
    public WorkforceConfigurationOrganizationalStructuringUnitLeafCardView()
    {
        InitializeComponent();
    }

    public event System.EventHandler DefineChiefVacantButtonClick;

    public event System.EventHandler ChiefVacantEditionButtonClick;

    public event System.EventHandler AddVacantButtonClick;

    public event System.EventHandler VacantEditionButtonClick;

    public event System.EventHandler VacantRemoveButtonClick;

    private void DefineChiefVacantButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DefineChiefVacantButtonClick(sender, eventArgs);
    }

    private void ChiefVacantEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        ChiefVacantEditionButtonClick(sender, eventArgs);
    }

    private void AddVacantButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        AddVacantButtonClick(sender, eventArgs);
    }

    private void VacantEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        VacantEditionButtonClick(sender, eventArgs);
    }

    private void VacantRemoveButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        VacantRemoveButtonClick(sender, eventArgs);
    }
}