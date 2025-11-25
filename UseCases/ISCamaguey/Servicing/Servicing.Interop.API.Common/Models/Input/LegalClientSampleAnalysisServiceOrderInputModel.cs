namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class LegalClientSampleAnalysisServiceOrderInputModel : Contract.AbstractSampleAnalysisServiceOrderInputModel<Persistence.Entities.LegalClientSampleAnalysisServiceOrder>
    {
        public System.Guid ContractId { get; set; }

        public override Persistence.Entities.LegalClientSampleAnalysisServiceOrder Export()
        {
            var entity = new Persistence.Entities.LegalClientSampleAnalysisServiceOrder { Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.LegalClientSampleAnalysisServiceOrder entity)
        {
            base.Mergue(entity);

            if (entity.SampleAnalysisLegalClientContractId != ContractId)
            {
                entity.Contract = null;
                entity.SampleAnalysisLegalClientContractId = ContractId;
            }
        }
    }
}
