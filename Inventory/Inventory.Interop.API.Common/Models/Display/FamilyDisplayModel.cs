namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display
{
	public class FamilyDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Family, int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public FamilyDisplayModel Parent { get; set; }

        public void Import(Persistence.Entities.Family entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            At = entity.At;
            Priority = entity.Priority;

            if (entity.Parent != null)
            {
                Parent = new FamilyDisplayModel();

                Parent.Import(entity.Parent);
            }
        }
    }
}

