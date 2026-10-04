using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.Framework.Guama.Core.Presentation.API.Connect.Providers.Facade;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class WorkPlanConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.WorkPlanDisplayModel, Interop.API.Common.Models.Display.WorkPlanDisplayModel, Models.Page.Configuration.WorkPlanConfigurationPageModel>
{
    private readonly List<System.Guid> inServiceOrderSampleIds = [];
    private readonly List<System.Guid> outServiceOrderSampleIds = [];
    private readonly List<System.Guid> inResearchSampleIds = [];
    private readonly List<System.Guid> outResearchSampleIds = [];
    private readonly List<System.Guid> inProductionSampleIds = [];
    private readonly List<System.Guid> outProductionSampleIds = [];

    public WorkPlanConfigurationPage(System.Action<Interop.API.Common.Models.Display.WorkPlanDisplayModel> successAction, Models.Page.Configuration.WorkPlanConfigurationPageModel model, FluentValidation.AbstractValidator<Models.Page.Configuration.WorkPlanConfigurationPageModel> validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Plan de Trabajo";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.WorkPlanDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.WorkPlansAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.WorkPlanInputModel
        {
            Id = System.Guid.NewGuid(),
            At = ConcreteBindingContext.At,
            Description = ConcreteBindingContext.Description,
            WorkingGroupId = ConcreteBindingContext.WorkingGroup.Id,
            InServiceOrderSampleIds = inServiceOrderSampleIds,
            InResearchSampleIds = inResearchSampleIds,
            InProductionSampleIds = inProductionSampleIds,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.WorkPlanDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.WorkPlansAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.WorkPlanInputModel
        {
            Id = ConcreteBindingContext.Id,
            At = ConcreteBindingContext.At,
            Description = ConcreteBindingContext.Description,
            WorkingGroupId = ConcreteBindingContext.WorkingGroup.Id,
            InServiceOrderSampleIds = inServiceOrderSampleIds,
            InResearchSampleIds = inResearchSampleIds,
            InProductionSampleIds = inProductionSampleIds,
            OutServiceOrderSampleIds = outServiceOrderSampleIds,
            OutResearchSampleIds = outResearchSampleIds,
            OutProductionSampleIds = outProductionSampleIds,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
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

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs args)
    {
        hasChangesFlag = true;
    }

    private void ServiceOrderSampleAgregationButton_Clicked(object sender, System.EventArgs args)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ServiceOrderSamplePickPage(ServiceOrderSamplePicked_Callback, false, false)));
    }

    private void ResearchSampleAgregationButton_Clicked(object sender, System.EventArgs args)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ResearchSamplePickPage(ResearchSamplePicked_Callback, false, false)));
    }

    private void ProductionSampleAgregationButton_Clicked(object sender, System.EventArgs args)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ProductionSamplePickPage(ProductionSamplePicked_Callback, false, false)));
    }

    private void ServiceOrderSampleRemotionButton_Clicked(object sender, System.EventArgs args)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta muestra?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel;

                if (target.HandledAt != null)
                {
                    DisplayAlert("Aviso", "No es posible retirar una muestra que ya ha sido procesada.", "Aceptar");

                    return;
                }

                var handled = false;

                foreach (var item in inServiceOrderSampleIds)
                {
                    if (item != target.Id) continue;

                    inServiceOrderSampleIds.Remove(item);

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outServiceOrderSampleIds.Add(target.Id);
                }

                ConcreteBindingContext.ServiceOrderSamples.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void ResearchSampleRemotionButton_Clicked(object sender, System.EventArgs args)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta muestra?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ResearchSampleDisplayModel;

                if (target.HandledAt != null)
                {
                    DisplayAlert("Aviso", "No es posible retirar una muestra que ya ha sido procesada.", "Aceptar");

                    return;
                }

                var handled = false;

                foreach (var item in inResearchSampleIds)
                {
                    if (item != target.Id) continue;

                    inResearchSampleIds.Remove(item);

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outResearchSampleIds.Add(target.Id);
                }

                ConcreteBindingContext.ResearchSamples.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void ProductionSampleRemotionButton_Clicked(object sender, System.EventArgs args)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta muestra?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ProductionSampleDisplayModel;

                if (target.HandledAt != null)
                {
                    DisplayAlert("Aviso", "No es posible retirar una muestra que ya ha sido procesada.", "Aceptar");

                    return;
                }

                var handled = false;

                foreach (var item in inProductionSampleIds)
                {
                    if (item != target.Id) continue;

                    inProductionSampleIds.Remove(item);

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    outProductionSampleIds.Add(target.Id);
                }

                ConcreteBindingContext.ProductionSamples.Remove(target);

                hasChangesFlag = true;
            });
        });
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

    private void ServiceOrderSamplePicked_Callback(Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel model)
    {
        if (ConcreteBindingContext.ServiceOrderSamples.Any(item => item.Id == model.Id))
        {
            DisplayAlert("Aviso", "Esta muestra ya ha sido vinculada a este plan de trabajo.", "Aceptar");

            return;
        }

        inServiceOrderSampleIds.Add(model.Id);

        ConcreteBindingContext.ServiceOrderSamples.Add(model);

        hasChangesFlag = true;
    }

    private void ResearchSamplePicked_Callback(Interop.API.Common.Models.Display.ResearchSampleDisplayModel model)
    {
        if (ConcreteBindingContext.ResearchSamples.Any(item => item.Id == model.Id))
        {
            DisplayAlert("Aviso", "Esta muestra ya ha sido vinculada a este plan de trabajo.", "Aceptar");

            return;
        }

        inResearchSampleIds.Add(model.Id);

        ConcreteBindingContext.ResearchSamples.Add(model);

        hasChangesFlag = true;
    }

    private void ProductionSamplePicked_Callback(Interop.API.Common.Models.Display.ProductionSampleDisplayModel model)
    {
        if (ConcreteBindingContext.ProductionSamples.Any(item => item.Id == model.Id))
        {
            DisplayAlert("Aviso", "Esta muestra ya ha sido vinculada a este plan de trabajo.", "Aceptar");

            return;
        }

        inProductionSampleIds.Add(model.Id);

        ConcreteBindingContext.ProductionSamples.Add(model);

        hasChangesFlag = true;
    }
}