using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input
{
    public class PurchaseOrderInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.PurchaseOrder, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public System.DateTime PlannedFor { get; set; }

        public int Priority { get; set; }

        public System.Guid? RequestId { get; set; }

        public System.Guid AgreementId { get; set; }

        public System.Guid ResponsibleId { get; set; }

        public System.Guid ZoneId { get; set; }

        public float? AdvanceRequired { get; set; }

        public System.Guid? AdvanceRequiredCurrencyId { get; set; }

        public string Description { get; set; }

        public List<Bridge.PurchaseCommonProductBridgeModel> ResultProductBridges { get; set; } = new List<Bridge.PurchaseCommonProductBridgeModel>();

        public List<Bridge.PurchaseCommonProductBridgeModel> SpentProductBridges { get; set; } = new List<Bridge.PurchaseCommonProductBridgeModel>();

        public List<Display.LegalProviderBudgetDisplayModel> LegalProviderBudgets { get; set; } = new List<Display.LegalProviderBudgetDisplayModel>();

        public List<Display.NaturalProviderBudgetDisplayModel> NaturalProviderBudgets { get; set; } = new List<Display.NaturalProviderBudgetDisplayModel>();

        public Persistence.Entities.PurchaseOrder Export()
        {
            var entity = new Persistence.Entities.PurchaseOrder { Id = Id, Enabled = true };

            Mergue(entity);

            if (entity.RequestId != RequestId)
            {
                entity.Request = null;
                entity.RequestId = RequestId;
            }

            return entity;
        }

        public void Import(Persistence.Entities.PurchaseOrder entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.PurchaseOrder entity)
        {
            entity.PlannedFor = PlannedFor;
            entity.Priority = Priority;
            entity.Description = Description;
            entity.AdvanceRequired = AdvanceRequired;

            if (entity.AdvanceRequiredCurrencyId != AdvanceRequiredCurrencyId)
            {
                entity.AdvanceRequiredCurrency = null;
                entity.AdvanceRequiredCurrencyId = AdvanceRequiredCurrencyId;
            }

            if (entity.AgreementId != AgreementId)
            {
                entity.Agreement = null;
                entity.AgreementId = AgreementId;
            }

            if (entity.ResponsibleId != ResponsibleId)
            {
                entity.Responsible = null;
                entity.ResponsibleId = ResponsibleId;
            }

            if (entity.ZoneId != ZoneId)
            {
                entity.Zone = null;
                entity.ZoneId = ZoneId;
            }
        }
    }
}
