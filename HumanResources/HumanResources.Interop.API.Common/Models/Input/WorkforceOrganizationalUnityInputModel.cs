using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class WorkforceOrganizationalUnityInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.WorkforceOrganizationalUnity, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid OrganizationalUnityId { get; set; }

        public VacantInputModel ChiefVacant { get; set; }

        public List<VacantInputModel> EditionVacants { get; set; } = new List<VacantInputModel>();

        public List<VacantInputModel> IncomingVacants { get; set; } = new List<VacantInputModel>();

        public List<VacantDisplayModel> OutgoingVacants { get; set; } = new List<VacantDisplayModel>();

        public List<WorkforceOrganizationalUnityInputModel> Children { get; set; } = new List<WorkforceOrganizationalUnityInputModel>();

        public Persistence.Entities.WorkforceOrganizationalUnity Export()
        {
            var entity = new Persistence.Entities.WorkforceOrganizationalUnity { Id = Id, OrganizationalUnityId = OrganizationalUnityId };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.WorkforceOrganizationalUnity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.WorkforceOrganizationalUnity entity)
        {
        }
    }
}
