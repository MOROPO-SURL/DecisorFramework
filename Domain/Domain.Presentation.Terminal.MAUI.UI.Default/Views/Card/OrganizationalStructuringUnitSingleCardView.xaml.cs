namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Views.Card;

public partial class OrganizationalStructuringUnitSingleCardView : Microsoft.Maui.Controls.ContentView
{
    public OrganizationalStructuringUnitSingleCardView()
    {
        InitializeComponent();
    }

    public event System.EventHandler<System.EventArgs> EditChildButtonClick;

    public event System.EventHandler<System.EventArgs> RemoveChildButtonClick;

    private void EditChildButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        EditChildButtonClick(sender, eventArgs);
    }

    private void RemoveChildButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        RemoveChildButtonClick(sender, eventArgs);
    }
}