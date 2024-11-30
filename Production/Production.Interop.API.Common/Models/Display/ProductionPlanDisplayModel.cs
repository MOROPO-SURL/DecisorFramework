using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display
{
    public class ProductionPlanDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ProductionPlan, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public System.DateTime PlannedFor { get; set; }

        public System.DateTime? ApprovedAt { get; set; }

        public EmployeeDisplayModel Planner { get; set; }

        public EmployeeDisplayModel Responsible { get; set; }

        public EmployeeDisplayModel Decisor { get; set; }

        public ElaborationDisplayModel Elaboration { get; set; }

        public ProductionDisplayModel Production { get; set; }

        public virtual void Import(Persistence.Entities.ProductionPlan entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            At = entity.At;
            Amount = entity.Amount;
            Description = entity.Description;
            PlannedFor = entity.PlannedFor;
            ApprovedAt = entity.ApprovedAt;

            if (entity.Planner != null)
            {
                Planner = new EmployeeDisplayModel();

                Planner.Import(entity.Planner);
            }

            if (entity.Responsible != null)
            {
                Responsible = new EmployeeDisplayModel();

                Responsible.Import(entity.Responsible);
            }

            if (entity.Decisor != null)
            {
                Decisor = new EmployeeDisplayModel();

                Decisor.Import(entity.Decisor);
            }

            if (entity.Elaboration != null)
            {
                Elaboration = new ElaborationDisplayModel();

                Elaboration.Import(entity.Elaboration);
            }
        }
    }
}

