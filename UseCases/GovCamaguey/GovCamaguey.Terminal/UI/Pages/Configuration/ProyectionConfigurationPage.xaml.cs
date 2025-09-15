using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Configuration;

public partial class ProyectionConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ProyectionInputModel, ProyectionInputModel, Models.Page.Configuration.ProyectionConfigurationPageModel>
{
    private readonly List<ActionInputModel> editionActions = [];
    private readonly List<ActionInputModel> incomingActions = [];
    private readonly List<ActionDisplayModel> outgoingActions = [];

    public ProyectionConfigurationPage(System.Action<ProyectionInputModel> successAction, Models.Page.Configuration.ProyectionConfigurationPageModel model) : base(successAction, model, new Validators.ProyectionConfigurationValidator())
    {
        InitializeComponent();
    }

    public ProyectionConfigurationPage(System.Action<ProyectionInputModel> successAction, Models.Page.Configuration.ProyectionConfigurationPageModel model, List<ActionInputModel> editionActions, List<ActionInputModel> incomingActions, List<ActionDisplayModel> outgoingActions) : this(successAction, model)
    {
        this.editionActions = editionActions;
        this.incomingActions = incomingActions;
        this.outgoingActions = outgoingActions;
    }

    protected override string EntityTypeName => "Objetivo Específico";

