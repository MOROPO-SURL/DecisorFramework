using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display
{
    public class ResearchSampleDisplayModel : Contract.AbstractSampleDisplayModel<Persistence.Entities.ResearchSample>
    {
        public ProjectDisplayModel Project { get; set; }

        public PersonContactDisplayModel ResearcherContact { get; set; }

        public override void Import(ResearchSample entity)
        {
            base.Import(entity);

            Project = new ProjectDisplayModel();
            ResearcherContact = new PersonContactDisplayModel();

            Project.Import(entity.Project);
            ResearcherContact.Import(entity.Project.InternalResearcherParticipations.FirstOrDefault(item => item.ResearcherId == entity.ResearcherId)?.Researcher.Employee.Contact ?? entity.Project.ExternalResearcherParticipations.Single(item => item.ResearcherId == entity.ResearcherId).Researcher.Contact);
        }
    }
}
