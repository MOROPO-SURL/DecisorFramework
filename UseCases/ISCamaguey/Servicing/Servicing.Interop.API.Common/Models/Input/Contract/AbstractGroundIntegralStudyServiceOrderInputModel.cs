
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractGroundIntegralStudyServiceOrderInputModel<TEntity> : AbstractServiceOrderInputModel<TEntity> where TEntity : Persistence.Entities.Contract.AbstractGroundIntegralStudyServiceOrder
    {
        public System.Guid ServiceId { get; set; }

        public override void Mergue(TEntity entity)
        {
            base.Mergue(entity);

            if (entity.GroundIntegralStudyServiceId != ServiceId)
            {
                entity.Service = null;
                entity.GroundIntegralStudyServiceId = ServiceId;
            }
        }
    }
}