    protected override System.Threading.Tasks.Task<ProyectionInputModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new ProyectionInputModel
        {
            Id = System.Guid.NewGuid(),
            Index = ConcreteBindingContext.Index,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Guidelines = [.. ConcreteBindingContext.Guidelines],
            ResponsabilityOrganizations = [.. ConcreteBindingContext.ResponsabilityOrganizations],
            ParticipationOrganizations = [.. ConcreteBindingContext.ParticipationOrganizations],
            IncomingActions = incomingActions
        });
    }

    protected override System.Threading.Tasks.Task<ProyectionInputModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new ProyectionInputModel
        {
            Id = ConcreteBindingContext.Id,
            Index = ConcreteBindingContext.Index,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
            Guidelines = [.. ConcreteBindingContext.Guidelines],
            ResponsabilityOrganizations = [.. ConcreteBindingContext.ResponsabilityOrganizations],
            ParticipationOrganizations = [.. ConcreteBindingContext.ParticipationOrganizations],
            IncomingActions = incomingActions,
            EditionActions = editionActions,
            OutgoingActions = outgoingActions
        });
    }

    private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnApply(sender, eventArgs);
    }

    private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
    {
        OnCancel(sender, eventArgs);
    }

    private void ActionAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

        if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == Interop.API.Common.Constants.Security.Authorization.ActionCreatorPermission)))
        {
            DisplayAlert("Aviso", "Su usuario no cuenta con permisos para agregar nuevos elementos de este tipo. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

            return;
        }

        this.NavigationPushPageAsync(new ActionConfigurationPage(ActionCreateSuccess_Callback, new Models.Page.Configuration.ActionConfigurationPageModel(null)));
    }

    private void ActionEditionButton_Clicked(object sender, System.EventArgs e)
    {
        var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

        if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == Interop.API.Common.Constants.Security.Authorization.ActionEditorPermission)))
        {
            DisplayAlert("Aviso", "Su usuario no cuenta con permisos para modificar elementos registrados de este tipo. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

            return;
        }

        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ActionDisplayModel;

        var model = incomingActions.FirstOrDefault(_model => _model.Id == target.Id) ?? editionActions.FirstOrDefault(_model => _model.Id == target.Id);

        model ??= new ActionInputModel
        {
            Id = target.Id,
            Index = target.Index,
            Name = target.Name,
            Description = target.Description,
            ResponsabilityOrganizations = target.ResponsabilityOrganizations,
            ParticipationOrganizations = target.ParticipationOrganizations
        };
        
        this.NavigationPushPageAsync(new ActionConfigurationPage(ActionEditSuccess_Callback, new Models.Page.Configuration.ActionConfigurationPageModel(model, target.Indicators, target.MonthlyClosures), model.EditionIndicators, model.IncomingIndicators, model.OutgoingIndicators, model.EditionMonthlyClosures, model.IncomingMonthlyClosures, model.OutgoingMonthlyClosures));
    }

    private void ActionRemotionButton_Clicked(object sender, System.EventArgs e)
    {
        var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

        if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == Interop.API.Common.Constants.Security.Authorization.ActionRemoverPermission)))
        {
            DisplayAlert("Aviso", "Su usuario no cuenta con permisos para retirar elementos registrados de este tipo. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

            return;
        }

        DisplayAlert("Confirmación", "Está seguro que desea retirar esta proyección?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ActionDisplayModel;

                var handled = false;

                foreach (var item in incomingActions)
                {
                    if (item.Id != target.Id) continue;

                    incomingActions.Remove(incomingActions.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionActions)
                    {
                        if (item.Id != target.Id) continue;

                        editionActions.Remove(editionActions.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingActions.Add(target);
                }

                ConcreteBindingContext.Actions.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void AddOrganizationParticipationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.OrganizationPickPage(ParticipationOrganizationPickComplete_Callback)));
    }

    private void AddOrganizationResponsabilityButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.OrganizationPickPage(ResponsabilityOrganizationPickComplete_Callback)));
    }

    private void AddGuidelineButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.GuidelinePickPage(GuidelinePickComplete_Callback)));
    }

    private void ParticipationOrganizationRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este organismo participante?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.ParticipationOrganizations.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as OrganizationDisplayModel);

                hasChangesFlag = true;
            });
        });
    }

    private void ResponsabilityOrganizationRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este organismo responsable?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.ResponsabilityOrganizations.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as OrganizationDisplayModel);

                hasChangesFlag = true;
            });
        });
    }

    private void GuidelineRemoveButton_Clicked(object sender, System.EventArgs e)
    {
        DisplayAlert("Confirmación", "Está seguro que desea retirar este lineamiento?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                ConcreteBindingContext.Guidelines.Remove(((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as GuidelineDisplayModel);

                hasChangesFlag = true;
            });
        });
    }

    private void ActionCreateSuccess_Callback(ActionInputModel model)
    {
        incomingActions.Add(model);

        ConcreteBindingContext.Actions.Add(new ActionDisplayModel
        {
            Id = model.Id,
            Index = model.Index,
            Name = model.Name,
            Description = model.Description,
            ResponsabilityOrganizations = model.ResponsabilityOrganizations,
            ParticipationOrganizations = model.ParticipationOrganizations
        });

        hasChangesFlag = true;
    }

    private void ActionEditSuccess_Callback(ActionInputModel model)
    {
        var handled = false;

        foreach (var item in incomingActions)
        {
            if (item.Id != model.Id) continue;

            item.Index = model.Index;
            item.Name = model.Name;
            item.Description = model.Description;
            item.ResponsabilityOrganizations = model.ResponsabilityOrganizations;
            item.ParticipationOrganizations = model.ParticipationOrganizations;
            item.IncomingIndicators = model.IncomingIndicators;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionActions)
            {
                if (item.Id != model.Id) continue;

                item.Index = model.Index;
                item.Name = model.Name;
                item.Description = model.Description;
                item.ResponsabilityOrganizations = model.ResponsabilityOrganizations;
                item.ParticipationOrganizations = model.ParticipationOrganizations;
                item.IncomingIndicators = model.IncomingIndicators;
                item.EditionIndicators = model.EditionIndicators;
                item.OutgoingIndicators = model.OutgoingIndicators;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionActions.Add(model);
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.Actions)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.Actions[index] = new ActionDisplayModel
            {
                Id = model.Id,
                Index = model.Index,
                Name = model.Name,
                Description = model.Description,
                ResponsabilityOrganizations = model.ResponsabilityOrganizations,
                ParticipationOrganizations = model.ParticipationOrganizations
            };

            break;
        }

        hasChangesFlag = true;
    }

    private void ParticipationOrganizationPickComplete_Callback(OrganizationDisplayModel model)
    {
        ConcreteBindingContext.ParticipationOrganizations.Add(model);

        hasChangesFlag = true;
    }

    private void ResponsabilityOrganizationPickComplete_Callback(OrganizationDisplayModel model)
    {
        ConcreteBindingContext.ResponsabilityOrganizations.Add(model);

        hasChangesFlag = true;
    }

    private void GuidelinePickComplete_Callback(GuidelineDisplayModel model)
    {
        ConcreteBindingContext.Guidelines.Add(model);

        hasChangesFlag = true;
    }
}