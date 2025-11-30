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

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get; set; }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Responsible { get; set; }

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

            if (entity.Agreement != null)
            {
                Agreement = new Governance.Interop.API.Common.Models.Display.AgreementDisplayModel();

                Agreement.Import(entity.Agreement);
            }

            if (entity.Responsible != null)
            {
                Responsible = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                Responsible.Import(entity.Responsible);
            }

            if (entity.Elaboration != null)
            {
                Elaboration = new ElaborationDisplayModel();

                Elaboration.Import(entity.Elaboration);
            }
        }
    }
}

