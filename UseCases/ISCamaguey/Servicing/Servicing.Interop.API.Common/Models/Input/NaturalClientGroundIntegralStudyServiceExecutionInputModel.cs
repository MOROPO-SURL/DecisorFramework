using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public sealed class NaturalClientGroundIntegralStudyServiceExecutionInputModel : Contract.AbstractExecutionInputModel<NaturalClientGroundIntegralStudyServiceExecution>
    {
        public long OrderId { get; set; }

        public override NaturalClientGroundIntegralStudyServiceExecution Export()
        {
            var entity = new NaturalClientGroundIntegralStudyServiceExecution { Id = Id, Archived = false, OrderId = OrderId };

            Mergue(entity);

            return entity;
        }
    }
}
