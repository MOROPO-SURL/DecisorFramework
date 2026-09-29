using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public sealed class AwardResultInputModel : IEntityInputModel<AwardResult, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public Persistence.Enumerations.AwardModality AwardModality { get; set; }

        public System.Guid AwardKindId { get; set; }

        public System.Guid ReceptorId { get; set; }

        public System.Guid? ProjectId { get; set; }

        public AwardResult Export()
        {
            var entity = new AwardResult { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public void Import(AwardResult entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(AwardResult entity)
        {
            entity.At = At;
            entity.Description = Description;
            entity.Title = Title;
            entity.AwardModality = AwardModality;

            if (entity.AwardKindId != AwardKindId)
            {
                entity.AwardKind = null;
                entity.AwardKindId = AwardKindId;
            }

            if (entity.ReceptorId != ReceptorId)
            {
                entity.Receptor = null;
                entity.ReceptorId = ReceptorId;
            }

            if (entity.ProjectId != ProjectId)
            {
                entity.Project = null;
                entity.ProjectId = ProjectId;
            }
        }
    }
}