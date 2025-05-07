using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProductionOrderConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ProductionOrderDisplayModel, ProductionOrderDisplayModel, Models.Page.Configuration.ProductionOrderConfigurationPageModel>
{
    public ProductionOrderConfigurationPage(System.Action<ProductionOrderDisplayModel> successAction, Models.Page.Configuration.ProductionOrderConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.Author != null)
        {
            for (int i = 0; i < model.AvailableAuthors.Length; i++)
            {
                var current = model.AvailableAuthors[i];

                if (model.Author.Id != current.Id) continue;

                AuthorPicker.SelectedIndex = i;

                break;
            }
        }

        if (model.Responsible != null)
        {
            for (int i = 0; i < model.AvailableResponsibles.Length; i++)
            {
                var current = model.AvailableResponsibles[i];

                if (model.Responsible.Id != current.Id) continue;

                ResponsiblePicker.SelectedIndex = i;

                break;
            }
        }

        if (model.Decisor != null)
        {
            for (int i = 0; i < model.AvailableDecisors.Length; i++)
            {
                var current = model.AvailableDecisors[i];

                if (model.Decisor.Id != current.Id) continue;

                DecisorPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Orden de Producción";

    protected override async System.Threading.Tasks.Task<ProductionOrderDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductionOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.ProductionOrderConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.ProductionOrderInputModel
        {
            Id = System.Guid.NewGuid(),
            RequestedFor = concreteBindingContext.RequestedFor,
            Amount = concreteBindingContext.Amount,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority,
            ElaborationId = concreteBindingContext.Elaboration.Id,
            AuthorId = concreteBindingContext.AvailableAuthors[AuthorPicker.SelectedIndex].Id,
            ResponsibleId = concreteBindingContext.AvailableResponsibles[ResponsiblePicker.SelectedIndex].Id,
            DecisorId = concreteBindingContext.AvailableDecisors[DecisorPicker.SelectedIndex].Id
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<ProductionOrderDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductionOrdersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.ProductionOrderConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.ProductionOrderInputModel
        {
            Id = concreteBindingContext.Id,
            RequestedFor = concreteBindingContext.RequestedFor,
            Amount = concreteBindingContext.Amount,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority,
            ElaborationId = concreteBindingContext.Elaboration.Id,
            AuthorId = concreteBindingContext.AvailableAuthors[AuthorPicker.SelectedIndex].Id,
            ResponsibleId = concreteBindingContext.AvailableResponsibles[ResponsiblePicker.SelectedIndex].Id,
            DecisorId = concreteBindingContext.AvailableDecisors[DecisorPicker.SelectedIndex].Id
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void ElaborationChangeButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ElaborationPickPage(ElaborationPickComplete_Callback)));
    }

    private void ElaborationPickComplete_Callback(ElaborationDisplayModel model)
    {
        ((Models.Page.Configuration.ProductionOrderConfigurationPageModel)BindingContext).Elaboration = model;

        hasChangesFlag = true;
    }
}