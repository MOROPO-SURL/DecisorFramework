using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProductionConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ProductionDisplayModel,ProductionDisplayModel, Models.Page.Configuration.ProductionConfigurationPageModel>
{
    public ProductionConfigurationPage(System.Action<ProductionDisplayModel> successAction, Models.Page.Configuration.ProductionConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.ProductionConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.UnitMeasurement != null)
        {
            for (int i = 0; i < model.AvailableUnitMeasurements.Count; i++)
            {
                var current = model.AvailableUnitMeasurements[i];

                if (model.UnitMeasurement.Id != current.Id) continue;

                UnitMeasurementPicker.SelectedIndex = i;
                UnitMeasurementPicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Producción";

    protected override async System.Threading.Tasks.Task<ProductionDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProductionInputModel
        {
            Id = System.Guid.NewGuid(),
            OrderId = ConcreteBindingContext.Order.Id,
            Amount = ConcreteBindingContext.Amount,
            UnitMeasurementId = ConcreteBindingContext.AvailableUnitMeasurements[UnitMeasurementPicker.SelectedIndex].Id,
            At = ConcreteBindingContext.At,
            Description = ConcreteBindingContext.Description,
            ProductBridges = ConcreteBindingContext.ProductBridges.Select(_model => new Interop.API.Common.Models.Bridge.ProductionProductBridgeModel { Product = _model.Product, Amount = _model.Amount, UnitMeasurement = _model.UnitMeasurement }).ToList(),
            EmployeeBridges = ConcreteBindingContext.EmployeeBridges.ToList(),
            ColaboratorBridges = ConcreteBindingContext.ColaboratorBridges.ToList()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected async override System.Threading.Tasks.Task<ProductionDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProductionInputModel
        {
            Id = ConcreteBindingContext.Id,
            OrderId = ConcreteBindingContext.Order.Id,
            Amount = ConcreteBindingContext.Amount,
            UnitMeasurementId = ConcreteBindingContext.AvailableUnitMeasurements[UnitMeasurementPicker.SelectedIndex].Id,
            At = ConcreteBindingContext.At,
            Description = ConcreteBindingContext.Description,
            ProductBridges = ConcreteBindingContext.ProductBridges.Select(_model => new Interop.API.Common.Models.Bridge.ProductionProductBridgeModel { Product = _model.Product, Amount = _model.Amount, UnitMeasurement = _model.UnitMeasurement }).ToList(),
            EmployeeBridges = ConcreteBindingContext.EmployeeBridges.ToList(),
            ColaboratorBridges = ConcreteBindingContext.ColaboratorBridges.ToList()
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

    private void OrderPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ProductionOrderPickPage(OrderPickComplete_Callback)));
    }

    private void OrderPickComplete_Callback(ProductionOrderDisplayModel model)
    {
        ConcreteBindingContext.Order = model;

        ConcreteBindingContext.ProductBridges.Clear();

        foreach (var item in model.Elaboration.OutputProductBridges)
        {
            ConcreteBindingContext.ProductBridges.Add(new Models.View.ProductionProductBridgeViewModel
            {
                Product = item.Product,
                UnitMeasurement = item.UnitMeasurement
            });
        }

        ConcreteBindingContext.AvailableUnitMeasurements.Clear();

        ConcreteBindingContext.IsBusy = true;

        var unitMeasurementsAPIConnectClient = new Domain.Interop.API.Connect.Clients.UnitMeasurementsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        unitMeasurementsAPIConnectClient.GetReleatedsAsync(model.Elaboration.Product.DefaultUnitMeasurement.Id).ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.IsBusy = false;

                if (!task.IsCompletedSuccessfully) return;

                foreach (var item in task.Result)
                {
                    ConcreteBindingContext.AvailableUnitMeasurements.Add(item);
                }
            });
        });
    }

    private void AddEmployeeBridgeButton_Clicked(object sender, System.EventArgs e)
    {
        if (ConcreteBindingContext.Order == null) return;

        var model = new Models.Page.Configuration.ProductionEmployeeBridgeConfigurationPageModel(null)
        {
            AvailableSteps = ConcreteBindingContext.Order.Elaboration.Steps
        };

        this.NavigationPushPageAsync(new ProductionEmployeeBridgeConfigurationPage(EmployeeBridgeCreateSuccess_Callback, model));
    }

    private void EditEmployeeBridgeButton_Clicked(object sender, System.EventArgs e)
    {
        var model = new Models.Page.Configuration.ProductionEmployeeBridgeConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.ProductionEmployeeBridgeModel)
        {
            AvailableSteps = ConcreteBindingContext.Order.Elaboration.Steps
        };

        this.NavigationPushPageAsync(new ProductionEmployeeBridgeConfigurationPage(EmployeetBridgeEditSuccess_Callback, model));
    }

    private void RemoveEmployeeBridgeButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este empleado?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            hasChangesFlag = true;

            Dispatcher.Dispatch(() => ((Models.Page.Configuration.ProductionConfigurationPageModel)BindingContext).EmployeeBridges.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.ProductionEmployeeBridgeModel));
        });
    }

    private void EmployeeBridgeCreateSuccess_Callback(Interop.API.Common.Models.Bridge.ProductionEmployeeBridgeModel model)
    {
        ((Models.Page.Configuration.ProductionConfigurationPageModel)BindingContext).EmployeeBridges.Add(model);

        hasChangesFlag = true;
    }

    private void EmployeetBridgeEditSuccess_Callback(Interop.API.Common.Models.Bridge.ProductionEmployeeBridgeModel model)
    {
        var reference = ConcreteBindingContext.EmployeeBridges.First(item => item.Employee.Id == model.Employee.Id);

        var index = ConcreteBindingContext.EmployeeBridges.IndexOf(reference);

        ConcreteBindingContext.EmployeeBridges[index] = model;

        hasChangesFlag = true;
    }
}