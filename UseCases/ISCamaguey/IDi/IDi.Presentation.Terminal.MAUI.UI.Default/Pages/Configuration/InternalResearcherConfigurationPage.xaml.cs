using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class InternalResearcherConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.InternalResearcherDisplayModel, Interop.API.Common.Models.Display.InternalResearcherDisplayModel, Models.Page.Configuration.InternalResearcherConfigurationPageModel>
{
    public InternalResearcherConfigurationPage(System.Action<Interop.API.Common.Models.Display.InternalResearcherDisplayModel> successAction, Models.Page.Configuration.InternalResearcherConfigurationPageModel model, Validators.InternalResearcherConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.Category != null)
        {
            for (int i = 0; i < model.AvailableResearcherCategories.Length; i++)
            {
                var current = model.AvailableResearcherCategories[i];

                if (model.Category.Id != current.Id) continue;

                CategoryPicker.SelectedIndex = i;

                break;
            }
        }

        if (model.TeachingCategory != null)
        {
            for (int i = 0; i < model.AvailableTeachingCategories.Length; i++)
            {
                var current = model.AvailableTeachingCategories[i];

                if (model.TeachingCategory.Id != current.Id) continue;

                TeachingCategoryPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Investigador Interno";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.InternalResearcherDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.InternalResearchersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.InternalResearcherInputModel
        {
            Id = System.Guid.NewGuid(),
            EmployeeId = ConcreteBindingContext.Employee.Id,
            Priority = ConcreteBindingContext.Priority,
            CategoryId = ConcreteBindingContext.Category?.Id,
            TeachingCategoryId = ConcreteBindingContext.TeachingCategory?.Id,
            TimeAvailability = ConcreteBindingContext.TimeAvailability,
            SpecializationResearchAreas = [.. ConcreteBindingContext.SpecializationResearchAreas],
            MasteryResearchAreas = [.. ConcreteBindingContext.MasteryResearchAreas],
            DoctorateResearchAreas = [.. ConcreteBindingContext.DoctorateResearchAreas]
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.InternalResearcherDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.InternalResearchersAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.InternalResearcherInputModel
        {
            Id = ConcreteBindingContext.Id,
            EmployeeId = ConcreteBindingContext.Employee.Id,
            Priority = ConcreteBindingContext.Priority,
            CategoryId = ConcreteBindingContext.Category?.Id,
            TeachingCategoryId = ConcreteBindingContext.TeachingCategory?.Id,
            SpecializationResearchAreas = [.. ConcreteBindingContext.SpecializationResearchAreas],
            TimeAvailability = ConcreteBindingContext.TimeAvailability,
            MasteryResearchAreas = [.. ConcreteBindingContext.MasteryResearchAreas],
            DoctorateResearchAreas = [.. ConcreteBindingContext.DoctorateResearchAreas]
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

    private void EmployeePickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(EmployeetPickComplete_Callback)));
    }

    private void ResearchAreaDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ResearchAreaDisplayModel;

        this.NavigationPushModalPageAsync(new Detail.ResearchAreaDetailPage(target, null));
    }

    private void SpecializationResearchAreaAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ResearchAreaPickPage(SpecializationResearchAreaPickComplete_Callback)));
    }

    private void SpecializationResearchAreaRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta especialización en área de investigación?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ResearchAreaDisplayModel;

                ConcreteBindingContext.SpecializationResearchAreas.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void MasteryResearchAreaAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ResearchAreaPickPage(MasteryResearchAreaPickComplete_Callback)));
    }

    private void MasteryResearchAreaRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este master en área de investigación?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ResearchAreaDisplayModel;

                ConcreteBindingContext.MasteryResearchAreas.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void DoctorateResearchAreaAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ResearchAreaPickPage(DoctorateResearchAreaPickComplete_Callback)));
    }

    private void DoctorateResearchAreaRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este doctorado en área de investigación?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ResearchAreaDisplayModel;

                ConcreteBindingContext.DoctorateResearchAreas.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void EmployeetPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Employee = model;

        hasChangesFlag |= true;
    }

    private void SpecializationResearchAreaPickComplete_Callback(Interop.API.Common.Models.Display.ResearchAreaDisplayModel model)
    {
        ConcreteBindingContext.SpecializationResearchAreas.Add(model);

        hasChangesFlag = true;
    }

    private void MasteryResearchAreaPickComplete_Callback(Interop.API.Common.Models.Display.ResearchAreaDisplayModel model)
    {
        ConcreteBindingContext.MasteryResearchAreas.Add(model);

        hasChangesFlag = true;
    }

    private void DoctorateResearchAreaPickComplete_Callback(Interop.API.Common.Models.Display.ResearchAreaDisplayModel model)
    {
        ConcreteBindingContext.DoctorateResearchAreas.Add(model);

        hasChangesFlag = true;
    }
}