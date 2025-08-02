using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class AgreementConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.AgreementDisplayModel, Interop.API.Common.Models.Display.AgreementDisplayModel, Models.Page.Configuration.AgreementConfigurationPageModel>
{
    public AgreementConfigurationPage(System.Action<Interop.API.Common.Models.Display.AgreementDisplayModel> successAction, Models.Page.Configuration.AgreementConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Acuerdo";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.AgreementDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.AgreementDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Index = ConcreteBindingContext.Index,
            Title = ConcreteBindingContext.Title,
            Description = ConcreteBindingContext.Description,
            EndAt = ConcreteBindingContext.HasEndDate ? ConcreteBindingContext.EndAt : null,
            Responsible = ConcreteBindingContext.Responsible
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.AgreementDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.AgreementDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            Index = ConcreteBindingContext.Index,
            Title = ConcreteBindingContext.Title,
            Description = ConcreteBindingContext.Description,
            EndAt = ConcreteBindingContext.HasEndDate ? ConcreteBindingContext.EndAt : null,
            Responsible = ConcreteBindingContext.Responsible
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

    private void ResponsiblePickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ResponsiblePickComplete_Callback)));
    }

    private void ResponsiblePickComplete_Callback(Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.Responsible = model;
    }
}