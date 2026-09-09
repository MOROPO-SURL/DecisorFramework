using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;

public partial class InternalResearcherProjectParticipationConfigurationPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.InternalResearcherProjectParticipationDisplayModel, Interop.API.Common.Models.Display.InternalResearcherProjectParticipationDisplayModel, Models.Page.Configuration.InternalResearcherProjectParticipationConfigurationPageModel>
{
	public InternalResearcherProjectParticipationConfigurationPage(System.Action<Interop.API.Common.Models.Display.InternalResearcherProjectParticipationDisplayModel> successAction, Models.Page.Configuration.InternalResearcherProjectParticipationConfigurationPageModel model) : base(successAction, model, new Validators.InternalResearcherProjectParticipationConfigurationValidator())
    {
		InitializeComponent();
    }

    protected override string EntityTypeName => "Participación en Proyecto (Interno)";

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.InternalResearcherProjectParticipationDisplayModel> PerformCreationAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.InternalResearcherProjectParticipationDisplayModel
        {
            Id = System.Guid.NewGuid(),
            Researcher = ConcreteBindingContext.Researcher,
            StartAt = ConcreteBindingContext.StartAt,
            EndAt = ConcreteBindingContext.EndAt,
            TimeAvailability = ConcreteBindingContext.TimeAvailability
        });
    }

    protected override System.Threading.Tasks.Task<Interop.API.Common.Models.Display.InternalResearcherProjectParticipationDisplayModel> PerformEditionAsync()
    {
        return System.Threading.Tasks.Task.FromResult(new Interop.API.Common.Models.Display.InternalResearcherProjectParticipationDisplayModel
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
        this.NavigationPushModalPageAsync(new Microsoft.Maui.Controls.NavigationPage(new Pick.InternalResearcherPickPage(ResearcherPickComplete_Callback)));
    }

    private void ResearcherPickComplete_Callback(Interop.API.Common.Models.Display.InternalResearcherDisplayModel model)
    {
        ConcreteBindingContext.Researcher = model;

        hasChangesFlag = true;
    }
}