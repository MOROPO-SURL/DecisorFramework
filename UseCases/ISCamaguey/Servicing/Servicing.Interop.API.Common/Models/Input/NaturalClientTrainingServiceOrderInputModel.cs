
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class NaturalClientTrainingServiceOrderInputModel : Contract.AbstractTrainingServiceOrderInputModel<Persistence.Entities.NaturalClientTrainingServiceOrder>
    {
        public System.Guid ContractId { get; set; }

        public override Persistence.Entities.NaturalClientTrainingServiceOrder Export()
        {
            var entity = new Persistence.Entities.NaturalClientTrainingServiceOrder { Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.NaturalClientTrainingServiceOrder entity)
        {
            base.Mergue(entity);

            if (entity.TrainingNaturalClientContractId != ContractId)
            {
                entity.Contract = null;
                entity.TrainingNaturalClientContractId = ContractId;
            }
        }
    }
}
