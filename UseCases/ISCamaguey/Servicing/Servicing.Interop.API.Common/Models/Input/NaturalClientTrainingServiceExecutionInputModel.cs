using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public sealed class NaturalClientTrainingServiceExecutionInputModel : Contract.AbstractExecutionInputModel<NaturalClientTrainingServiceExecution>
    {
        public long OrderId { get; set; }

        public override NaturalClientTrainingServiceExecution Export()
        {
            var entity = new NaturalClientTrainingServiceExecution { Id = Id, Archived = false, OrderId = OrderId };

            Mergue(entity);

            return entity;
        }
    }
}