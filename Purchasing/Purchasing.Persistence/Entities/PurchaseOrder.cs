using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Purchasing.Persistence.Entities
{
    public class PurchaseOrder : Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public string Description { get; set; }

        public System.DateTime PlannedFor { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RequestId))]
        public PurchaseRequest Request { get; set; }
        public System.Guid? RequestId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AgreementId))]
        public Governance.Persistence.Entities.Agreement Agreement { get; set; }
        public System.Guid AgreementId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ResponsibleId))]
        public Domain.Persistence.Entities.Employee Responsible { get; set; }
        public System.Guid ResponsibleId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ZoneId))]
        public PurchaseZone Zone { get; set; }
        public System.Guid ZoneId { get; set; }

        public float? AdvanceRequired { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AdvanceRequiredCurrencyId))]
        public Financial.Persistence.Entities.Currency AdvanceRequiredCurrency { get; set; }
        public System.Guid? AdvanceRequiredCurrencyId { get; set; }

        public PurchaseCashAdvance Advance { get; set; }

        public Purchase Purchase { get; set; }

        public List<PurchaseOrderProductResultBridge> ResultProductBridges { get; set; } = new List<PurchaseOrderProductResultBridge>();

        public List<PurchaseOrderProductSpentBridge> SpentProductBridges { get; set; } = new List<PurchaseOrderProductSpentBridge>();

        public List<PurchaseOrderLegalProviderBudgetBridge> LegalProviderBudgetBridges { get; set; } = new List<PurchaseOrderLegalProviderBudgetBridge>();

        public List<PurchaseOrderNaturalProviderBudgetBridge> NaturalProviderBudgetBridges { get; set; } = new List<PurchaseOrderNaturalProviderBudgetBridge>();
    }
}
