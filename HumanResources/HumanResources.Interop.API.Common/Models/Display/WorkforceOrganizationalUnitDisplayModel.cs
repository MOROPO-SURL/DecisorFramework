namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class WorkforceOrganizationalUnitDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.WorkforceOrganizationalUnit, System.Guid>
    {
        public System.Guid Id { get; set; }

        public Domain.Interop.API.Common.Models.Display.OrganizationalStructuringUnitDisplayModel OrganizationalStructuringUnit { get; set; }

        public VacantDisplayModel ChiefVacant { get; set; }

        public VacantDisplayModel[] Vacants { get; set; }

        public WorkforceOrganizationalUnitDisplayModel[] Children { get; set; }

        public void Import(Persistence.Entities.WorkforceOrganizationalUnit entity)
        {
            Id = entity.Id;

            if (entity.OrganizationalStructuringUnit != null)
            {
                OrganizationalStructuringUnit = new Domain.Interop.API.Common.Models.Display.OrganizationalStructuringUnitDisplayModel();

                OrganizationalStructuringUnit.Import(entity.OrganizationalStructuringUnit);
            }

            if (entity.ChiefVacant != null)
            {
                ChiefVacant = new VacantDisplayModel();

                ChiefVacant.Import(entity.ChiefVacant);
            }
        }
    }
}
