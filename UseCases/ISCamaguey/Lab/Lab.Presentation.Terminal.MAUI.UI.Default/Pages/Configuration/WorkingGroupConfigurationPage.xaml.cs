using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class WorkingGroupConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.WorkingGroupDisplayModel, Interop.API.Common.Models.Display.WorkingGroupDisplayModel, Models.Page.Configuration.WorkingGroupConfigurationPageModel>
{
    public WorkingGroupConfigurationPage(System.Action<Interop.API.Common.Models.Display.WorkingGroupDisplayModel> successAction, Models.Page.Configuration.WorkingGroupConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.WorkingGroupConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Grupo de Trabajo";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.WorkingGroupDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.WorkingGroupsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.WorkingGroupInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            ChiefId = ConcreteBindingContext.Chief.Id,
            QualitySpecialistId = ConcreteBindingContext.QualitySpecialist.Id,
            Employees = [.. ConcreteBindingContext.Employees],
            Techniques = [.. ConcreteBindingContext.Techniques]
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.WorkingGroupDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.WorkingGroupsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.WorkingGroupInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            ChiefId = ConcreteBindingContext.Chief.Id,
            QualitySpecialistId = ConcreteBindingContext.QualitySpecialist.Id,
            Employees = [.. ConcreteBindingContext.Employees],
            Techniques = [.. ConcreteBindingContext.Techniques]
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

    private void ChiefPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(ChiefPickComplete_Callback)));
    }

    private void QualitySpecialistPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(QualitySpecialistPickComplete_Callback)));
    }

    private void EmployeeAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(EmployeePickComplete_Callback)));
    }

    private void TechniqueAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.TechniquePickPage(TechniquePickComplete_Callback)));
    }

    private void EmployeeDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel;

        this.NavigationPushModalPageAsync(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.EmployeeDetailPage(target));
    }

    private void TechniqueDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel;

        this.NavigationPushModalPageAsync(new Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail.TechniqueDetailPage(target, null));
    }

    private void EmployeeRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este miembro del grupo de trabajo?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel;

                ConcreteBindingContext.Employees.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void TechniqueRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta técnica del grupo de trabajo?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel;

                ConcreteBindingContext.Techniques.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void ChiefPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Chief = model;

        hasChangesFlag = true;
    }

    private void QualitySpecialistPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.QualitySpecialist = model;

        hasChangesFlag = true;
    }

    private void EmployeePickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Employees.Add(model);

        hasChangesFlag = true;
    }

    private void TechniquePickComplete_Callback(Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel model)
    {
        ConcreteBindingContext.Techniques.Add(model);

        hasChangesFlag = true;
    }
}