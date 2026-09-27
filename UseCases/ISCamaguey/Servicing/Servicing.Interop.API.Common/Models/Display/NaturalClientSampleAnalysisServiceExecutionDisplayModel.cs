namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public sealed class NaturalClientSampleAnalysisServiceExecutionDisplayModel : Contract.AbstractExecutionDisplayModel<Persistence.Entities.NaturalClientSampleAnalysisServiceExecution>
    {
        public NaturalClientSampleAnalysisServiceOrderDisplayModel Order { get; set; }

        public override void Import(Persistence.Entities.NaturalClientSampleAnalysisServiceExecution entity)
        {
            base.Import(entity);

            if (entity.Order != null)
            {
                Order = new NaturalClientSampleAnalysisServiceOrderDisplayModel();

                Order.Import(entity.Order);
            }
        }
    }
}
