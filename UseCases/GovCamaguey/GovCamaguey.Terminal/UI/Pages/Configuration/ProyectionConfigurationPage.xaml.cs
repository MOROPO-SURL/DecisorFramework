using MOROPO.Framework.Caney.MVVM.Core.Extensions;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Configuration;

public partial class ProyectionConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<ProyectionInputModel, Models.Page.Configuration.ProyectionConfigurationPageModel>
{
    private readonly List<ActionInputModel> editionActions = [];
    private readonly List<ActionInputModel> incomingActions = [];
    private readonly List<ActionDisplayModel> outgoingActions = [];

    public ProyectionConfigurationPage(System.Action<ProyectionInputModel> successAction, Models.Page.Configuration.ProyectionConfigurationPageModel model) : base(successAction, model)
    {
        InitializeComponent();
    }

    public ProyectionConfigurationPage(System.Action<ProyectionInputModel> successAction, Models.Page.Configuration.ProyectionConfigurationPageModel model, List<ActionInputModel> editionActions, List<ActionInputModel> incomingActions, List<ActionDisplayModel> outgoingActions) : this(successAction, model)
    {
        this.editionActions = editionActions;
        this.incomingActions = incomingActions;
        this.outgoingActions = outgoingActions;
    }

    protected override string EntityTypeName => "Proyección";

    protected override System.Threading.Tasks.Task<ProyectionInputModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new ProyectionInputModel
        {
            Id = System.Guid.NewGuid(),
            Index = ConcreteBindingContext.Index,
            Name = ConcreteBindingContext.Name,
            Description = ConcreteBindingContext.Description,
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
            IncomingActions = incomingActions,
            EditionActions = editionActions,
            OutgoingActions = outgoingActions
        });
    }

    private void ActionAgregationButton_Clicked(object sender, System.EventArgs e)
    {
        this.NavigationPushPageAsync(new ActionConfigurationPage(ActionCreateSuccess_Callback, new Models.Page.Configuration.ActionConfigurationPageModel(null)));
    }

    private void ActionEditionButton_Clicked(object sender, System.EventArgs e)
    {
        var target = ((Microsoft.Maui.Controls.BindableObject)sender).BindingContext as ActionDisplayModel;

        var model = incomingActions.FirstOrDefault(_model => _model.Id == target.Id) ?? editionActions.FirstOrDefault(_model => _model.Id == target.Id);

        model ??= new ActionInputModel
        {
            Id = target.Id,
            Index = target.Index,
            Name = target.Name,
            Description = target.Description
        };
        
        this.NavigationPushPageAsync(new ActionConfigurationPage(ActionEditSuccess_Callback, new Models.Page.Configuration.ActionConfigurationPageModel(model, target.Indicators), model.EditionIndicators, model.IncomingIndicators, model.OutgoingIndicators));
    }

    private void ActionRemotionButton_Clicked(object sender, System.EventArgs e)
    {
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

    private void ActionCreateSuccess_Callback(ActionInputModel model)
    {
        incomingActions.Add(model);

        ConcreteBindingContext.Actions.Add(new ActionDisplayModel
        {
            Id = model.Id,
            Index = model.Index,
            Name = model.Name,
            Description = model.Description
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
                Description = model.Description
            };

            break;
        }

        hasChangesFlag = true;
    }
}