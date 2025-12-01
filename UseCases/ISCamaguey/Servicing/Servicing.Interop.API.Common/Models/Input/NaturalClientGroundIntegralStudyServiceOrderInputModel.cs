
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class NaturalClientGroundIntegralStudyServiceOrderInputModel : Contract.AbstractGroundIntegralStudyServiceOrderInputModel<Persistence.Entities.NaturalClientGroundIntegralStudyServiceOrder>
    {
        public System.Guid ContractId { get; set; }

        public override Persistence.Entities.NaturalClientGroundIntegralStudyServiceOrder Export()
        {
            var entity = new Persistence.Entities.NaturalClientGroundIntegralStudyServiceOrder { Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.NaturalClientGroundIntegralStudyServiceOrder entity)
        {
            base.Mergue(entity);

            if (entity.GroundIntegralStudyNaturalClientContractId != ContractId)
            {
                entity.Contract = null;
                entity.GroundIntegralStudyNaturalClientContractId = ContractId;
            }
        }
    }
}
