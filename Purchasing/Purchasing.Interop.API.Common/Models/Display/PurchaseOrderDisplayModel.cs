using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display
{
    public class PurchaseOrderDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PurchaseOrder, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public System.DateTime At { get; set; }

        public System.DateTime PlannedFor { get; set; }

        public int Priority { get; set; }

        public PurchaseRequestDisplayModel Request { get; set; }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get; set; }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Responsible { get; set; }

        public PurchaseZoneDisplayModel Zone { get; set; }

        public float? AdvanceRequired { get; set; }

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel AdvanceRequiredCurrency { get; set; }

        public string Description { get; set; }

        public List<PurchaseOrderExpectedProductResultDisplayModel> ExpectedProductResults { get; set; } = new List<PurchaseOrderExpectedProductResultDisplayModel>();

        public List<PurchaseOrderPlannedProductSpentDisplayModel> PlannedProductSpents { get; set; } = new List<PurchaseOrderPlannedProductSpentDisplayModel>();

        public List<LegalProviderBudgetDisplayModel> LegalProviderBudgets { get; set; } = new List<LegalProviderBudgetDisplayModel>();

        public List<NaturalProviderBudgetDisplayModel> NaturalProviderBudgets { get; set; } = new List<NaturalProviderBudgetDisplayModel>();

        public void Import(Persistence.Entities.PurchaseOrder entity)
        {
            Id = entity.Id;
            At = entity.At;
            Enabled = entity.Enabled;
            PlannedFor = entity.PlannedFor;
            Priority = entity.Priority;
            AdvanceRequired = entity.AdvanceRequired;
            Description = entity.Description;

            if (entity.Request != null)
            {
                Request = new PurchaseRequestDisplayModel();

                Request.Import(entity.Request);
            }

            if (entity.Zone != null)
            {
                Zone = new PurchaseZoneDisplayModel();

                Zone.Import(entity.Zone);
            }

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

            if (entity.AdvanceRequiredCurrency != null)
            {
                AdvanceRequiredCurrency = new Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel();

                AdvanceRequiredCurrency.Import(entity.AdvanceRequiredCurrency);
            }
        }
    }
}
