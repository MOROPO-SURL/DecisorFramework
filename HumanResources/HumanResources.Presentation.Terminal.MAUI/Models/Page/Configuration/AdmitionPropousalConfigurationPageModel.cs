namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class AdmitionPropousalConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel>
{
    public static string CandidateValidableProperty => nameof(Candidate);
    public static string AgreementValidableProperty => nameof(Agreement);

    private System.DateTime at;
    private Interop.API.Common.Models.Display.OcupationCandidateDisplayModel candidate;
    private Governance.Interop.API.Common.Models.Display.AgreementDisplayModel agreement;
    private string argument;

    public AdmitionPropousalConfigurationPageModel(Interop.API.Common.Models.Display.AdmitionPropousalDisplayModel model) : base(model)
    {
        if (model != null)
        {
            Id = model.Id;
            at = model.At;
            candidate = model.Candidate;
            agreement = model.Agreement;
            argument = model.Argument;
        }
        else
        {
            at = System.DateTime.Now;
        }
    }

    public System.Guid Id { get; set; }

    public System.DateTime At { get => at; set => SetProperty(ref at, value); }

    public Interop.API.Common.Models.Display.OcupationCandidateDisplayModel Candidate { get => candidate; set => SetProperty(ref candidate, value); }

    public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get => agreement; set => SetProperty(ref agreement, value); }

    public string Argument { get => argument; set => SetProperty(ref argument, value); }
}
