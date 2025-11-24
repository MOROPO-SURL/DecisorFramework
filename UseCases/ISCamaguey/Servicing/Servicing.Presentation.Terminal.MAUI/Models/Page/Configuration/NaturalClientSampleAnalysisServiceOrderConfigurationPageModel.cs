namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class NaturalClientSampleAnalysisServiceOrderConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel>
{
    public static string ContractValidableProperty => nameof(Contract);
    public static string ServiceValidableProperty => nameof(Service);
    public static string DescriptionValidableProperty => nameof(Description);

    private Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel contract;
    private Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel service;
    private Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel requestedTechnique;
    private string description;

    public NaturalClientSampleAnalysisServiceOrderConfigurationPageModel(Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel model) : base(model)
    {
        if (model == null) return;

        Id = model.Id;
        contract = model.Contract;
        service = model.Service;
        requestedTechnique = model.RequestedTechnique;
        description = model.Description;
    }

    public long Id { get; set; }

    public Interop.API.Common.Models.Display.NaturalClientServicingContractDisplayModel Contract { get => contract; set => SetProperty(ref contract, value); }

    public Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel Service { get => service; set => SetProperty(ref service, value); }

    public Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel RequestedTechnique { get => requestedTechnique; set => SetProperty(ref requestedTechnique, value); }

    public string Description { get => description; set => SetProperty(ref description, value); }
}
