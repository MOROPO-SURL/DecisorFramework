namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractSampleAnalysisServiceOrderInputModel<TEntity> : AbstractServiceOrderInputModel<TEntity> where TEntity : Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder
    {
        public System.Guid ServiceId { get; set; }

        public System.Guid? RequestedTechniqueId { get; set; }

        public override void Mergue(TEntity entity)
        {
            base.Mergue(entity);

            if (entity.SampleAnalysisServiceId != ServiceId)
            {
                entity.Service = null;
                entity.SampleAnalysisServiceId = ServiceId;
            }

            if (entity.RequestedTechniqueId != RequestedTechniqueId)
            {
                entity.RequestedTechnique = null;
                entity.RequestedTechniqueId = RequestedTechniqueId;
            }
        }
    }
}
