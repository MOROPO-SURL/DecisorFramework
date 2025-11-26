
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractTrainingServiceOrderDisplayModel<TEntity> : AbstractServiceOrderDisplayModel<TEntity> where TEntity : Persistence.Entities.Contract.AbstractTrainingServiceOrder
    {
        public TrainingServiceDisplayModel Service {  get; set; }

        public override void Import(TEntity entity)
        {
            base.Import(entity);

            if (entity.Service != null)
            {
                Service = new TrainingServiceDisplayModel();

                Service.Import(entity.Service);
            }
        }
    }
}
