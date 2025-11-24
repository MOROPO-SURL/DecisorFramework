namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class NaturalClientSampleAnalysisServiceOrderInputModel : Contract.AbstractSampleAnalysisServiceOrderInputModel<Persistence.Entities.NaturalClientSampleAnalysisServiceOrder>
    {
        public System.Guid ContractId { get; set; }

        public override Persistence.Entities.NaturalClientSampleAnalysisServiceOrder Export()
        {
            var entity = new Persistence.Entities.NaturalClientSampleAnalysisServiceOrder { Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.NaturalClientSampleAnalysisServiceOrder entity)
        {
            base.Mergue(entity);

            if (entity.SampleAnalysisNaturalClientContractId != ContractId)
            {
                entity.Contract = null;
                entity.SampleAnalysisNaturalClientContractId = ContractId;
            }
        }
    }
}
