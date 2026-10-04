using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input
{
    public sealed class AssessmentQualityCheckInputModel : Framework.Decisor.Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<AssessmentQualityCheck, System.Guid>
    {
        public System.DateTime At { get; set; }

        public System.Guid AssessmentId { get; set; }

        public System.Guid AuthorId { get; set; }

        [System.ComponentModel.DataAnnotations.Range(0D, 100D)]
        public double QualityPercent { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel[] CubanStandards { get; set; }

        public Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel[] IsoStandards { get; set; }

        public override AssessmentQualityCheck Export()
        {
            var entity = new AssessmentQualityCheck { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(AssessmentQualityCheck entity)
        {
            entity.At = At;
            entity.QualityPercent = QualityPercent;
            entity.Description = Description;

            entity.CubanStandardBridge.Clear();
            entity.CubanStandardBridge = CubanStandards.Select(model => new AssessmentQualityCheckCubanStandardBridge { ProwId = entity.Id, SternId = model.Id }).ToList();

            entity.IsoStandardBridge.Clear();
            entity.IsoStandardBridge = IsoStandards.Select(model => new AssessmentQualityCheckIsoStandardBridge { ProwId = entity.Id, SternId = model.Id }).ToList();

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