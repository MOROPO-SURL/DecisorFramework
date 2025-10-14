namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class WorkforceOrganizationalUnityDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.WorkforceOrganizationalUnity, System.Guid>
    {
        public System.Guid Id { get; set; }

        public Domain.Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel OrganizationalUnity { get; set; }

        public VacantDisplayModel ChiefVacant { get; set; }

        public VacantDisplayModel[] Vacants { get; set; }

        public WorkforceOrganizationalUnityDisplayModel[] Children { get; set; }

        public void Import(Persistence.Entities.WorkforceOrganizationalUnity entity)
        {
            Id = entity.Id;

            if (entity.OrganizationalUnity != null)
            {
                OrganizationalUnity = new Domain.Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel();

                OrganizationalUnity.Import(entity.OrganizationalUnity);
            }

            if (entity.ChiefVacant != null)
            {
                ChiefVacant = new VacantDisplayModel();

                ChiefVacant.Import(entity.ChiefVacant);
            }
        }
    }
}
