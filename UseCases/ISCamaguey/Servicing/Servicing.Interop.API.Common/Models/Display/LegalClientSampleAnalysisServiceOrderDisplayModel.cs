namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class LegalClientSampleAnalysisServiceOrderDisplayModel : Contract.AbstractSampleAnalysisServiceOrderDisplayModel<Persistence.Entities.LegalClientSampleAnalysisServiceOrder>
    {
        public LegalClientServicingContractDisplayModel Contract { get; set; }

        public override void Import(Persistence.Entities.LegalClientSampleAnalysisServiceOrder entity)
        {
            base.Import(entity);

            if (entity.Contract != null)
            {
                Contract = new LegalClientServicingContractDisplayModel();

                Contract.Import(entity.Contract);
            }
        }
    }
}
