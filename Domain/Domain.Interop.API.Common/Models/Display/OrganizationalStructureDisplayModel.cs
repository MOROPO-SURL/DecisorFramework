namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class OrganizationalStructureDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.OrganizationalStructure, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public OrganizationalStructuringUnitDisplayModel RootStructuringUnit { get; set; }

        public void Import(Persistence.Entities.OrganizationalStructure entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Name = entity.Name;

            if (entity.RootStructuringUnit != null)
            {
                RootStructuringUnit = new OrganizationalStructuringUnitDisplayModel();

                RootStructuringUnit.Import(entity.RootStructuringUnit);
            }
        }
    }
}
