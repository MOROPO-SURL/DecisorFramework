namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public sealed class LegalClientSampleAnalysisServiceExecutionDisplayModel : Contract.AbstractExecutionDisplayModel<Persistence.Entities.LegalClientSampleAnalysisServiceExecution>
    {
        public LegalClientSampleAnalysisServiceOrderDisplayModel Order { get; set; }

        public override void Import(Persistence.Entities.LegalClientSampleAnalysisServiceExecution entity)
        {
            base.Import(entity);

            if (entity.Order != null)
            {
                Order = new LegalClientSampleAnalysisServiceOrderDisplayModel();

                Order.Import(entity.Order);
            }
        }
    }
}