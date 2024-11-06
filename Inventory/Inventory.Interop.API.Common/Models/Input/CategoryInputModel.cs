using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input
{
	public class CategoryInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Category, int>
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public Category Export()
        {
            var entity = new Category { Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Category entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Category entity)
        {
            entity.Name = Name;
            entity.Priority = Priority;
            entity.Description = Description;

            if (entity.ParentId != ParentId)
            {
                entity.Parent = null;
                entity.ParentId = ParentId;
            }
        }
    }
}

