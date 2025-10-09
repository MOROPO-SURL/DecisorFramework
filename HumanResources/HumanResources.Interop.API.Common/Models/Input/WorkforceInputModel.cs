using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class WorkforceInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Workforce, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public List<System.Guid> RootOrganizationalUnityIds { get; set; } = new List<System.Guid>();
        
        public List<KeyValuePair<System.Guid, VacantInputModel>> OrganizationalUnityVacants { get; set; } = new List<KeyValuePair<System.Guid, VacantInputModel>>();

        public List<WorkforceOrganizationalUnityInputModel> EditionOrganizationalUnities { get; set; } = new List<WorkforceOrganizationalUnityInputModel>();

        public List<WorkforceOrganizationalUnityInputModel> IncomingOrganizationalUnities { get; set; } = new List<WorkforceOrganizationalUnityInputModel>();

        public List<WorkforceOrganizationalUnityDisplayModel> OutgoingOrganizationalUnities { get; set; } = new List<WorkforceOrganizationalUnityDisplayModel>();

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
        }
    }
}
