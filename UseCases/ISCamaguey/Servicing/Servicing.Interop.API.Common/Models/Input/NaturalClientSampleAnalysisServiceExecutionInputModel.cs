using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public sealed class NaturalClientSampleAnalysisServiceExecutionInputModel : Contract.AbstractExecutionInputModel<NaturalClientSampleAnalysisServiceExecution>
    {
        public long OrderId { get; set; }

        public override NaturalClientSampleAnalysisServiceExecution Export()
        {
            var entity = new NaturalClientSampleAnalysisServiceExecution { Id = Id, Archived = false, OrderId = OrderId };

            Mergue(entity);

            return entity;
        }
    }
}