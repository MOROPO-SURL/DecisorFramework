
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class LegalClientTrainingServiceOrderInputModel : Contract.AbstractTrainingServiceOrderInputModel<Persistence.Entities.LegalClientTrainingServiceOrder>
    {
        public System.Guid ContractId { get; set; }

        public override Persistence.Entities.LegalClientTrainingServiceOrder Export()
        {
            var entity = new Persistence.Entities.LegalClientTrainingServiceOrder { Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.LegalClientTrainingServiceOrder entity)
        {
            base.Mergue(entity);

            if (entity.TrainingLegalClientContractId != ContractId)
            {
                entity.Contract = null;
                entity.TrainingLegalClientContractId = ContractId;
            }
        }
    }
}
