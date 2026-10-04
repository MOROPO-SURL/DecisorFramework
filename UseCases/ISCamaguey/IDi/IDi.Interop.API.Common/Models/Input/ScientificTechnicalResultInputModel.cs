using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public sealed class ScientificTechnicalResultInputModel : Framework.Decisor.Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<ScientificTechnicalResult, System.Guid>
    {
        public string Description { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string Reference { get; set; }

        public System.Guid KindId { get; set; }

        public System.Guid? ProjectId { get; set; }

        public override ScientificTechnicalResult Export()
        {
            var entity = new ScientificTechnicalResult { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(ScientificTechnicalResult entity)
        {
            entity.At = At;
            entity.Description = Description;
            entity.Title = Title;
            entity.Reference = Reference;

            if (entity.KindId != KindId)
            {
                entity.Kind = null;
                entity.KindId = KindId;
            }

            if (entity.ProjectId != ProjectId)
            {
                entity.Project = null;
                entity.ProjectId = ProjectId;
            }
        }
    }
}