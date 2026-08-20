namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class WorkPositionInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.WorkPosition, System.Guid>
    {
        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Reference { get; set; }

        public System.Guid KindId { get; set; }

        public Domain.Persistence.Enumerations.EducationLevel EducationLevel { get; set; }

        public string Description { get; set; }

        public override Persistence.Entities.WorkPosition Export()
        {
            var entity = new Persistence.Entities.WorkPosition { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.WorkPosition entity)
        {
            entity.Name = Name;
            entity.Reference = Reference;
            entity.EducationLevel = EducationLevel;
            entity.Description = Description;
            entity.Priority = Priority;

            if (entity.KindId != KindId)
            {
                entity.Kind = null;
                entity.KindId = KindId;
            }
        }
    }
}
