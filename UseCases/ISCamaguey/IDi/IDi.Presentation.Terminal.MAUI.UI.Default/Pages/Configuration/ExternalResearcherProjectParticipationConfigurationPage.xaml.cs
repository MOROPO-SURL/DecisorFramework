using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class ExternalResearcherProjectParticipationConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ExternalResearcherProjectParticipationDisplayModel, Interop.API.Common.Models.Display.ExternalResearcherProjectParticipationDisplayModel, Models.Page.Configuration.ExternalResearcherProjectParticipationConfigurationPageModel>
{
    public ExternalResearcherProjectParticipationConfigurationPage(System.Action<Interop.API.Common.Models.Display.ExternalResearcherProjectParticipationDisplayModel> successAction, Models.Page.Configuration.ExternalResearcherProjectParticipationConfigurationPageModel model) : base(successAction, model, new Validators.ExternalResearcherProjectParticipationConfigurationValidator())
    {
        InitializeComponent();
    }

    protected override string EntityTypeName => "Participación en Proyecto (Externo)";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ExternalResearcherProjectParticipationDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.ExternalResearcherProjectParticipationDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Researcher = ConcreteBindingContext.Researcher,
            StartAt = ConcreteBindingContext.StartAt,
            EndAt = ConcreteBindingContext.EndAt,
            TimeAvailability = ConcreteBindingContext.TimeAvailability
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.ExternalResearcherProjectParticipationDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.ExternalResearcherProjectParticipationDisplayModel
        {
            Id = ConcreteBindingContext.Id,
            Researcher = ConcreteBindingContext.Researcher,
            StartAt = ConcreteBindingContext.StartAt,
            EndAt = ConcreteBindingContext.EndAt,
            TimeAvailability = ConcreteBindingContext.TimeAvailability
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

    private void ResearcherPickButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.ExternalResearcherPickPage(ResearcherPickComplete_Callback)));
    }

    private void ResearcherPickComplete_Callback(Interop.API.Common.Models.Display.ExternalResearcherDisplayModel model)
    {
        ConcreteBindingContext.Researcher = model;

        hasChangesFlag = true;
    }
}