using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class AnalysisConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<AnalysisDisplayModel, AnalysisDisplayModel, Models.Page.Configuration.AnalysisConfigurationPageModel>
{
	public AnalysisConfigurationPage(System.Action<AnalysisDisplayModel> successAction, Models.Page.Configuration.AnalysisConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.AnalysisConfigurationPageModel> validator) : base(successAction, model, validator)
    {
		InitializeComponent();
    }

    protected override string EntityTypeName => "Análisis de Muestra";

    protected override async System.Threading.Tasks.Task<AnalysisDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.AnalysesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.AnalysisInputModel
        {
            Id = System.Guid.NewGuid(),
            At = ConcreteBindingContext.At.Date.AddTicks(ConcreteBindingContext.Time.Ticks),
            Description = ConcreteBindingContext.Description,
            WorkPlanId = ConcreteBindingContext.WorkPlan.Id,
            SampleId = ConcreteBindingContext.Sample.Id,
            TechniqueId = ConcreteBindingContext.Technique.Id,
            AuthorId = ConcreteBindingContext.Author.Id,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<AnalysisDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.AnalysesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.AnalysisInputModel
        {
            Id = ConcreteBindingContext.Id,
            At = ConcreteBindingContext.At.Date.AddTicks(ConcreteBindingContext.Time.Ticks),
            Description = ConcreteBindingContext.Description,
            WorkPlanId = ConcreteBindingContext.WorkPlan.Id,
            SampleId = ConcreteBindingContext.Sample.Id,
            TechniqueId = ConcreteBindingContext.Technique.Id,
            AuthorId = ConcreteBindingContext.Author.Id,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.EditAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs args)
    {
        OnApply(sender, args);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs args)
    {
        OnCancel(sender, args);
    }

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs args)
    {
        hasChangesFlag = true;
    }

    private void WorkPlanPickButton_Clicked(object sender, System.EventArgs args)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.WorkPlanPickPage(WorkPlanPicked_Callback)));
    }

    private void AuthorPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.EmployeePickPage(AuthorPickComplete_Callback)));
    }

    private void SamplePickButton_Clicked(object sender, System.EventArgs args)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.WorkPlanSamplePickPage(ConcreteBindingContext.WorkPlan, ServiceOrderSamplePicked_Callback, ResearchSamplePicked_Callback, ProductionSamplePicked_Callback)));
    }

    protected void NotificationUserAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.UserPickPage(NotificationUserPickComplete_Callback)));
    }

    private void NotificationUserRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este usuario de las notificaciones?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Framework.Decisor.Core.Interop.API.Common.Models.Display.UserDisplayModel;

                ConcreteBindingContext.NotificationUsers.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void NotificationUserPickComplete_Callback(Framework.Decisor.Core.Interop.API.Common.Models.Display.UserDisplayModel model)
    {
        ConcreteBindingContext.NotificationUsers.Add(model);
    }

    private void AuthorPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel model)
    {
        ConcreteBindingContext.Author = model;

        hasChangesFlag = true;
    }

    private void WorkPlanPicked_Callback(WorkPlanDisplayModel model)
    {
        ConcreteBindingContext.WorkPlan = model;

        hasChangesFlag = true;
    }

    private void ServiceOrderSamplePicked_Callback(ServiceOrderSampleDisplayModel model)
    {
        ConcreteBindingContext.Sample = new SampleOverviewModel
        {
            Id = model.Id,
            Type = Interop.API.Common.Enumerations.SampleType.ServiceOrder,
            Index = model.Index,
            Year = model.Year,
            Kind = model.SampleKind,
            Amount = model.Amount,
            At = model.At,
            Observation = model.Observation,
            UnitMeasurement = model.UnitMeasurement,
            PickedAt = model.PickedAt,
            HandledAt = model.HandledAt,
            AssessmentAt = model.AssessmentAt
        };

        if (model.Order.RequestedTechnique != null)
        {
            ConcreteBindingContext.Technique = ConcreteBindingContext.AvailableTechniques.SingleOrDefault(item => item.Id == model.Order.RequestedTechnique.Id);
        }

        hasChangesFlag = true;
    }

    private void ResearchSamplePicked_Callback(ResearchSampleDisplayModel model)
    {
        ConcreteBindingContext.Sample = new SampleOverviewModel
        {
            Id = model.Id,
            Type = Interop.API.Common.Enumerations.SampleType.Research,
            Index = model.Index,
            Year = model.Year,
            Kind = model.SampleKind,
            Amount = model.Amount,
            At = model.At,
            Observation = model.Observation,
            UnitMeasurement = model.UnitMeasurement,
            PickedAt = model.PickedAt,
            HandledAt = model.HandledAt,
            AssessmentAt = model.AssessmentAt
        };

        hasChangesFlag = true;
    }

    private void ProductionSamplePicked_Callback(ProductionSampleDisplayModel model)
    {
        ConcreteBindingContext.Sample = new SampleOverviewModel
        {
            Id = model.Id,
            Type = Interop.API.Common.Enumerations.SampleType.Production,
            Index = model.Index,
            Year = model.Year,
            Kind = model.SampleKind,
            Amount = model.Amount,
            At = model.At,
            Observation = model.Observation,
            UnitMeasurement = model.UnitMeasurement,
            PickedAt = model.PickedAt,
            HandledAt = model.HandledAt,
            AssessmentAt = model.AssessmentAt
        };

        hasChangesFlag = true;
    }
}