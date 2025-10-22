namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class GroundIntegralStudyServiceStepInputModel : Contract.AbstractServiceStepInputModel<Persistence.Entities.GroundIntegralStudyServiceStep>
    {
        public System.Guid? ParentId { get; set; }

        public override Persistence.Entities.GroundIntegralStudyServiceStep Export()
        {
            var entity = new Persistence.Entities.GroundIntegralStudyServiceStep { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.GroundIntegralStudyServiceStep entity)
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
