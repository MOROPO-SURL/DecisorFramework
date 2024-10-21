namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display
{
    public class PurchaseSpentDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PurchaseSpent, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public void Import(Persistence.Entities.PurchaseSpent entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = string.IsNullOrEmpty(entity.Description) ? null : entity.Description;
            At = entity.At;
            Priority = entity.Priority;
        }
    }
}
