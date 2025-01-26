namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display
{
    public class ProductionRoleDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ProductionRole, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public virtual void Import(Persistence.Entities.ProductionRole entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Priority = entity.Priority;
            At = entity.At;
            Description = entity.Description;
        }
    }
}

