namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Views.Card;

public partial class OrganizationalStructuringUnitTreeCardView : Microsoft.Maui.Controls.ContentView
{
	public OrganizationalStructuringUnitTreeCardView()
	{
		InitializeComponent();
    }

    public event System.EventHandler<System.EventArgs> AddDependencyChildButtonClick;

    public event System.EventHandler<System.EventArgs> AddCompositionChildButtonClick;

    public event System.EventHandler<System.EventArgs> EditChildButtonClick;

    public event System.EventHandler<System.EventArgs> RemoveChildButtonClick;

    private void AddDependencyChildButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        AddDependencyChildButtonClick(sender, eventArgs);
    }

    private void AddCompositionChildButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        AddCompositionChildButtonClick(sender, eventArgs);
    }

    private void EditChildButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        EditChildButtonClick(sender, eventArgs);
    }

    private void RemoveChildButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        RemoveChildButtonClick(sender, eventArgs);
    }
}