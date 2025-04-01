namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class VehicleBrandInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Brand, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public Persistence.Entities.Brand Export()
        {
            var entity = new Persistence.Entities.Brand { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Brand entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Brand entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
