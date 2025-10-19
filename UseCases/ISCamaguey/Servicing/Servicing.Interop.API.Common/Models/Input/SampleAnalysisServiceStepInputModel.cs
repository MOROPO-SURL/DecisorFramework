namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class SampleAnalysisServiceStepInputModel : Contract.AbstractServiceStepInputModel<Persistence.Entities.SampleAnalysisServiceStep>
    {
        public System.Guid? ParentId { get; set; }

        public override Persistence.Entities.SampleAnalysisServiceStep Export()
        {
            var entity = new Persistence.Entities.SampleAnalysisServiceStep { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.SampleAnalysisServiceStep entity)
        {
            base.Mergue(entity);

            if (entity.ParentId != ParentId)
            {
                entity.Parent = null;
                entity.ParentId = ParentId;
            }
        }
    }
}
