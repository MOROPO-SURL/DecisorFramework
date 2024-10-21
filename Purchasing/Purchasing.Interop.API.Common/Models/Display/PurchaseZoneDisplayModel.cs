namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display
{
    public class PurchaseZoneDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PurchaseZone, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public int Priority { get; set; }

        public string Description { get; set; }

        public void Import(Persistence.Entities.PurchaseZone entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            At = entity.At;
            Priority = entity.Priority;
            Description = string.IsNullOrEmpty(entity.Description) ? null : entity.Description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
