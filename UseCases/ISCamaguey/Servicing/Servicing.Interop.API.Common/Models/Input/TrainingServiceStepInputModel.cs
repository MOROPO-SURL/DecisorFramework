namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class TrainingServiceStepInputModel : Contract.AbstractServiceStepInputModel<Persistence.Entities.TrainingServiceStep>
    {
        public System.Guid? ParentId { get; set; }

        public override Persistence.Entities.TrainingServiceStep Export()
        {
            var entity = new Persistence.Entities.TrainingServiceStep { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.TrainingServiceStep entity)
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
