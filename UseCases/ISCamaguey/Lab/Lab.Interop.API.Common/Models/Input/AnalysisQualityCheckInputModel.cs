using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input
{
    public sealed class AnalysisQualityCheckInputModel : IEntityInputModel<AnalysisQualityCheck, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public System.Guid AnalysisId { get; set; }

        public System.Guid AuthorId { get; set; }

        [System.ComponentModel.DataAnnotations.Range(0D, 100D)]
        public double QualityPercent { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public Quality.Interop.API.Common.Models.Display.CubanStandardDisplayModel[] CubanStandards { get; set; }

        public Quality.Interop.API.Common.Models.Display.IsoStandardDisplayModel[] IsoStandards { get; set; }

        public AnalysisQualityCheck Export()
        {
            var entity = new AnalysisQualityCheck { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public void Import(AnalysisQualityCheck entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(AnalysisQualityCheck entity)
        {
            entity.At = At;
            entity.QualityPercent = QualityPercent;
            entity.Description = Description;

            entity.CubanStandardBridge.Clear();
            entity.CubanStandardBridge = CubanStandards.Select(model => new AnalysisQualityCheckCubanStandardBridge { ProwId = entity.Id, SternId = model.Id }).ToList();

            entity.IsoStandardBridge.Clear();
            entity.IsoStandardBridge = IsoStandards.Select(model => new AnalysisQualityCheckIsoStandardBridge { ProwId = entity.Id, SternId = model.Id }).ToList();

            if (entity.AnalysisId != AnalysisId)
            {
                entity.Analysis = null;
                entity.AnalysisId = AnalysisId;
            }

            if (entity.AuthorId != AuthorId)
            {
                entity.Author = null;
                entity.AuthorId = AuthorId;
            }
        }
    }
}
