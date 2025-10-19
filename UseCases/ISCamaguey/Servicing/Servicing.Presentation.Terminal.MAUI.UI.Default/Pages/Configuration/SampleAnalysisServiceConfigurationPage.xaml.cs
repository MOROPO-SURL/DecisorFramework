using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class SampleAnalysisServiceConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel, Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel, Models.Page.Configuration.SampleAnalysisServiceConfigurationPageModel>
{
    private readonly List<Interop.API.Common.Models.Input.SampleAnalysisServiceStepInputModel> editionSteps = [];
    private readonly List<Interop.API.Common.Models.Input.SampleAnalysisServiceStepInputModel> incomingSteps = [];
    private readonly List<Interop.API.Common.Models.Display.SampleAnalysisServiceStepDisplayModel> outgoingSteps = [];

    public SampleAnalysisServiceConfigurationPage(System.Action<Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel> successAction, Models.Page.Configuration.SampleAnalysisServiceConfigurationPageModel model, Validators.SampleAnalysisServiceConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.SampleKind != null)
        {
            for (int i = 0; i < model.AvailableSampleKinds.Length; i++)
            {
                var current = model.AvailableSampleKinds[i];

                if (model.SampleKind.Id != current.Id) continue;

                SampleKindPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Servicio de Procesamiento de Muestra";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SampleAnalysisServicesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.SampleAnalysisServiceInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            SampleKindId = ConcreteBindingContext.SampleKind.Id,
            IncomingSteps = incomingSteps
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.SampleAnalysisServicesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.SampleAnalysisServiceInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Priority = ConcreteBindingContext.Priority,
            SampleKindId = ConcreteBindingContext.SampleKind.Id,
            IncomingSteps = incomingSteps,
            EditionSteps = editionSteps,
            OutgoingSteps = outgoingSteps
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

    private void StepAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new SampleAnalysisServiceStepConfigurationPage(StepCreateSuccess_Callback, new Models.Page.Configuration.SampleAnalysisServiceStepConfigurationPageModel(null), new Validators.SampleAnalysisServiceStepConfigurationValidator()));
    }

    private void StepDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Detail.SampleAnalysisServiceStepDetailPage(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.SampleAnalysisServiceStepDisplayModel));
    }

    private void StepEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new SampleAnalysisServiceStepConfigurationPage(StepEditSuccess_Callback, new Models.Page.Configuration.SampleAnalysisServiceStepConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.SampleAnalysisServiceStepDisplayModel), new Validators.SampleAnalysisServiceStepConfigurationValidator()));
    }

    private void StepRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta etapa?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.SampleAnalysisServiceStepDisplayModel;

                var handled = false;

                foreach (var item in incomingSteps)
                {
                    if (item.Id != target.Id) continue;

                    incomingSteps.Remove(incomingSteps.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionSteps)
                    {
                        if (item.Id != target.Id) continue;

                        editionSteps.Remove(editionSteps.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingSteps.Add(target);
                }

                ConcreteBindingContext.Steps.Remove(target);

                // TODO Order by index !!!

                hasChangesFlag = true;
            });
        });
    }

    private void StepCreateSuccess_Callback(Interop.API.Common.Models.Input.SampleAnalysisServiceStepInputModel model)
    {
        // TODO Order by index !!!

        incomingSteps.Add(model);

        ConcreteBindingContext.Steps.Add(new Interop.API.Common.Models.Display.SampleAnalysisServiceStepDisplayModel
        {
            Id = model.Id,
            Name = model.Name,
            Priority = model.Priority,
            Description = model.Description
        });

        hasChangesFlag = true;
    }

    private void StepEditSuccess_Callback(Interop.API.Common.Models.Input.SampleAnalysisServiceStepInputModel model)
    {
        var handled = false;

        foreach (var item in incomingSteps)
        {
            if (item.Id != model.Id) continue;

            item.Name = model.Name;
            item.Priority = model.Priority;
            item.Description = model.Description;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionSteps)
            {
                if (item.Id != model.Id) continue;

                item.Name = model.Name;
                item.Priority = model.Priority;
                item.Description = model.Description;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionSteps.Add(model);
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.Steps)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.Steps[index] = new Interop.API.Common.Models.Display.SampleAnalysisServiceStepDisplayModel
            {
                Id = model.Id,
                Name = model.Name,
                Priority = model.Priority,
                Description = model.Description
            };

            break;
        }

        hasChangesFlag = true;
    }
}