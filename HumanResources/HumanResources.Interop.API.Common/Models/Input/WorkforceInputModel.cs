using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class WorkforceInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Workforce, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public List<Domain.Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel> OrganizationalUnities { get; set; } = new List<Domain.Interop.API.Common.Models.Display.OrganizationalUnityTreeDisplayModel>();

        public List<VacantInputModel> EditionVacants { get; set; } = new List<VacantInputModel>();

        public List<VacantInputModel> IncomingVacants { get; set; } = new List<VacantInputModel>();

        public List<VacantDisplayModel> OutgoingVacants { get; set; } = new List<VacantDisplayModel>();

        public Persistence.Entities.Workforce Export()
        {
            var entity = new Persistence.Entities.Workforce { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Workforce entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Workforce entity)
        {
            entity.At = System.DateTime.Now;
            entity.Name = Name;
            entity.Priority = Priority;
            entity.OrganizationalUnityBridges = OrganizationalUnities.Select(model => new Persistence.Entities.WorkforceOrganizationalUnityBridge
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();
        }
    }
}
