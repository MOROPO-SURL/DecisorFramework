namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class VehicleCategoryDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.VehicleCategory, int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public VehicleCategoryDisplayModel Parent { get; set; }

        public void Import(Persistence.Entities.VehicleCategory entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            At = entity.At;
            Priority = entity.Priority;

            if (entity.Parent != null)
            {
                Parent = new VehicleCategoryDisplayModel();

                Parent.Import(entity.Parent);
            }
        }
    }
}
