using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Configuration;

public partial class ObjectiveConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ObjectiveDisplayModel, ObjectiveDisplayModel, Models.Page.Configuration.ObjectiveConfigurationPageModel>
{
    private readonly List<ProyectionInputModel> editionProyections = [];
    private readonly List<ProyectionInputModel> incomingProyections = [];
    private readonly List<ProyectionDisplayModel> outgoingProyections = [];

    public ObjectiveConfigurationPage(System.Action<ObjectiveDisplayModel> successAction, Models.Page.Configuration.ObjectiveConfigurationPageModel model) : base(successAction, model, new Validators.ObjectiveConfigurationValidator())
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Objetivo";

    protected override async System.Threading.Tasks.Task<ObjectiveDisplayModel> PerformCreationAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ObjectivesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new ObjectiveInputModel
        {
            Id = System.Guid.NewGuid(),
            Index = ConcreteBindingContext.Index,
            Name = ConcreteBindingContext.Name,
            ResponsibleId = ConcreteBindingContext.Responsible.Id,
            Description = ConcreteBindingContext.Description,
            IncomingProyections = incomingProyections
        };

        await apiConnectClient.CreateAsync(model);

        return await apiConnectClient.GetAsync(model.Id);
    }

    protected override async System.Threading.Tasks.Task<ObjectiveDisplayModel> PerformEditionAsync()
    {
        var apiConnectClient = new Interop.API.Connect.Clients.ObjectivesAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        var model = new ObjectiveInputModel
        {
            Id = ConcreteBindingContext.Id,
            Index = ConcreteBindingContext.Index,
            Name = ConcreteBindingContext.Name,
            ResponsibleId = ConcreteBindingContext.Responsible.Id,
            Description = ConcreteBindingContext.Description,
            IncomingProyections = incomingProyections,
            EditionProyections = editionProyections,
            OutgoingProyections = outgoingProyections
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

    private void ResponsiblePickButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.PersonPickPage(ResponsiblePickComplete_Callback)));
    }

    private void ProyectionAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

        if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == Interop.API.Common.Constants.Security.Authorization.ProyectionCreatorPermission)))
        {
            DisplayAlert("Aviso", "Su usuario no cuenta con permisos para agregar nuevos elementos de este tipo. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

            return;
        }

        this.NavigationPushPageAsync(new ProyectionConfigurationPage(ProyectionCreateSuccess_Callback, new Models.Page.Configuration.ProyectionConfigurationPageModel(null)));
    }

    private void ProyectionEditionButton_Clicked(object sender, System.EventArgs e)
    {
        var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

        if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == Interop.API.Common.Constants.Security.Authorization.ProyectionEditorPermission)))
        {
            DisplayAlert("Aviso", "Su usuario no cuenta con permisos para modificar elementos registrados de este tipo. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

            return;
        }

        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ProyectionDisplayModel;

        var model = incomingProyections.FirstOrDefault(_model => _model.Id == target.Id) ?? editionProyections.FirstOrDefault(_model => _model.Id == target.Id);

        model ??= new ProyectionInputModel
        {
            Id = target.Id,
            Index = target.Index,
            Name = target.Name,
            Description = target.Description,
            Guidelines = target.Guidelines,
            ResponsabilityOrganizations = target.ResponsabilityOrganizations,
            ParticipationOrganizations = target.ParticipationOrganizations
        };
        
        this.NavigationPushPageAsync(new ProyectionConfigurationPage(ProyectionEditSuccess_Callback, new Models.Page.Configuration.ProyectionConfigurationPageModel(model, target.Actions), model.EditionActions, model.IncomingActions, model.OutgoingActions));
    }

    private void ProyectionRemotionButton_Clicked(object sender, System.EventArgs e)
    {
        var user = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>().CurrentSession.User;

        if (!user.HasFullAccess && !user.Roles.Any(item => item.Permissions.Any(_item => _item.Code == Interop.API.Common.Constants.Security.Authorization.ProyectionRemoverPermission)))
        {
            DisplayAlert("Aviso", "Su usuario no cuenta con permisos para retirar elementos registrados de este tipo. Póngase en contacto con los administradores del sistema para solicitar los permisos requeridos.", "Aceptar");

            return;
        }

        DisplayAlert("Confirmación", "Está seguro que desea retirar esta proyección?", "Confirmar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            Dispatcher.Dispatch(() =>
            {
                var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ProyectionDisplayModel;

                var handled = false;

                foreach (var item in incomingProyections)
                {
                    if (item.Id != target.Id) continue;

                    incomingProyections.Remove(incomingProyections.First(model => model.Id == target.Id));

                    handled = true;

                    break;
                }

                if (!handled)
                {
                    foreach (var item in editionProyections)
                    {
                        if (item.Id != target.Id) continue;

                        editionProyections.Remove(editionProyections.First(model => model.Id == target.Id));

                        break;
                    }
                }

                if (!handled)
                {
                    outgoingProyections.Add(target);
                }

                ConcreteBindingContext.Proyections.Remove(target);

                hasChangesFlag = true;
            });
        });
    }

    private void ProyectionCreateSuccess_Callback(ProyectionInputModel model)
    {
        incomingProyections.Add(model);

        ConcreteBindingContext.Proyections.Add(new ProyectionDisplayModel
        {
            Id = model.Id,
            Index = model.Index,
            Name = model.Name,
            Description = model.Description,
            Guidelines = model.Guidelines,
            ResponsabilityOrganizations = model.ResponsabilityOrganizations,
            ParticipationOrganizations = model.ParticipationOrganizations
        });

        hasChangesFlag = true;
    }

    private void ProyectionEditSuccess_Callback(ProyectionInputModel model)
    {
        var handled = false;

        foreach (var item in incomingProyections)
        {
            if (item.Id != model.Id) continue;

            item.Index = model.Index;
            item.Name = model.Name;
            item.Description = model.Description;
            item.Guidelines = model.Guidelines;
            item.ResponsabilityOrganizations = model.ResponsabilityOrganizations;
            item.ParticipationOrganizations = model.ParticipationOrganizations;
            item.IncomingActions = model.IncomingActions;

            handled = true;

            break;
        }

        if (!handled)
        {
            foreach (var item in editionProyections)
            {
                if (item.Id != model.Id) continue;

                item.Index = model.Index;
                item.Name = model.Name;
                item.Description = model.Description;
                item.Guidelines = model.Guidelines;
                item.ResponsabilityOrganizations = model.ResponsabilityOrganizations;
                item.ParticipationOrganizations = model.ParticipationOrganizations;
                item.IncomingActions = model.IncomingActions;
                item.EditionActions = model.EditionActions;
                item.OutgoingActions = model.OutgoingActions;

                handled = true;

                break;
            }
        }

        if (!handled)
        {
            editionProyections.Add(model);
        }

        var index = -1;

        foreach (var item in ConcreteBindingContext.Proyections)
        {
            index++;

            if (item.Id != model.Id) continue;

            ConcreteBindingContext.Proyections[index] = new ProyectionDisplayModel
            {
                Id = model.Id,
                Index = model.Index,
                Name = model.Name,
                Description = model.Description,
                Guidelines = model.Guidelines,
                ResponsabilityOrganizations = model.ResponsabilityOrganizations,
                ParticipationOrganizations = model.ParticipationOrganizations
            };

            break;
        }

        hasChangesFlag = true;
    }

    private void ResponsiblePickComplete_Callback(PersonDisplayModel model)
    {
        ConcreteBindingContext.Responsible = model;
    }
}