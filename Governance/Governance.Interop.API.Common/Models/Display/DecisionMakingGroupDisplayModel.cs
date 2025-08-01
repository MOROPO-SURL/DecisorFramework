namespace MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Display
{
    public class DecisionMakingGroupDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.DecisionMakingGroup, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel Structure { get; set; }

        public string Name { get; set; }

        public HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel Leader { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel[] Members { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel[] Collaborators { get; set; }

        public string CanonicalName => $"{Structure.Identity.Name}, {Name}";

        public void Import(Persistence.Entities.DecisionMakingGroup entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Name = entity.Name;
            Description = entity.Description;
            Priority = entity.Priority;

            if (entity.Structure != null)
            {
                Structure = new Domain.Interop.API.Common.Models.Display.StructureParentalDisplayModel();

                Structure.Import(entity.Structure);
            }

            if (entity.Leader != null)
            {
                Leader = new HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                Leader.Import(entity.Leader);
            }
        }
    }
}
