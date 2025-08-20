using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display
{
    public class ProductionOrderDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ProductionOrder, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public System.DateTime RequestedFor { get; set; }

        public System.DateTime? ApprovedAt { get; set; }

        public EmployeeDisplayModel Author { get; set; }

        public EmployeeDisplayModel Responsible { get; set; }

        public EmployeeDisplayModel Decisor { get; set; }

        public ElaborationDisplayModel Elaboration { get; set; }

        public ProductionDisplayModel Production { get; set; }

        public virtual void Import(Persistence.Entities.ProductionOrder entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            At = entity.At;
            Amount = entity.Amount;
            Description = entity.Description;
            RequestedFor = entity.RequestedFor;
            ApprovedAt = entity.ApprovedAt;

            if (entity.Author != null)
            {
                Author = new EmployeeDisplayModel();

                Author.Import(entity.Author);
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

