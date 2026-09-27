using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public sealed class PublicationResultDisplayModel : IEntityDisplayModel<PublicationResult, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public string Title { get; set; }

        public ProjectDisplayModel Project { get; set; }

        public InternalResearcherDisplayModel[] InternalResearchers { get; set; }

        public ExternalResearcherDisplayModel[] ExternalResearchers { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel Document { get; set; }

        public void Import(PublicationResult entity)
        {
            Id = entity.Id;
            Description = entity.Description;
            At = entity.At;
            Title = entity.Title;

            if (entity.Project != null)
            {
                Project = new ProjectDisplayModel();

                Project.Import(entity.Project);
            }
        }
    }
}
