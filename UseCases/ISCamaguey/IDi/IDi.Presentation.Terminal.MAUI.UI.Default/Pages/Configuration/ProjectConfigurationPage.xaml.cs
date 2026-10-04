using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ProjectConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ProjectDisplayModel, Interop.API.Common.Models.Display.ProjectDisplayModel, Models.Page.Configuration.ProjectConfigurationPageModel>
{
    private Microsoft.Maui.Storage.FileResult documentFilePickResult;

    private readonly List<Interop.API.Common.Models.Input.ProjectSpecificObjectiveInputModel> editionSpecificObjectives = [];
    private readonly List<Interop.API.Common.Models.Input.ProjectSpecificObjectiveInputModel> incomingSpecificObjectives = [];
    private readonly List<Interop.API.Common.Models.Display.ProjectSpecificObjectiveDisplayModel> outgoingSpecificObjectives = [];

    private readonly List<Interop.API.Common.Models.Input.ProjectBudgetFunancingInputModel> editionBudgetFunancings = [];
    private readonly List<Interop.API.Common.Models.Input.ProjectBudgetFunancingInputModel> incomingBudgetFunancings = [];
    private readonly List<Interop.API.Common.Models.Display.ProjectBudgetFunancingDisplayModel> outgoingBudgetFunancings = [];

    private readonly List<Interop.API.Common.Models.Input.InternalResearcherProjectParticipationInputModel> editionInternalResearcherProjectParticipations = [];
    private readonly List<Interop.API.Common.Models.Input.InternalResearcherProjectParticipationInputModel> incomingInternalResearcherProjectParticipations = [];
    private readonly List<Interop.API.Common.Models.Display.InternalResearcherProjectParticipationDisplayModel> outgoingInternalResearcherProjectParticipations = [];

    private readonly List<Interop.API.Common.Models.Input.ExternalResearcherProjectParticipationInputModel> editionExternalResearcherProjectParticipations = [];
    private readonly List<Interop.API.Common.Models.Input.ExternalResearcherProjectParticipationInputModel> incomingExternalResearcherProjectParticipations = [];
    private readonly List<Interop.API.Common.Models.Display.ExternalResearcherProjectParticipationDisplayModel> outgoingExternalResearcherProjectParticipations = [];

    public ProjectConfigurationPage(System.Action<Interop.API.Common.Models.Display.ProjectDisplayModel> successAction, Models.Page.Configuration.ProjectConfigurationPageModel model, Validators.ProjectConfigurationValidator validator) : base(successAction, model, validator)
    {
        InitializeComponent();

        if (model.Category != null)
        {
            for (int i = 0; i < model.AvailableCategories.Length; i++)
            {
                var current = model.AvailableCategories[i];

                if (model.Category.Id != current.Id) continue;

                CategoryPicker.SelectedIndex = i;

                break;
            }
        }
    }

    protected override string EntityTypeName => "Proyecto";

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProjectDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProjectsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProjectInputModel
        {
            Id = System.Guid.NewGuid(),
            Priority = ConcreteBindingContext.Priority,
            Name = ConcreteBindingContext.Name,
            Alias = ConcreteBindingContext.Alias,
            Code = ConcreteBindingContext.Code,
            StartAt = ConcreteBindingContext.StartAt,
            EndAt = ConcreteBindingContext.EndAt,
            Summary = ConcreteBindingContext.Summary,
            Problem = ConcreteBindingContext.Problem,
            Context = ConcreteBindingContext.Context,
            Beneficiary = ConcreteBindingContext.Beneficiary,
            MainObjetive = ConcreteBindingContext.MainObjetive,
            CategoryId = ConcreteBindingContext.Category.Id,
            ChiefId = ConcreteBindingContext.Chief.Id,
            ProgramId = ConcreteBindingContext.Program?.Id,
            ProposalId = ConcreteBindingContext.Proposal?.Id,
            PredecessorId = ConcreteBindingContext.Predecessor?.Id,
            ParticipatingOrganizations = [.. ConcreteBindingContext.ParticipatingOrganizations],
            ProgramExpectResults = [.. ConcreteBindingContext.ProgramExpectResults],
            IncomingSpecificObjectives = incomingSpecificObjectives,
            IncomingBudgetFunancings = incomingBudgetFunancings,
            IncomingExternalResearcherProjectParticipations = incomingExternalResearcherProjectParticipations,
            IncomingInternalResearcherProjectParticipations = incomingInternalResearcherProjectParticipations,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        if (documentFilePickResult != null)
        {
            using var stream = await documentFilePickResult.OpenReadAsync();

            model.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = documentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = MimeTypes.MimeTypeMap.GetMimeType(System.IO.Path.GetExtension(documentFilePickResult.FileName))
            };

            stream.Read(model.Document.ContentData, 0, (int)stream.Length);
        }

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ProjectDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ProjectsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new Interop.API.Common.Models.Input.ProjectInputModel
        {
            Id = ConcreteBindingContext.Id,
            Priority = ConcreteBindingContext.Priority,
            Name = ConcreteBindingContext.Name,
            Alias = ConcreteBindingContext.Alias,
            Code = ConcreteBindingContext.Code,
            StartAt = ConcreteBindingContext.StartAt,
            EndAt = ConcreteBindingContext.EndAt,
            Summary = ConcreteBindingContext.Summary,
            Problem = ConcreteBindingContext.Problem,
            Context = ConcreteBindingContext.Context,
            Beneficiary = ConcreteBindingContext.Beneficiary,
            MainObjetive = ConcreteBindingContext.MainObjetive,
            CategoryId = ConcreteBindingContext.Category.Id,
            ChiefId = ConcreteBindingContext.Chief.Id,
            ProgramId = ConcreteBindingContext.Program?.Id,
            ProposalId = ConcreteBindingContext.Proposal?.Id,
            PredecessorId = ConcreteBindingContext.Predecessor?.Id,
            ParticipatingOrganizations = [.. ConcreteBindingContext.ParticipatingOrganizations],
            ProgramExpectResults = [.. ConcreteBindingContext.ProgramExpectResults],
            IncomingSpecificObjectives = incomingSpecificObjectives,
            EditionSpecificObjectives = editionSpecificObjectives,
            OutgoingSpecificObjectives = outgoingSpecificObjectives,
            IncomingBudgetFunancings = incomingBudgetFunancings,
            EditionBudgetFunancings = editionBudgetFunancings,
            OutgoingBudgetFunancings = outgoingBudgetFunancings,
            IncomingExternalResearcherProjectParticipations = incomingExternalResearcherProjectParticipations,
            EditionExternalResearcherProjectParticipations = editionExternalResearcherProjectParticipations,
            OutgoingExternalResearcherProjectParticipations = outgoingExternalResearcherProjectParticipations,
            IncomingInternalResearcherProjectParticipations = incomingInternalResearcherProjectParticipations,
            EditionInternalResearcherProjectParticipations = editionInternalResearcherProjectParticipations,
            OutgoingInternalResearcherProjectParticipations = outgoingInternalResearcherProjectParticipations,
            NotificationUserIds = ConcreteBindingContext.NotificationUsers.Select(item => item.Id).ToArray()
        };

        if (documentFilePickResult != null)
        {
            using var stream = await documentFilePickResult.OpenReadAsync();

            model.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Input.DocumentInputModel
            {
                Id = model.Document?.Id ?? System.Guid.NewGuid(),
                Name = documentFilePickResult.FileName,
                ContentData = new byte[stream.Length],
                ContentType = MimeTypes.MimeTypeMap.GetMimeType(System.IO.Path.GetExtension(documentFilePickResult.FileName))
            };

            stream.Read(model.Document.ContentData, 0, (int)stream.Length);
        }

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

    private void Picker_SelectedIndexChanged(object sender, System.EventArgs eventArgs)
    {
        hasChangesFlag = true;
    }

    private void ProgramPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ProgramPickPage(ProgramPickComplete_Callback)));
    }

    private void ProjectProposalPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ProjectProposalPickPage(ProjectProposalPickComplete_Callback)));
    }

    private void ChiefPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.InternalResearcherPickPage(ChiefPickComplete_Callback)));
    }

    private void ParticipatingOrganizationAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ParticipatingOrganizationPickPage(ParticipatingOrganizationPickComplete_Callback)));
    }

    private void ParticipatingOrganizationRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta entidad participante?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel;

                ConcreteBindingContext.ParticipatingOrganizations.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void ProgramExpectResultAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ProgramExpectResultPickPage(ConcreteBindingContext.Program, ConcreteBindingContext.ProgramExpectResults, ProgramExpectResultPickComplete_Callback)));
    }

    private void ProgramExpectResultRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este resultado esperado de programa?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel;

                ConcreteBindingContext.ProgramExpectResults.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void DocumentPickButton_Clicked(object sender, System.EventArgs e)
    {
        Microsoft.Maui.Storage.FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
        {
            PickerTitle = "Seleccionar archivo",
            FileTypes = new Microsoft.Maui.Storage.FilePickerFileType(
                new Dictionary<Microsoft.Maui.Devices.DevicePlatform, IEnumerable<string>>
                {
                    { Microsoft.Maui.Devices.DevicePlatform.iOS, [ "public.my.comic.extension" ] }, // UTType values
                    { Microsoft.Maui.Devices.DevicePlatform.Android, [ "application/comics" ] }, // MIME type
                    { Microsoft.Maui.Devices.DevicePlatform.WinUI, [ ".doc", ".docx", ".dot", ".pdf" ] }, // file extension
                    { Microsoft.Maui.Devices.DevicePlatform.macOS, [ "cbr", "cbz" ] }, // UTType values
                })
        }).ContinueWith(async task =>
        {
            if (task.Result == null) return;

            documentFilePickResult = task.Result;

            using var stream = await documentFilePickResult.OpenReadAsync();

            var lenght = stream.Length;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.Document = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel
                {
                    Name = System.IO.Path.GetFileNameWithoutExtension(documentFilePickResult.FileName),
                    Extension = System.IO.Path.GetExtension(documentFilePickResult.FileName),
                    Length = lenght
                };
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

    #region SpecificObjective

    private void SpecificObjectiveAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new ProjectSpecificObjectiveConfigurationPage(SpecificObjectiveCreateSuccess_Callback, new Models.Page.Configuration.ProjectSpecificObjectiveConfigurationPageModel(null), new Validators.ProjectSpecificObjectiveConfigurationValidator()));
    }

    private void SpecificObjectiveEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new ProjectSpecificObjectiveConfigurationPage(SpecificObjectiveEditSuccess_Callback, new Models.Page.Configuration.ProjectSpecificObjectiveConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ProjectSpecificObjectiveDisplayModel), new Validators.ProjectSpecificObjectiveConfigurationValidator()));
    }

    private void SpecificObjectiveRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este objetivo específico?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ProjectSpecificObjectiveDisplayModel;

                var handled = false;

                foreach (var item in incomingSpecificObjectives)
                {
                    if (item.Id != target.Id) continue;

                    incomingSpecificObjectives.Remove(editionSpecificObjectives.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionSpecificObjectives)
                    {
                        if (item.Id != target.Id) continue;

                        editionSpecificObjectives.Remove(editionSpecificObjectives.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingSpecificObjectives.Add(target);
                }

                ConcreteBindingContext.SpecificObjectives.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    #endregion

    #region BudgetFunancing

    private void BudgetFunancingAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var apiClient = new Framework.Decisor.Financial.Interop.API.Connect.Clients.CurrenciesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        ConcreteBindingContext.IsBusy = true;

        apiClient.GetAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.IsBusy = false;

                if (task.IsFaulted || task.IsCanceled) 
                {
                    HandleException(task.Exception);
                }
                else
                {
                    var model = new Models.Page.Configuration.ProjectBudgetFunancingConfigurationPageModel(null);

                    model.PopulateAvailableCurrencies(task.Result);

                    this.NavigationPushPageAsync(new ProjectBudgetFunancingConfigurationPage(BudgetFunancingCreateSuccess_Callback, model));
                }
            });
        });
    }

    private void BudgetFunancingEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var apiClient = new Framework.Decisor.Financial.Interop.API.Connect.Clients.CurrenciesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        ConcreteBindingContext.IsBusy = true;

        apiClient.GetAsync().ContinueWith(task =>
        {
            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.IsBusy = false;

                if (task.IsFaulted || task.IsCanceled)
                {
                    HandleException(task.Exception);
                }
                else
                {
                    var model = new Models.Page.Configuration.ProjectBudgetFunancingConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ProjectBudgetFunancingDisplayModel);

                    model.PopulateAvailableCurrencies(task.Result);

                    this.NavigationPushPageAsync(new ProjectBudgetFunancingConfigurationPage(BudgetFunancingCreateSuccess_Callback, model));
                }
            });
        });
    }

    private void BudgetFunancingRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este financiamiento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ProjectBudgetFunancingDisplayModel;

                var handled = false;

                foreach (var item in incomingBudgetFunancings)
                {
                    if (item.Id != target.Id) continue;

                    incomingBudgetFunancings.Remove(editionBudgetFunancings.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionBudgetFunancings)
                    {
                        if (item.Id != target.Id) continue;

                        editionBudgetFunancings.Remove(editionBudgetFunancings.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingBudgetFunancings.Add(target);
                }

                ConcreteBindingContext.BudgetFunancings.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    #endregion

    #region ExternalResearcher

    private void ExternalResearcherParticipationAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new ExternalResearcherProjectParticipationConfigurationPage(ExternalResearcherParticipationCreateSuccess_Callback, new Models.Page.Configuration.ExternalResearcherProjectParticipationConfigurationPageModel(null)));
    }

    private void ExternalResearcherParticipationEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new ExternalResearcherProjectParticipationConfigurationPage(ExternalResearcherParticipationEditSuccess_Callback, new Models.Page.Configuration.ExternalResearcherProjectParticipationConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ExternalResearcherProjectParticipationDisplayModel)));
    }

    private void ExternalResearcherParticipationRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta participación de investigador externo?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.ExternalResearcherProjectParticipationDisplayModel;

                var handled = false;

                foreach (var item in incomingExternalResearcherProjectParticipations)
                {
                    if (item.Id != target.Id) continue;

                    incomingExternalResearcherProjectParticipations.Remove(editionExternalResearcherProjectParticipations.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionExternalResearcherProjectParticipations)
                    {
                        if (item.Id != target.Id) continue;

                        editionExternalResearcherProjectParticipations.Remove(editionExternalResearcherProjectParticipations.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingExternalResearcherProjectParticipations.Add(target);
                }

                ConcreteBindingContext.ExternalResearcherProjectParticipations.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    #endregion

    #region InternalResearcher

    private void InternalResearcherParticipationAgregationButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new InternalResearcherProjectParticipationConfigurationPage(InternalResearcherParticipationCreateSuccess_Callback, new Models.Page.Configuration.InternalResearcherProjectParticipationConfigurationPageModel(null)));
    }

    private void InternalResearcherParticipationEditionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushPageAsync(new InternalResearcherProjectParticipationConfigurationPage(InternalResearcherParticipationEditSuccess_Callback, new Models.Page.Configuration.InternalResearcherProjectParticipationConfigurationPageModel(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.InternalResearcherProjectParticipationDisplayModel)));
    }

    private void InternalResearcherParticipationRemotionButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar esta participación de investigador interno?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as Interop.API.Common.Models.Display.InternalResearcherProjectParticipationDisplayModel;

                var handled = false;

                foreach (var item in incomingExternalResearcherProjectParticipations)
                {
                    if (item.Id != target.Id) continue;

                    incomingInternalResearcherProjectParticipations.Remove(editionInternalResearcherProjectParticipations.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionExternalResearcherProjectParticipations)
                    {
                        if (item.Id != target.Id) continue;

                        editionInternalResearcherProjectParticipations.Remove(editionInternalResearcherProjectParticipations.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingInternalResearcherProjectParticipations.Add(target);
                }

                ConcreteBindingContext.InternalResearcherProjectParticipations.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    #endregion

    private void SpecificObjectiveCreateSuccess_Callback(Interop.API.Common.Models.Display.ProjectSpecificObjectiveDisplayModel model)
    {
        incomingSpecificObjectives.Add(new Interop.API.Common.Models.Input.ProjectSpecificObjectiveInputModel
        {
            Id = model.Id,
            Name = model.Name,
            Index = model.Index,
            Description = model.Description
        });

        ConcreteBindingContext.SpecificObjectives.Add(model);

        hasChangesFlag = true;
    }

    private void BudgetFunancingCreateSuccess_Callback(Interop.API.Common.Models.Display.ProjectBudgetFunancingDisplayModel model)
    {
        incomingBudgetFunancings.Add(new Interop.API.Common.Models.Input.ProjectBudgetFunancingInputModel
        {
            Id = model.Id,
            FinancierId = model.Financier.Id,
            CurrencyId = model.Currency.Id,
            Amount = model.Amount
        });

        ConcreteBindingContext.BudgetFunancings.Add(model);

        hasChangesFlag = true;
    }

    private void ExternalResearcherParticipationCreateSuccess_Callback(Interop.API.Common.Models.Display.ExternalResearcherProjectParticipationDisplayModel model)
    {
        incomingExternalResearcherProjectParticipations.Add(new Interop.API.Common.Models.Input.ExternalResearcherProjectParticipationInputModel
        {
            Id = model.Id,
            ResearcherId = model.Researcher.Id,
            TimeAvailability = model.TimeAvailability,
            StartAt = model.StartAt,
            EndAt = model.EndAt
        });

        ConcreteBindingContext.ExternalResearcherProjectParticipations.Add(model);

        hasChangesFlag = true;
    }

    private void InternalResearcherParticipationCreateSuccess_Callback(Interop.API.Common.Models.Display.InternalResearcherProjectParticipationDisplayModel model)
    {
        incomingInternalResearcherProjectParticipations.Add(new Interop.API.Common.Models.Input.InternalResearcherProjectParticipationInputModel
        {
            Id = model.Id,
            ResearcherId = model.Researcher.Id,
            TimeAvailability = model.TimeAvailability,
            StartAt = model.StartAt,
            EndAt = model.EndAt
        });

        ConcreteBindingContext.InternalResearcherProjectParticipations.Add(model);

        hasChangesFlag = true;
    }

    private void SpecificObjectiveEditSuccess_Callback(Interop.API.Common.Models.Display.ProjectSpecificObjectiveDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingSpecificObjectives)
        {
            if (item.Id != model.Id) continue;

            item.Name = model.Name;
            item.Index = model.Index;
            item.Description = model.Description;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionSpecificObjectives)
            {
                if (item.Id != model.Id) continue;

                item.Name = model.Name;
                item.Index = model.Index;
                item.Description = model.Description;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionSpecificObjectives.Add(new Interop.API.Common.Models.Input.ProjectSpecificObjectiveInputModel
            {
                Id = model.Id,
                Index = model.Index,
                Name = model.Name,
                Description = model.Description
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.SpecificObjectives)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.SpecificObjectives[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void BudgetFunancingEditSuccess_Callback(Interop.API.Common.Models.Display.ProjectBudgetFunancingDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingBudgetFunancings)
        {
            if (item.Id != model.Id) continue;

            item.FinancierId = model.Financier.Id;
            item.CurrencyId = model.Currency.Id;
            item.Amount = model.Amount;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionBudgetFunancings)
            {
                if (item.Id != model.Id) continue;

                item.FinancierId = model.Financier.Id;
                item.CurrencyId = model.Currency.Id;
                item.Amount = model.Amount;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionBudgetFunancings.Add(new Interop.API.Common.Models.Input.ProjectBudgetFunancingInputModel
            {
                Id = model.Id,
                FinancierId = model.Financier.Id,
                CurrencyId = model.Currency.Id,
                Amount = model.Amount
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.BudgetFunancings)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.BudgetFunancings[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void ExternalResearcherParticipationEditSuccess_Callback(Interop.API.Common.Models.Display.ExternalResearcherProjectParticipationDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingExternalResearcherProjectParticipations)
        {
            if (item.Id != model.Id) continue;

            item.ResearcherId = model.Researcher.Id;
            item.TimeAvailability = model.TimeAvailability;
            item.StartAt = model.StartAt;
            item.EndAt = model.EndAt;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionExternalResearcherProjectParticipations)
            {
                if (item.Id != model.Id) continue;

                item.ResearcherId = model.Researcher.Id;
                item.TimeAvailability = model.TimeAvailability;
                item.StartAt = model.StartAt;
                item.EndAt = model.EndAt;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionExternalResearcherProjectParticipations.Add(new Interop.API.Common.Models.Input.ExternalResearcherProjectParticipationInputModel
            {
                Id = model.Id,
                ResearcherId = model.Researcher.Id,
                TimeAvailability = model.TimeAvailability,
                StartAt = model.StartAt,
                EndAt = model.EndAt
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.ExternalResearcherProjectParticipations)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.ExternalResearcherProjectParticipations[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void InternalResearcherParticipationEditSuccess_Callback(Interop.API.Common.Models.Display.InternalResearcherProjectParticipationDisplayModel model)
    {
        var handled = false;

        foreach (var item in incomingInternalResearcherProjectParticipations)
        {
            if (item.Id != model.Id) continue;

            item.ResearcherId = model.Researcher.Id;
            item.TimeAvailability = model.TimeAvailability;
            item.StartAt = model.StartAt;
            item.EndAt = model.EndAt;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionInternalResearcherProjectParticipations)
            {
                if (item.Id != model.Id) continue;

                item.ResearcherId = model.Researcher.Id;
                item.TimeAvailability = model.TimeAvailability;
                item.StartAt = model.StartAt;
                item.EndAt = model.EndAt;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionInternalResearcherProjectParticipations.Add(new Interop.API.Common.Models.Input.InternalResearcherProjectParticipationInputModel
            {
                Id = model.Id,
                ResearcherId = model.Researcher.Id,
                TimeAvailability = model.TimeAvailability,
                StartAt = model.StartAt,
                EndAt = model.EndAt
            });
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.InternalResearcherProjectParticipations)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.InternalResearcherProjectParticipations[index] = model;

            break;
        }

        hasChangesFlag = true;
    }

    private void ProgramPickComplete_Callback(Interop.API.Common.Models.Display.ProgramDisplayModel model)
    {
        ConcreteBindingContext.Program = model;

        ConcreteBindingContext.ProgramExpectResults.Clear();

        hasChangesFlag = true;
    }

    private void ProjectProposalPickComplete_Callback(Interop.API.Common.Models.Display.ProjectProposalDisplayModel model)
    {
        ConcreteBindingContext.Proposal = model;

        hasChangesFlag = true;
    }

    private void ChiefPickComplete_Callback(Interop.API.Common.Models.Display.InternalResearcherDisplayModel model)
    {
        ConcreteBindingContext.Chief = model;

        hasChangesFlag = true;
    }

    private void ParticipatingOrganizationPickComplete_Callback(Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel model)
    {
        ConcreteBindingContext.ParticipatingOrganizations.Add(model);

        hasChangesFlag = true;
    }

    private void ProgramExpectResultPickComplete_Callback(Interop.API.Common.Models.Display.ProgramExpectResultDisplayModel model)
    {
        ConcreteBindingContext.ProgramExpectResults.Add(model);

        hasChangesFlag = true;
    }
}