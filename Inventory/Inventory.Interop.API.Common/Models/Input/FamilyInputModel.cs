using MOROPO.Framework.Decisor.Inventory.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Input
{
	public class FamilyInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Family, int>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public override Family Export()
        {
            var entity = new Family { Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Family entity)
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

