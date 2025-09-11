namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class PropertySpaceInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.PropertySpace, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public Core.Interop.API.Common.Models.Input.ImageInputModel FeatureImage { get; set; }

        public decimal Area { get; set; }

        public string Description { get; set; }

        public Persistence.Entities.PropertySpace Export()
        {
            var entity = new Persistence.Entities.PropertySpace { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.PropertySpace entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.PropertySpace entity)
        {
            entity.Name = Name;
            entity.Area = Area;
            entity.Description = Description;
        }
    }
}
