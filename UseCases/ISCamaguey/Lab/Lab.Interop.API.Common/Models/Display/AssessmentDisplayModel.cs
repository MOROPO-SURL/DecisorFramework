using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display
{
    public class AssessmentDisplayModel : IEntityDisplayModel<Assessment, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public string Description { get; set; }

        public WorkPlanDisplayModel WorkPlan { get; set; }

        public SampleOverviewModel Sample { get; set; }

        public EmployeeDisplayModel Author { get; set; }

        public DocumentDisplayModel Document { get; set; }

        public void Import(Assessment entity)
        {
            Id = entity.Id;
            At = entity.At;
            Description = entity.Description;

            if (entity.Sample != null)
            {
                Sample = new SampleOverviewModel
                {
                    Id = entity.Sample.Id,
                    Type = Enumerations.SampleType.Production,
                    Index = entity.Sample.Index,
                    Year = entity.Sample.Year,
                    Kind = new SampleKindDisplayModel(),
                    Amount = entity.Sample.Amount,
                    At = entity.Sample.At,
                    Observation = entity.Sample.Observation,
                    UnitMeasurement = new UnitMeasurementDisplayModel(),
                    PickedAt = entity.Sample.PickedAt,
                    HandledAt = entity.Sample.HandledAt,
                    AssessmentAt = entity.Sample.AssessmentAt
                };
            }

            if (entity.WorkPlan != null)
            {
                WorkPlan = new WorkPlanDisplayModel();

                WorkPlan.Import(entity.WorkPlan);
            }

            if (entity.WorkPlan != null)
            {
                WorkPlan = new WorkPlanDisplayModel();

                WorkPlan.Import(entity.WorkPlan);
            }

            if (entity.Author != null)
            {
                Author = new EmployeeDisplayModel();

                Author.Import(entity.Author);
            }

            if (entity.Document != null)
            {
                Document = new DocumentDisplayModel();

                Document.Import(entity.Document);
            }

            Sample.Kind.Import(entity.Sample.SampleKind);
            Sample.UnitMeasurement.Import(entity.Sample.UnitMeasurement);

            if (entity.Sample is ServiceOrderSample)
            {
                Sample.Type = Enumerations.SampleType.ServiceOrder;

                return;
            }

            if (entity.Sample is ResearchSample)
            {
                Sample.Type = Enumerations.SampleType.Research;

                return;
            }
        }
    }
}
