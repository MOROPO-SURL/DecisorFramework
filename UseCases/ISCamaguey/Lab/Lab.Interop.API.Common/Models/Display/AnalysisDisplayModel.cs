using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using System.Reflection;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display
{
    public sealed class AnalysisDisplayModel : IEntityDisplayModel<Analysis, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public WorkPlanDisplayModel WorkPlan { get; set; }

        public SampleOverviewModel Sample { get; set; }

        public TechniqueDisplayModel Technique { get; set; }

        public string Description { get; set; }

        public EmployeeDisplayModel Author { get; set; }

        public void Import(Analysis entity)
        {
            Id = entity.Id;
            At = entity.At;
            Description = entity.Description;
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
            
            if (entity.Author != null)
            {
                Author = new EmployeeDisplayModel();

                Author.Import(entity.Author);
            }

            if (entity.Technique != null)
            {
                Technique = new TechniqueDisplayModel();

                Technique.Import(entity.Technique);
            }

            if (entity.WorkPlan != null)
            {
                WorkPlan = new WorkPlanDisplayModel();

                WorkPlan.Import(entity.WorkPlan);
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
