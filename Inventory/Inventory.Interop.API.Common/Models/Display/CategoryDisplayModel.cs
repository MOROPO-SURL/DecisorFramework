namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display
{
	public class CategoryDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Category, int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public CategoryDisplayModel Parent { get; set; }

        public void Import(Persistence.Entities.Category entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            At = entity.At;
            Priority = entity.Priority;

            if (entity.Parent != null)
            {
                Parent = new CategoryDisplayModel();

                Parent.Import(entity.Parent);
            }
        }

        public override int GetHashCode()
        {
            var self = Id * 100 + Priority;

            if (Parent != null) return Parent.GetHashCode() * 100 + self;

            return self;
        }
    }
}

