using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public sealed class PublicationResultInputModel : IEntityInputModel<PublicationResult, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public System.Guid? ProjectId { get; set; }

        public InternalResearcherDisplayModel[] InternalResearchers { get; set; }

        public ExternalResearcherDisplayModel[] ExternalResearchers { get; set; }

        public DocumentInputModel Document { get; set; }

        public PublicationResult Export()
        {
            var entity = new PublicationResult { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public void Import(PublicationResult entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(PublicationResult entity)
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
                entity.InternalResearcherBridges.Add(new PublicationResultInternalResearcherBridge { ProwId = entity.Id, SternId = item.Id });
            }

            entity.ExternalResearcherBridges.Clear();

            foreach (var item in ExternalResearchers)
            {
                entity.ExternalResearcherBridges.Add(new PublicationResultExternalResearcherBridge { ProwId = entity.Id, SternId = item.Id });
            }
        }
    }
}