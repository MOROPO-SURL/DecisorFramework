using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public sealed class LegalClientTrainingServiceExecutionInputModel : Contract.AbstractExecutionInputModel<LegalClientTrainingServiceExecution>
    {
        public long OrderId { get; set; }

        public override LegalClientTrainingServiceExecution Export()
        {
            var entity = new LegalClientTrainingServiceExecution { Id = Id, Archived = false, OrderId = OrderId };

            Mergue(entity);

            return entity;
        }
    }
}