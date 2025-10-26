using System.Collections.Generic;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display
{
    public class PurchasePlanDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PurchasePlan, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public System.DateTime At { get; set; }

        public System.DateTime PlannedFor { get; set; }

        public int Priority { get; set; }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Planner { get; set; }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Responsible { get; set; }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Decisor { get; set; }

        public PurchaseZoneDisplayModel Zone { get; set; }

        public string Description { get; set; }

        public System.DateTime? ApprovedAt { get; set; }

        public decimal EstimatedAdvance { get; set; }

        public List<PurchasePlanCommonProductBridgeModel> OutputProductBridges { get; set; } = new List<PurchasePlanCommonProductBridgeModel>();

        public List<PurchasePlanCommonProductBridgeModel> InputProductBridges { get; set; } = new List<PurchasePlanCommonProductBridgeModel>();

        public List<PurchasePlanLegalProviderBridgeModel> LegalProviderBridges { get; set; } = new List<PurchasePlanLegalProviderBridgeModel>();

        public List<PurchasePlanNaturalProviderBridgeModel> NaturalProviderBridges { get; set; } = new List<PurchasePlanNaturalProviderBridgeModel>();

        public void Import(Persistence.Entities.PurchasePlan entity)
        {
            Id = entity.Id;
            At = entity.At;
            PlannedFor = entity.PlannedFor;
            ApprovedAt = entity.ApprovedAt;
            Priority = entity.Priority;
            Description = entity.Description;
            EstimatedAdvance = entity.EstimatedAdvance;

            Zone = new PurchaseZoneDisplayModel();
            Zone.Import(entity.Zone);

            Planner = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();
            Planner.Import(entity.Planner);

            Responsible = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();
            Responsible.Import(entity.Responsible);

            if (entity.Decisor != null)
            {
                Decisor = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();
                Decisor.Import(entity.Decisor);
            }

            foreach (var bridge in entity.OutputProductBridges)
            {
                var model = new PurchasePlanCommonProductBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel(),
                    Amount = bridge.Amount
                };

                model.Product.Import(bridge.Stern);
                model.UnitMeasurement.Import(bridge.UnitMeasurement);

                OutputProductBridges.Add(model);
            }

            foreach (var bridge in entity.InputProductBridges)
            {
                var model = new PurchasePlanCommonProductBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel(),
                    Amount = bridge.Amount
                };

                model.Product.Import(bridge.Stern);
                model.UnitMeasurement.Import(bridge.UnitMeasurement);

                InputProductBridges.Add(model);
            }

            foreach (var bridge in entity.LegalProviderBridges)
            {
                var model = new PurchasePlanLegalProviderBridgeModel
                {
                    Provider = new Commercial.Interop.API.Common.Models.Display.LegalProviderDisplayModel(),
                    Debt = bridge.Debt
                };

                model.Provider.Import(bridge.Stern);

                LegalProviderBridges.Add(model);
            }

            foreach (var bridge in entity.NaturalProviderBridges)
            {
                var model = new PurchasePlanNaturalProviderBridgeModel
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
