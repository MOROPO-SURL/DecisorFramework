
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractTrainingServiceOrderInputModel<TEntity> : AbstractServiceOrderInputModel<TEntity> where TEntity : Persistence.Entities.Contract.AbstractTrainingServiceOrder
    {
        public System.Guid ServiceId { get; set; }

        public override void Mergue(TEntity entity)
        {
            base.Mergue(entity);

            if (entity.TrainingServiceId != ServiceId)
            {
                entity.Service = null;
                entity.TrainingServiceId = ServiceId;
            }
        }
    }
}
