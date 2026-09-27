using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public sealed class ThesisResultInputModel : IEntityInputModel<ThesisResult, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public System.Guid? ProjectId { get; set; }

        public InternalResearcherDisplayModel[] InternalResearchers { get; set; }

        public ExternalResearcherDisplayModel[] ExternalResearchers { get; set; }

        public ThesisResult Export()
        {
            var entity = new ThesisResult { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public void Import(ThesisResult entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(ThesisResult entity)
        {
            entity.At = At;
            entity.Description = Description;
            entity.Title = Title;
            
            if (entity.ProjectId != ProjectId)
            {
                entity.Project = null;
                entity.ProjectId = ProjectId;
            }

            entity.InternalResearcherBridges.Clear();

            foreach (var item in InternalResearchers) 
            {
                entity.InternalResearcherBridges.Add(new ThesisResultInternalResearcherBridge { ProwId = entity.Id, SternId = item.Id });
            }

            entity.ExternalResearcherBridges.Clear();

            foreach (var item in ExternalResearchers)
            {
                entity.ExternalResearcherBridges.Add(new ThesisResultExternalResearcherBridge { ProwId = entity.Id, SternId = item.Id });
            }
        }
    }
}
