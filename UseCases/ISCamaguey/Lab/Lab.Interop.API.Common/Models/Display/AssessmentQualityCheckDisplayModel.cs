using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display
{
    public sealed class AssessmentQualityCheckDisplayModel : IEntityDisplayModel<AssessmentQualityCheck, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public AssessmentDisplayModel Assessment { get; set; }

        public EmployeeDisplayModel Author { get; set; }

        public double QualityPercent { get; set; }

        public string Description { get; set; }

        public void Import(AssessmentQualityCheck entity)
        {
            Id = entity.Id;
            At = entity.At;
            QualityPercent = entity.QualityPercent;
            Description = entity.Description;
            
            if (entity.Assessment != null)
            {
                Assessment = new AssessmentDisplayModel();

                Assessment.Import(entity.Assessment);
            }

            if (entity.Author != null)
            {
                Author = new EmployeeDisplayModel();

                Author.Import(entity.Author);
            }
        }
    }
}