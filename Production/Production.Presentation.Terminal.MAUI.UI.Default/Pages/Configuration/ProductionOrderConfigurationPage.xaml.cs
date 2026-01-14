using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProductionOrderConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ProductionOrderDisplayModel, ProductionOrderDisplayModel, Models.Page.Configuration.ProductionOrderConfigurationPageModel>
{
    public ProductionOrderConfigurationPage(System.Action<ProductionOrderDisplayModel> successAction, Models.Page.Configuration.ProductionOrderConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.ProductionOrderConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Órden de Producción";

    protected override async System.Threading.Tasks.Task<ProductionOrderDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductionOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProductionOrderInputModel
        {
            Id = System.Guid.NewGuid(),
            RequestedFor = ConcreteBindingContext.RequestedFor,
            Amount = ConcreteBindingContext.Amount,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            ElaborationId = ConcreteBindingContext.Elaboration.Id,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            ResponsibleId = ConcreteBindingContext.Responsible.Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<ProductionOrderDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductionOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProductionOrderInputModel
        {
            Id = ConcreteBindingContext.Id,
            RequestedFor = ConcreteBindingContext.RequestedFor,
            Amount = ConcreteBindingContext.Amount,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            ElaborationId = ConcreteBindingContext.Elaboration.Id,
            AgreementId = ConcreteBindingContext.Agreement.Id,
            ResponsibleId = ConcreteBindingContext.Responsible.Id
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

    private void ElaborationPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ElaborationPickPage(ElaborationPickComplete_Callback)));
    }

    private void AgreementPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.MeetingAgreementPickPage(AgreementPickComplete_Callback)));
    }

    private void EmployeePickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(EmployeePickComplete_Callback)));
    }

    private void ElaborationPickComplete_Callback(ElaborationDisplayModel model)
    {
       ConcreteBindingContext.Elaboration = model;

        hasChangesFlag = true;
    }

    private void AgreementPickComplete_Callback(Governance.Interop.API.Common.Models.Display.AgreementDisplayModel model)
    {
        ConcreteBindingContext.Agreement = model;

        hasChangesFlag = true;
    }

    private void EmployeePickComplete_Callback(Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Responsible = model;

        hasChangesFlag = true;
    }
}