using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class CostCenterConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.CostCenterDisplayModel, Interop.API.Common.Models.Display.CostCenterDisplayModel, Models.Page.Configuration.CostCenterConfigurationPageModel>
{
    public CostCenterConfigurationPage(System.Action<Interop.API.Common.Models.Display.CostCenterDisplayModel> successAction, Models.Page.Configuration.CostCenterConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.CostCenterConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.Structure != null)
        {
            for (int i = 0; i < model.AvailableStructures.Length; i++)
            {
                var current = model.AvailableStructures[i];

                if (model.Structure.Id != current.Id) continue;

                StructurePicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Centro de Costo";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.CostCenterDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.CostCentersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.CostCenterInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            DefaultBankAccountId = ConcreteBindingContext.DefaultBankAccount.Id,
            StructureId = ConcreteBindingContext.AvailableStructures[StructurePicker.SelectedIndex].Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.CostCenterDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.CostCentersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.CostCenterInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            DefaultBankAccountId = ConcreteBindingContext.DefaultBankAccount.Id,
            StructureId = ConcreteBindingContext.AvailableStructures[StructurePicker.SelectedIndex].Id
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void DefaultBankAccountPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.InternalBankAccountPickPage(DefaultBankAccountPickComplete_Callback, false)));
    }

    private void DefaultBankAccountPickComplete_Callback(Interop.API.Common.Models.Display.BankAccountDisplayModel model)
    {
        ((Models.Page.Configuration.CostCenterConfigurationPageModel)BindingContext).DefaultBankAccount = model;

        hasChangesFlag = true;
    }
}
