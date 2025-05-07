using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class BrandInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Brand, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public Brand Export()
        {
            var entity = new Brand { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Brand entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Brand entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
