using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input
{
    public class AssessmentInputModel : IEntityInputModel<Assessment, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public System.Guid WorkPlanId { get; set; }

        public System.Guid SampleId { get; set; }

        public System.Guid AuthorId { get; set; }

        public DocumentInputModel Document { get; set; }

        public Assessment Export()
        {
            var entity = new Assessment { Id = Id, Archived = false, WorkPlanId = WorkPlanId, SampleId = SampleId };

            Mergue(entity);

            return entity;
        }

        public void Import(Assessment entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Assessment entity)
        {
            entity.At = At;
            entity.Description = Description;

            if (entity.AuthorId != AuthorId)
            {
                entity.Author = null;
                entity.AuthorId = AuthorId;
            }
        }
    }
}
