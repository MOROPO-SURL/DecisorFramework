using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input
{
	public class FamilyInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Family, int>
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public Family Export()
        {
            var entity = new Family { Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Family entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Family entity)
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

