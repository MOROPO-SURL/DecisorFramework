using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class WorkforceOrganizationalUnitInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.WorkforceOrganizationalUnit, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid OrganizationalStructuringUnitId { get; set; }

        public VacantInputModel ChiefVacant { get; set; }

        public List<VacantInputModel> EditionVacants { get; set; } = new List<VacantInputModel>();

        public List<VacantInputModel> IncomingVacants { get; set; } = new List<VacantInputModel>();

        public List<VacantDisplayModel> OutgoingVacants { get; set; } = new List<VacantDisplayModel>();

        public Persistence.Entities.WorkforceOrganizationalUnit Export()
        {
            var entity = new Persistence.Entities.WorkforceOrganizationalUnit { Id = Id, OrganizationalStructuringUnitId = OrganizationalStructuringUnitId };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.WorkforceOrganizationalUnit entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.WorkforceOrganizationalUnit entity)
        {
        }
    }
}
