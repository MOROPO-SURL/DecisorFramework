using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProductionConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Configuration.BaseConfigurationContentPage<ProductionDisplayModel>
{
    public ProductionConfigurationPage(System.Action<ProductionDisplayModel> successAction, Models.Page.Configuration.ProductionConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();

        if (model.UnitMeasurement != null)
        {
            for (int i = 0; i < model.AvailableUnitMeasurements.Length; i++)
            {
                var current = model.AvailableUnitMeasurements[i];

                if (model.UnitMeasurement.Id != current.Id) continue;

                UnitMeasurementPicker.SelectedIndex = i;
                UnitMeasurementPicker.SelectedItem = current;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Compra";

    protected override async System.Threading.Tasks.Task<ProductionDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProductionsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var concreteBindingContext = (Models.Page.Configuration.ProductionConfigurationPageModel)BindingContext;

        var model = new Interop.API.Common.Models.Input.ProductionInputModel
        {
            Id = System.Guid.NewGuid(),
            PlanId = concreteBindingContext.Order.Id,
            Amount = concreteBindingContext.Amount,
            UnitMeasurementId = concreteBindingContext.AvailableUnitMeasurements[UnitMeasurementPicker.SelectedIndex].Id,
            Description = concreteBindingContext.Description,
            ProductBridges = concreteBindingContext.ProductBridges.Select(_model => new Interop.API.Common.Models.Bridge.ProductionProductBridgeModel { Product = _model.Product, Amount = _model.Amount, UnitMeasurement = _model.UnitMeasurement }).ToList(),
            EmployeeBridges = concreteBindingContext.EmployeeBridges.ToList(),
            ColaboratorBridges = concreteBindingContext.ColaboratorBridges.ToList()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override System.Threading.Tasks.Task<ProductionDisplayModel> PerformEditionAsync()
    {
        throw new System.InvalidOperationException();
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
        var concreteBindingContext = (Models.Page.Configuration.ProductionConfigurationPageModel)BindingContext;

        concreteBindingContext.Order = model;

        concreteBindingContext.ProductBridges.Clear();

        //foreach (var item in model.Elaboration.OutputProductBridges)
        //{
        //    concreteBindingContext.ProductBridges.Add(new Models.View.ProductionProductBridgeViewModel
        //    {
        //        Product = item,
        //        UnitMeasurement = item.DefaultUnitMeasurement
        //    });
        //}
    }

    private void AddEmployeeBridgeButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Configuration.ProductionConfigurationPageModel)BindingContext;

        if (concreteBindingContext.Order == null) return;

        var model = new Models.Page.Configuration.ProductionEmployeeBridgeConfigurationPageModel(null)
        {
            AvailableSteps = concreteBindingContext.Order.Elaboration.Steps
        };

        this.NavigationPushPageAsync(new ProductionEmployeeBridgeConfigurationPage(EmployeeBridgeCreateSuccess_Callback, model));
    }

    private void EditEmployeeBridgeButton_Clicked(object sender, System.EventArgs e)
    {
        var concreteBindingContext = (Models.Page.Configuration.ProductionConfigurationPageModel)BindingContext;

        var model = new Models.Page.Configuration.ProductionEmployeeBridgeConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Bridge.ProductionEmployeeBridgeModel)
        {
            AvailableSteps = concreteBindingContext.Order.Elaboration.Steps
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
        var concreteBindingContext = (Models.Page.Configuration.ProductionConfigurationPageModel)BindingContext;

        var reference = concreteBindingContext.EmployeeBridges.First(item => item.Employee.Id == model.Employee.Id);

        var index = concreteBindingContext.EmployeeBridges.IndexOf(reference);

        concreteBindingContext.EmployeeBridges[index] = model;

        hasChangesFlag = true;
    }
}