namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class NaturalClientSampleAnalysisServiceOrderDisplayModel : Contract.AbstractSampleAnalysisServiceOrderDisplayModel<Persistence.Entities.NaturalClientSampleAnalysisServiceOrder>
    {
        public NaturalClientServicingContractDisplayModel Contract { get; set; }

        public override void Import(Persistence.Entities.NaturalClientSampleAnalysisServiceOrder entity)
        {
            base.Import(entity);

            if (entity.Contract != null)
            {
                Contract = new NaturalClientServicingContractDisplayModel();

                Contract.Import(entity.Contract);
            }
        }
    }
}