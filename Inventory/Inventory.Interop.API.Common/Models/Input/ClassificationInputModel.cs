using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input
{
    public class ClassificationInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Classification, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public System.Guid ProductId { get; set; }

        public Classification Export()
        {
            var entity = new Classification { Id = System.Guid.NewGuid(), Enabled = true, ProductId = ProductId };

            Mergue(entity);

            return entity;
        }

        public void Import(Classification entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Classification entity)
        {
            entity.Name = Name;
            entity.Priority = Priority;
            entity.Description = Description;
        }
    }
}

