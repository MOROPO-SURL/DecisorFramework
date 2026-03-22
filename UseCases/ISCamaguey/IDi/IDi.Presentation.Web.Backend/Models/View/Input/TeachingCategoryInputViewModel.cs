namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Input
{
    public class TeachingCategoryInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.TeachingCategory, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        public bool Enabled { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Persistence.Entities.TeachingCategory Export()
        {
            var entity = new Persistence.Entities.TeachingCategory();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.TeachingCategory entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(Persistence.Entities.TeachingCategory entity)
        {
            entity.Name = Name;
            entity.Enabled = Enabled;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
