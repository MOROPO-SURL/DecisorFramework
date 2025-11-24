namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractSampleAnalysisServiceOrderDisplayModel<TEntity> : AbstractServiceOrderDisplayModel<TEntity> where TEntity : Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder
    {
        public SampleAnalysisServiceDisplayModel Service { get; set; }

        public Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel RequestedTechnique { get; set; }

        public override void Import(TEntity entity)
        {
            base.Import(entity);

            if (entity.Service != null)
            {
                Service = new SampleAnalysisServiceDisplayModel();

                Service.Import(entity.Service);
            }

            if (entity.RequestedTechnique != null)
            {
                RequestedTechnique = new Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel();

                RequestedTechnique.Import(entity.RequestedTechnique);
            }
        }
    }
}
