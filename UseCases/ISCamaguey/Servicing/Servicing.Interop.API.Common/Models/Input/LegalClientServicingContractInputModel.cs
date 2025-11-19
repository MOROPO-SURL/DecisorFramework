using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class LegalClientServicingContractInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.LegalClientServicingContract, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        public int Year { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Objective { get; set; }

        public int? DurationUnitCount { get; set; }

        public Framework.Decisor.Legal.Persistence.Enumerations.DurationUnitMeasureKind? DurationUnitMeasureKind { get; set; }

        public System.Guid ClientId { get; set; }

        public System.Guid PaymentTermId { get; set; }

        public System.Guid BankAccountId { get; set; }

        public System.Collections.Generic.List<Display.TrainingServiceDisplayModel> TrainingServices { get; set; } = new System.Collections.Generic.List<Display.TrainingServiceDisplayModel>();

        public System.Collections.Generic.List<Display.GroundIntegralStudyServiceDisplayModel> GroundIntegralStudyServices { get; set; } = new System.Collections.Generic.List<Display.GroundIntegralStudyServiceDisplayModel>();

        public System.Collections.Generic.List<Display.SampleAnalysisServiceDisplayModel> SampleAnalysisServices { get; set; } = new System.Collections.Generic.List<Display.SampleAnalysisServiceDisplayModel>();

        public Persistence.Entities.LegalClientServicingContract Export()
        {
            var entity = new Persistence.Entities.LegalClientServicingContract();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.LegalClientServicingContract entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.LegalClientServicingContract entity)
        {
            entity.Index = Index;
            entity.Year = Year;
            entity.Objective = Objective;
            entity.DurationUnitCount = DurationUnitCount;
            entity.DurationUnitMeasureKind = DurationUnitMeasureKind;

            if (entity.ServicingLegalClientId != ClientId)
            {
                entity.Client = null;
                entity.ServicingLegalClientId = ClientId;
            }

            if (entity.PaymentTermId != PaymentTermId)
            {
                entity.PaymentTerm = null;
                entity.PaymentTermId = PaymentTermId;
            }

            if (entity.BankAccountId != BankAccountId)
            {
                entity.BankAccount = null;
                entity.BankAccountId = BankAccountId;
            }

            entity.TrainingServiceBridges.Clear();
            entity.TrainingServiceBridges = TrainingServices.Select(model => new Persistence.Entities.ServicingContractTrainingServiceBridge { ProwId = entity.Id, SternId = model.Id }).ToList();

            entity.GroundIntegralStudyServiceBridges.Clear();
            entity.GroundIntegralStudyServiceBridges = GroundIntegralStudyServices.Select(model => new Persistence.Entities.ServicingContractGroundIntegralStudyServiceBridge { ProwId = entity.Id, SternId = model.Id }).ToList();

            entity.SampleAnalysisServiceBridges.Clear();
            entity.SampleAnalysisServiceBridges = SampleAnalysisServices.Select(model => new Persistence.Entities.ServicingContractSampleAnalysisServiceBridge { ProwId = entity.Id, SternId = model.Id }).ToList();
        }
    }
}
