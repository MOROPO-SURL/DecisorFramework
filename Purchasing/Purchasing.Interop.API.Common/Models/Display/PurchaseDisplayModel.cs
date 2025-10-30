using System.Collections.Generic;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display
{
    public class PurchaseDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Purchase, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public PurchaseOrderDisplayModel Order { get; set; }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Purchaser { get; set; }

        public string Description { get; set; }

        public List<PurchaseProductLegalProviderBridgeModel> LegalProviderProductBridges { get; set; } = new List<PurchaseProductLegalProviderBridgeModel>();

        public List<PurchaseProductNaturalProviderBridgeModel> NaturalProviderProductBridges { get; set; } = new List<PurchaseProductNaturalProviderBridgeModel>();

        public List<PurchasePurchaseSpentBridgeModel> RegularSpentBridges { get; set; } = new List<PurchasePurchaseSpentBridgeModel>();

        public List<PurchasePurchaseSpentBridgeModel> ExtraSpentBridges { get; set; } = new List<PurchasePurchaseSpentBridgeModel>();

        public List<PurchaseEmployeeBridgeModel> EmployeeBridges { get; set; } = new List<PurchaseEmployeeBridgeModel>();

        public List<PurchaseColaboratorBridgeModel> ColaboratorBridges { get; set; } = new List<PurchaseColaboratorBridgeModel>();

        public System.Guid? ReceptionId { get; set; }

        public System.DateTime? ReceptionAt { get; set; }

        public void Import(Persistence.Entities.Purchase entity)
        {
            Id = entity.Id;
            At = entity.At;
            Description = entity.Description;

            if (entity.Order != null)
            {
                Order = new PurchaseOrderDisplayModel();

                Order.Import(entity.Order);
            }

            if (entity.Purchaser != null)
            {
                Purchaser = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();
                Purchaser.Import(entity.Purchaser);
            }

            if (entity.Reception != null)
            {
                ReceptionId = entity.Reception.Id;
                ReceptionAt = entity.Reception.At;
            }

            foreach (var bridge in entity.LegalProviderProductBridges)
            {
                var model = new PurchaseProductLegalProviderBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    Provider = new Commercial.Interop.API.Common.Models.Display.LegalProviderDisplayModel(),
                    CostCenter = new Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel(),
                    Amount = bridge.Amount,
                    UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel(),
                    Cost = bridge.Cost
                };

                model.Product.Import(bridge.Product);
                model.Provider.Import(bridge.Provider);
                model.CostCenter.Import(bridge.CostCenter);
                model.UnitMeasurement.Import(bridge.UnitMeasurement);

                LegalProviderProductBridges.Add(model);
            }

            foreach (var bridge in entity.NaturalProviderProductBridges)
            {
                var model = new PurchaseProductNaturalProviderBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    Provider = new Commercial.Interop.API.Common.Models.Display.NaturalProviderDisplayModel(),
                    CostCenter = new Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel(),
                    Amount = bridge.Amount,
                    UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel(),
                    Cost = bridge.Cost
                };

                model.Product.Import(bridge.Product);
                model.Provider.Import(bridge.Provider);
                model.CostCenter.Import(bridge.CostCenter);
                model.UnitMeasurement.Import(bridge.UnitMeasurement);

                NaturalProviderProductBridges.Add(model);
            }

            foreach (var bridge in entity.SpentBridges)
            {
                var model = new PurchasePurchaseSpentBridgeModel
                {
                    Spent = new PurchaseSpentDisplayModel(),
                    Amount = bridge.Amount,
                    Count = bridge.Count
                };

                if (bridge.CostCenter != null)
                {
                    model.CostCenter = new Financial.Interop.API.Common.Models.Display.CostCenterDisplayModel();

                    model.CostCenter.Import(bridge.CostCenter);
                }

                model.Spent.Import(bridge.Stern);

                if (bridge.IsRegular)
                    RegularSpentBridges.Add(model);
                else
                    ExtraSpentBridges.Add(model);
            }

            foreach (var bridge in entity.EmployeeBridges)
            {
                var model = new PurchaseEmployeeBridgeModel
                {
                    Employee = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel(),
                    Role = bridge.Role
                };

                model.Employee.Import(bridge.Stern);

                EmployeeBridges.Add(model);
            }

            foreach (var bridge in entity.ColaboratorBridges)
            {
                var model = new PurchaseColaboratorBridgeModel
                {
                    Colaborator = new Domain.Interop.API.Common.Models.Display.ColaboratorDisplayModel(),
                    Role = bridge.Role
                };

                model.Colaborator.Import(bridge.Stern);

                ColaboratorBridges.Add(model);
            }
        }
    }
}
