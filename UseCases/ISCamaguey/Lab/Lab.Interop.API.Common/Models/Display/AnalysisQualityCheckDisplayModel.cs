using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display
{
    public sealed class AnalysisQualityCheckDisplayModel : IEntityDisplayModel<AnalysisQualityCheck, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public AnalysisDisplayModel Analysis { get; set; }

        public EmployeeDisplayModel Author { get; set; }

        public double QualityPercent { get; set; }

        public string Description { get; set; }

        public void Import(AnalysisQualityCheck entity)
        {
            Id = entity.Id;
            At = entity.At;
            QualityPercent = entity.QualityPercent;
            Description = entity.Description;
            
            if (entity.Analysis != null)
            {
                Analysis = new AnalysisDisplayModel();

                Analysis.Import(entity.Analysis);
            }

            if (entity.Author != null)
            {
                Author = new EmployeeDisplayModel();

                Author.Import(entity.Author);
            }
        }
    }
}
