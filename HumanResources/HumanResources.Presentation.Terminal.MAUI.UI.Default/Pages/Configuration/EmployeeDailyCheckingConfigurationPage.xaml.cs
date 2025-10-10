using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class EmployeeDailyCheckingConfigurationPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<EmployeeDailyCheckingDisplayModel, EmployeeDailyCheckingDisplayModel, Models.Page.Configuration.EmployeeDailyCheckingConfigurationPageModel>
{
    public EmployeeDailyCheckingConfigurationPage(System.Action<EmployeeDailyCheckingDisplayModel> successAction, Models.Page.Configuration.EmployeeDailyCheckingConfigurationPageModel model) : base(successAction, model, null)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Reporte de Asistencia";

    protected override async System.Threading.Tasks.Task<EmployeeDailyCheckingDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.EmployeeDailyCheckingsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.EmployeeDailyCheckingInputModel
        {
            EmployeeId = ConcreteBindingContext.EmployeeId,
            Day = ConcreteBindingContext.At.Day,
            Month = ConcreteBindingContext.At.Month,
            Year = ConcreteBindingContext.At.Year,
            CheckIn = ConcreteBindingContext.CheckIn,
            PartialCheckOut = ConcreteBindingContext.IsPartialCheckOutSet ? ConcreteBindingContext.PartialCheckOut : null,
            PartialChecIn = ConcreteBindingContext.IsPartialCheckInSet ? ConcreteBindingContext.PartialCheckIn : null,
            CheckOut = ConcreteBindingContext.IsCheckOutSet ? ConcreteBindingContext.CheckOut : null,
            ExtraCheckIn = ConcreteBindingContext.IsExtraCheckInSet ? ConcreteBindingContext.ExtraCheckIn : null,
            ExtraCheckOut = ConcreteBindingContext.IsExtraCheckOutSet ? ConcreteBindingContext.ExtraCheckOut : null
        };

        await apiConnectClient.CreateAsync(model);

        return new EmployeeDailyCheckingDisplayModel { EmployeeId = ConcreteBindingContext.EmployeeId };
    }

    protected override async System.Threading.Tasks.Task<EmployeeDailyCheckingDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.EmployeeDailyCheckingsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.EmployeeDailyCheckingInputModel
        {
            Id = ConcreteBindingContext.Id,
            Day = ConcreteBindingContext.At.Day,
            Month = ConcreteBindingContext.At.Month,
            Year = ConcreteBindingContext.At.Year,
            CheckIn = ConcreteBindingContext.CheckIn,
            PartialCheckOut = ConcreteBindingContext.IsPartialCheckOutSet ? ConcreteBindingContext.PartialCheckOut : null,
            PartialChecIn = ConcreteBindingContext.IsPartialCheckInSet ? ConcreteBindingContext.PartialCheckIn : null,
            CheckOut = ConcreteBindingContext.IsCheckOutSet ? ConcreteBindingContext.CheckOut : null,
            ExtraCheckIn = ConcreteBindingContext.IsExtraCheckInSet ? ConcreteBindingContext.ExtraCheckIn : null,
            ExtraCheckOut = ConcreteBindingContext.IsExtraCheckOutSet ? ConcreteBindingContext.ExtraCheckOut : null
        };

        await apiConnectClient.EditAsync(model);

        return new EmployeeDailyCheckingDisplayModel { EmployeeId = ConcreteBindingContext.EmployeeId };
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        hasChangesFlag = true;
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }
}