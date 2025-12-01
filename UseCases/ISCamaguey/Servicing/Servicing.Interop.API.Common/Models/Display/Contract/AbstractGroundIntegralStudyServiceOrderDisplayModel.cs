
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractGroundIntegralStudyServiceOrderDisplayModel<TEntity> : AbstractServiceOrderDisplayModel<TEntity> where TEntity : Persistence.Entities.Contract.AbstractGroundIntegralStudyServiceOrder
    {
        public GroundIntegralStudyServiceDisplayModel Service { get; set; }

        public override void Import(TEntity entity)
        {
            base.Import(entity);

            if (entity.Service != null)
            {
                Service = new GroundIntegralStudyServiceDisplayModel();

                Service.Import(entity.Service);
            }
        }
    }
}
