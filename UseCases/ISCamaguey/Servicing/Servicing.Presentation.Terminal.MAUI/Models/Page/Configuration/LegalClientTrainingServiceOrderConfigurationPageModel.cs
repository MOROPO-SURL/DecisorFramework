
namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class LegalClientTrainingServiceOrderConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.LegalClientTrainingServiceOrderDisplayModel>
    {
        public static string ContractValidableProperty => nameof(Contract);
        public static string ServiceValidableProperty => nameof(Service);
        public static string DescriptionValidableProperty => nameof(Description);

        private Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel contract;
        private Interop.API.Common.Models.Display.TrainingServiceDisplayModel service;
        private string description;

        public LegalClientTrainingServiceOrderConfigurationPageModel(Interop.API.Common.Models.Display.LegalClientTrainingServiceOrderDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            contract = model.Contract;
            service = model.Service;
            description = model.Description;
        }

        public long Id { get; set; }

        public Interop.API.Common.Models.Display.LegalClientServicingContractDisplayModel Contract { get => contract; set => SetProperty(ref contract, value); }

        public Interop.API.Common.Models.Display.TrainingServiceDisplayModel Service { get => service; set => SetProperty(ref service, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }
    }
}
