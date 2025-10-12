namespace MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class TechniqueInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Technique, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public Persistence.Entities.Technique Export()
        {
            var entity = new Persistence.Entities.Technique { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Technique entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Technique entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
