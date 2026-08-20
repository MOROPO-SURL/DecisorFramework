using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class BrandInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.Brand, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public override Brand Export()
        {
            var entity = new Brand { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Brand entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
