using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProgramConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProgramDisplayModel, Interop.API.Common.Models.Display.ProgramDisplayModel, Models.Page.Configuration.ProgramConfigurationPageModel>
{
    private readonly List<Interop.API.Common.Models.Input.ProgramExpectResultInputModel> editionProgramExpectResults = [];
    private readonly List<Interop.API.Common.Models.Input.ProgramExpectResultInputModel> incomingProgramExpectResults = [];
    private readonly List<Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel> outgoingProgramExpectResults = [];

    public ProgramConfigurationPage(System.Action<Interop.API.Common.Models.Display.ProgramDisplayModel> successAction, Models.Page.Configuration.ProgramConfigurationPageModel model, Validators.ProgramConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Programa";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProgramDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProgramsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProgramInputModel
        {
            Id = System.Guid.NewGuid(),
            Name = ConcreteBindingContext.Name,
            Alias = ConcreteBindingContext.Alias,
            Code = ConcreteBindingContext.Code,
            ManagerId = ConcreteBindingContext.Manager.Id,
            ChiefId = ConcreteBindingContext.Chief.Id,
            IncomingProgramExpectResults = incomingProgramExpectResults
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProgramDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProgramsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProgramInputModel
        {
            Id = ConcreteBindingContext.Id,
            Name = ConcreteBindingContext.Name,
            Alias = ConcreteBindingContext.Alias,
            Code = ConcreteBindingContext.Code,
            ManagerId = ConcreteBindingContext.Manager.Id,
            ChiefId = ConcreteBindingContext.Chief.Id,
            IncomingProgramExpectResults = incomingProgramExpectResults,
            EditionProgramExpectResults = editionProgramExpectResults,
            OutgoingProgramExpectResults = outgoingProgramExpectResults
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

    private void ManagerPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.OrganizationContactPickPage(ManagerPickComplete_Callback)));
    }

    private void ChiefPickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Pick.PersonContactPickPage(ChiefPickComplete_Callback)));
    }

    private void ProgramExpectResultAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new ProgramExpectResultConfigurationPage(ProgramExpectResultCreateSuccess_Callback, new Models.Page.Configuration.ProgramExpectResultConfigurationPageModel(null), new Validators.ProgramExpectResultConfigurationValidator()));
    }

    private void ProgramExpectResultDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Detail.ProgramExpectResultDetailPage(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel));
    }

    private void ProgramExpectResultEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new ProgramExpectResultConfigurationPage(ProgramExpectResultEditSuccess_Callback, new Models.Page.Configuration.ProgramExpectResultConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel), new Validators.ProgramExpectResultConfigurationValidator()));
    }

    private void ProgramExpectResultRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta prioridad?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel;

                var handled = false;

                foreach (var item in incomingProgramExpectResults)
                {
                    if (item.Id != target.Id) continue;

                    incomingProgramExpectResults.Remove(incomingProgramExpectResults.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionProgramExpectResults)
                    {
                        if (item.Id != target.Id) continue;

                        editionProgramExpectResults.Remove(editionProgramExpectResults.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingProgramExpectResults.Add(target);
                }

                ConcreteBindingContext.ExpectResults.Remove(target);

                var index = 1;

                foreach (var item in ConcreteBindingContext.ExpectResults)
                {
                    item.Index = index++;
                }

                hasChangesFlag = true;
            });
        });
    }

    private void ProgramExpectResultCreateSuccess_Callback(Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel model)
    {
        model.Index = ConcreteBindingContext.ExpectResults.Count + 1;

        incomingProgramExpectResults.Add(new Interop.API.Common.Models.Input.ProgramExpectResultInputModel
        {
            Id = model.Id,
            Index = model.Index,
            Title = model.Title,
            Description = model.Description
        });

        ConcreteBindingContext.ExpectResults.Add(model);

        hasChangesFlag = true;
    }

    private void ProgramExpectResultEditSuccess_Callback(Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingProgramExpectResults)
        {
            if (item.Id != model.Id) continue;

            item.Index = model.Index;
            item.Title = model.Title;
            item.Description = model.Description;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionProgramExpectResults)
            {
                if (item.Id != model.Id) continue;

                item.Index = model.Index;
                item.Title = model.Title;
                item.Description = model.Description;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionProgramExpectResults.Add(new Interop.API.Common.Models.Input.ProgramExpectResultInputModel
            {
                Id = model.Id,
                Index = model.Index,
                Title = model.Title,
                Description = model.Description
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.ExpectResults)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.ExpectResults[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void ManagerPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel model)
    {
        ConcreteBindingContext.Manager = model;
    }

    private void ChiefPickComplete_Callback(Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel model)
    {
        ConcreteBindingContext.Chief = model;
    }
}