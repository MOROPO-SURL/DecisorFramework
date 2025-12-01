
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class LegalClientGroundIntegralStudyServiceOrderInputModel : Contract.AbstractGroundIntegralStudyServiceOrderInputModel<Persistence.Entities.LegalClientGroundIntegralStudyServiceOrder>
    {
        public System.Guid ContractId { get; set; }

        public override Persistence.Entities.LegalClientGroundIntegralStudyServiceOrder Export()
        {
            var entity = new Persistence.Entities.LegalClientGroundIntegralStudyServiceOrder { Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.LegalClientGroundIntegralStudyServiceOrder entity)
        {
            base.Mergue(entity);

            if (entity.GroundIntegralStudyLegalClientContractId != ContractId)
            {
                entity.Contract = null;
                entity.GroundIntegralStudyLegalClientContractId = ContractId;
            }
        }
    }
}
