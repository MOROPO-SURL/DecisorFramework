using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public sealed class LegalClientGroundIntegralStudyServiceExecutionInputModel : Contract.AbstractExecutionInputModel<LegalClientGroundIntegralStudyServiceExecution>
    {
        public long OrderId { get; set; }

        public override LegalClientGroundIntegralStudyServiceExecution Export()
        {
            var entity = new LegalClientGroundIntegralStudyServiceExecution { Id = Id, Archived = false, OrderId = OrderId };

            Mergue(entity);

            return entity;
        }
    }
}