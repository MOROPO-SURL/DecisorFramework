using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class DriveLicenceConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.DriveLicenceDisplayModel, Interop.API.Common.Models.Display.DriveLicenceDisplayModel, Models.Page.Configuration.DriveLicenceConfigurationPageModel>
{
    public DriveLicenceConfigurationPage(System.Action<Interop.API.Common.Models.Display.DriveLicenceDisplayModel> successAction, Models.Page.Configuration.DriveLicenceConfigurationPageModel model) : base(successAction, model, new Validators.DriveLicenceConfigurationValidator())
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Licencia de Conducción";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.DriveLicenceDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.DriveLicenceDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Contact = ConcreteBindingContext.Contact,
            Code = ConcreteBindingContext.Code,
            Reference = ConcreteBindingContext.Reference,
            ReleasedAt = new System.DateTime(ConcreteBindingContext.ReleasedAtYear, ConcreteBindingContext.ReleasedAtMonth, 1),
            ExpireAt = new System.DateTime(ConcreteBindingContext.ExpireAtYear, ConcreteBindingContext.ReleasedAtMonth, 1)
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.DriveLicenceDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.DriveLicenceDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            Contact = ConcreteBindingContext.Contact,
            Code = ConcreteBindingContext.Code,
            Reference = ConcreteBindingContext.Reference,
            ReleasedAt = new System.DateTime(ConcreteBindingContext.ReleasedAtYear, ConcreteBindingContext.ReleasedAtMonth, 1),
            ExpireAt = new System.DateTime(ConcreteBindingContext.ExpireAtYear, ConcreteBindingContext.ReleasedAtMonth, 1)
        });
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void ContactPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ContactPickComplete_Callback)));
    }

    private void ContactPickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.Contact = model;

        hasChangesFlag = true;
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }
}