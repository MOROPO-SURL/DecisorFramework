using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public sealed class LegalClientSampleAnalysisServiceExecutionInputModel : Contract.AbstractExecutionInputModel<LegalClientSampleAnalysisServiceExecution>
    {
        public long OrderId { get; set; }

        public override LegalClientSampleAnalysisServiceExecution Export()
        {
            var entity = new LegalClientSampleAnalysisServiceExecution { Id = Id, Archived = false, OrderId = OrderId };

            Mergue(entity);

            return entity;
        }
    }
}