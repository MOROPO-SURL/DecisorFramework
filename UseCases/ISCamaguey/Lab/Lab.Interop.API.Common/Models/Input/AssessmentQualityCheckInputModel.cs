using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input
{
    public sealed class AssessmentQualityCheckInputModel : IEntityInputModel<AssessmentQualityCheck, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public System.Guid AssessmentId { get; set; }

        public System.Guid AuthorId { get; set; }

        [System.ComponentModel.DataAnnotations.Range(0D, 100D)]
        public double QualityPercent { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public AssessmentQualityCheck Export()
        {
            var entity = new AssessmentQualityCheck { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public void Import(AssessmentQualityCheck entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(AssessmentQualityCheck entity)
        {
            entity.At = At;
            entity.QualityPercent = QualityPercent;
            entity.Description = Description;

            if (entity.AssessmentId != AssessmentId)
            {
                entity.Assessment = null;
                entity.AssessmentId = AssessmentId;
            }

            if (entity.AuthorId != AuthorId)
            {
                entity.Author = null;
                entity.AuthorId = AuthorId;
            }
        }
    }
}