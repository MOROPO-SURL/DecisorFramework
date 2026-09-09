namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public class ProjectCategoryDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ProjectCategory, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public virtual void Import(Persistence.Entities.ProjectCategory entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Name = entity.Name;
            Description = entity.Description;
            At = entity.At;
            Priority = entity.Priority;
        }
    }
}
