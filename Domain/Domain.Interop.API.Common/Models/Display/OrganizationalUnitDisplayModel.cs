namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class OrganizationalUnitDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.OrganizationalUnit, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public void Import(Persistence.Entities.OrganizationalUnit entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Name = entity.Name;
            Description = entity.Description;
        }
    }
}
