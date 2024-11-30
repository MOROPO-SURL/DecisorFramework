using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ElaborationConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration.Contract.BaseConfigurationContentPage<ElaborationDisplayModel>
{
    public ElaborationConfigurationPage(System.Action<ElaborationDisplayModel> successAction, Models.Page.Configuration.ElaborationConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Elaboración";

    protected override async System.Threading.Tasks.Task<ElaborationDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ElaborationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.ElaborationConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.ElaborationInputModel
        {
            Id = System.Guid.NewGuid(),
            ProductId = concreteBindingContext.Product.Id,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority,
            MinPerformanceCoefficient = concreteBindingContext.MinPerformanceCoefficient,
            MaxPerformanceCoefficient = concreteBindingContext.MaxPerformanceCoefficient,
            InputProducts = concreteBindingContext.InputProducts.ToList(),
            OutputProducts = concreteBindingContext.OutputProducts.ToList(),
            Steps = concreteBindingContext.Steps.ToList()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<ElaborationDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ElaborationsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.ElaborationConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.ElaborationInputModel
        {
            Id = concreteBindingContext.Id,
            ProductId = concreteBindingContext.Product.Id,
            Description = concreteBindingContext.Description,
            Priority = concreteBindingContext.Priority,
            MinPerformanceCoefficient = concreteBindingContext.MinPerformanceCoefficient,
            MaxPerformanceCoefficient = concreteBindingContext.MaxPerformanceCoefficient,
            InputProducts = concreteBindingContext.InputProducts.ToList(),
            OutputProducts = concreteBindingContext.OutputProducts.ToList(),
            Steps = concreteBindingContext.Steps.ToList()
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ProductChangeButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.ProductPickPage(ProductPickComplete_Callback)));
    }

    private void AddInputProductButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.ProductPickPage(InputProductPickComplete_Callback)));
    }

    private void AddOutputProductButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.ProductPickPage(OutputProductPickComplete_Callback)));
    }

    private void AddStepButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new ElaborationStepConfigurationPage(StepCreateSuccess_Callback, new Models.Page.Configuration.ElaborationStepConfigurationPageModel(null)));
    }

    private void EditStepButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new ElaborationStepConfigurationPage(StepEditSuccess_Callback, new Models.Page.Configuration.ElaborationStepConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ElaborationStepDisplayModel)));
    }

    private void InputProductRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este insumo?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.ElaborationConfigurationPageModel)BindingContext).InputProducts.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Inventory.Interop.API.Common.Models.Display.ProductDisplayModel));
        });
    }

    private void OutputProductRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este sub-producto?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.ElaborationConfigurationPageModel)BindingContext).OutputProducts.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Inventory.Interop.API.Common.Models.Display.ProductDisplayModel));
        });
    }

    private void RemoveStepButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea eliminar esta etapa?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.ElaborationConfigurationPageModel)BindingContext).Steps.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ElaborationStepDisplayModel));
        });
    }

    private void ProductPickComplete_Callback(Inventory.Interop.API.Common.Models.Display.ProductDisplayModel model)
    {
        ((Models.Page.Configuration.ElaborationConfigurationPageModel)BindingContext).Product = model;

        hasChangesFlag = true;
    }

    private void InputProductPickComplete_Callback(Inventory.Interop.API.Common.Models.Display.ProductDisplayModel model)
    {
        ((Models.Page.Configuration.ElaborationConfigurationPageModel)BindingContext).InputProducts.Add(model);

        hasChangesFlag = true;
    }

    private void OutputProductPickComplete_Callback(Inventory.Interop.API.Common.Models.Display.ProductDisplayModel model)
    {
        ((Models.Page.Configuration.ElaborationConfigurationPageModel)BindingContext).OutputProducts.Add(model);

        hasChangesFlag = true;
    }

    private void StepCreateSuccess_Callback(ElaborationStepDisplayModel model)
    {
        ((Models.Page.Configuration.ElaborationConfigurationPageModel)BindingContext).Steps.Add(model);

        hasChangesFlag = true;
    }

    private void StepEditSuccess_Callback(ElaborationStepDisplayModel model)
    {
        var concreteBindingContext = (Models.Page.Configuration.ElaborationConfigurationPageModel)BindingContext;

        var reference = concreteBindingContext.Steps.First(item => item.Id == model.Id);

        var index = concreteBindingContext.Steps.IndexOf(reference);

        concreteBindingContext.Steps[index] = model;

        hasChangesFlag = true;
    }
}