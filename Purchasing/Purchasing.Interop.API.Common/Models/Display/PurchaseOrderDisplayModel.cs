using System.Collections.Generic;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;

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

        public List<PurchaseCommonProductBridgeModel> ResultProductBridges { get; set; } = new List<PurchaseCommonProductBridgeModel>();

        public List<PurchaseCommonProductBridgeModel> SpentProductBridges { get; set; } = new List<PurchaseCommonProductBridgeModel>();

        public List<PurchaseOrderLegalProviderBridgeModel> LegalProviderBridges { get; set; } = new List<PurchaseOrderLegalProviderBridgeModel>();

        public List<PurchaseOrderNaturalProviderBridgeModel> NaturalProviderBridges { get; set; } = new List<PurchaseOrderNaturalProviderBridgeModel>();

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

            foreach (var bridge in entity.ResultProductBridges)
            {
                var model = new PurchaseCommonProductBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel(),
                    Amount = bridge.Amount
                };

                model.Product.Import(bridge.Stern);
                model.UnitMeasurement.Import(bridge.UnitMeasurement);

                ResultProductBridges.Add(model);
            }

            foreach (var bridge in entity.SpentProductBridges)
            {
                var model = new PurchaseCommonProductBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel(),
                    Amount = bridge.Amount
                };

                model.Product.Import(bridge.Stern);
                model.UnitMeasurement.Import(bridge.UnitMeasurement);

                SpentProductBridges.Add(model);
            }

            foreach (var bridge in entity.LegalProviderBridges)
            {
                var model = new PurchaseOrderLegalProviderBridgeModel
                {
                    Provider = new Commercial.Interop.API.Common.Models.Display.LegalProviderDisplayModel(),
                    Debt = bridge.Debt
                };

                model.Provider.Import(bridge.Stern);

                LegalProviderBridges.Add(model);
            }

            foreach (var bridge in entity.NaturalProviderBridges)
            {
                var model = new PurchaseOrderNaturalProviderBridgeModel
                {
                    Provider = new Commercial.Interop.API.Common.Models.Display.NaturalProviderDisplayModel(),
                    Debt = bridge.Debt
                };

                model.Provider.Import(bridge.Stern);

                NaturalProviderBridges.Add(model);
            }
        }
    }
}
