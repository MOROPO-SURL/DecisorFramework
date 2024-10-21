using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class PurchasesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementFilteredController<Purchase, System.Guid, PurchaseInputModel, PurchaseDisplayModel, PurchaseFilterModel>
    {
        public PurchasesController(IEntityRepository<Purchase, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PurchasesController> localizer, Microsoft.Extensions.Logging.ILogger<PurchasesController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<Purchase, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override PurchaseDisplayModel EntityToDisplayModel(Purchase entity)
        {
            var model = base.EntityToDisplayModel(entity);

            foreach (var item in model.LegalProviderProductBridges)
            {
                if (item.Product.FeatureImage != null)
                {
                    item.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.LegalProviderProductBridges.First(bridge => bridge.SternId == item.Product.Id).Stern.FeatureImage.ContentType);
                }

                if (item.Provider.Image != null)
                {
                    item.Provider.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.LegalProviderProductBridges.First(bridge => bridge.ProviderId == item.Provider.Id).Stern.FeatureImage.ContentType);
                }
            }

            foreach (var item in model.NaturalProviderProductBridges)
            {
                if (item.Product.FeatureImage != null)
                {
                    item.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.NaturalProviderProductBridges.First(bridge => bridge.SternId == item.Product.Id).Stern.FeatureImage.ContentType);
                }

                if (item.Provider.Image != null)
                {
                    item.Provider.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.NaturalProviderProductBridges.First(bridge => bridge.ProviderId == item.Provider.Id).Stern.FeatureImage.ContentType);
                }
            }

            foreach (var item in model.EmployeeBridges)
            {
                if (item.Employee.Image != null)
                {
                    item.Employee.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.EmployeeBridges.First(bridge => bridge.SternId == item.Employee.Id).Stern.Identity.Image.ContentType);
                }
            }

            foreach (var item in model.ColaboratorBridges)
            {
                if (item.Colaborator.Image != null)
                {
                    item.Colaborator.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.EmployeeBridges.First(bridge => bridge.SternId == item.Colaborator.Id).Stern.Identity.Image.ContentType);
                }
            }

            return model;
        }

        protected override void PreCreate(Purchase entity, PurchaseInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.LegalProviderProductBridges != null)
            {
                foreach (var item in model.LegalProviderProductBridges)
                {
                    entity.LegalProviderProductBridges.Add(new PurchaseProductLegalProviderBridge 
                    { 
                        ProwId = entity.Id, 
                        SternId = item.Product.Id, 
                        ProviderId = item.Provider.Id, 
                        UnitMeasurementId = item.UnitMeasurement.Id,
                        Amount = item.Amount,
                        Cost = item.Cost
                    });
                }
            }

            if (model.NaturalProviderProductBridges != null)
            {
                foreach (var item in model.NaturalProviderProductBridges)
                {
                    entity.NaturalProviderProductBridges.Add(new PurchaseProductNaturalProviderBridge
                    {
                        ProwId = entity.Id,
                        SternId = item.Product.Id,
                        ProviderId = item.Provider.Id,
                        UnitMeasurementId = item.UnitMeasurement.Id,
                        Amount = item.Amount,
                        Cost = item.Cost,
                        CostCenterId = item.CostCenter.Id
                    });
                }
            }

            if (model.EmployeeBridges != null)
            {
                foreach (var item in model.EmployeeBridges)
                {
                    entity.EmployeeBridges.Add(new PurchaseEmployeeBridge { ProwId = entity.Id, SternId = item.Employee.Id, Role = item.Role });
                }
            }

            if (model.ColaboratorBridges != null)
            {
                foreach (var item in model.ColaboratorBridges)
                {
                    entity.ColaboratorBridges.Add(new PurchaseColaboratorBridge { ProwId = entity.Id, SternId = item.Colaborator.Id, Role = item.Role });
                }
            }

            if (model.SpentBridges != null)
            {
                foreach (var item in model.SpentBridges)
                {
                    entity.SpentBridges.Add(new PurchasePurchaseSpentBridge 
                    { 
                        ProwId = entity.Id, 
                        SternId = item.Spent.Id, 
                        Amount = item.Amount, 
                        Cost = item.Cost, 
                        CostCenterId = item.CostCenter.Id 
                    });
                }
            }
        }

        protected override void PostCreate(Purchase entity, PurchaseInputModel model)
        {
            base.PostCreate(entity, model);
        }

        protected override void PreEdit(Purchase entity, PurchaseInputModel model)
        {
            //base.PreEdit(entity, model);

            //if (model.LegalProviderProductBridges != null)
            //{
            //    entity.LegalProviderProductBridges.Clear();

            //    foreach (var item in model.LegalProviderProductBridges)
            //    {
            //        entity.LegalProviderProductBridges.Add(new LegalProviderPurchaseProductBridge
            //        {
            //            ProwId = entity.Id,
            //            SternId = item.Product.Id,
            //            ProviderId = item.Provider.Id,
            //            UnitMeasurementId = item.UnitMeasurement.Id,
            //            Amount = item.Amount,
            //            Cost = item.Cost,
            //            IsContextual = item.IsContextual
            //        });
            //    }
            //}

            //if (model.NaturalProviderProductBridges != null)
            //{
            //    entity.NaturalProviderProductBridges.Clear();

            //    foreach (var item in model.NaturalProviderProductBridges)
            //    {
            //        entity.NaturalProviderProductBridges.Add(new NaturalProviderPurchaseProductBridge
            //        {
            //            ProwId = entity.Id,
            //            SternId = item.Product.Id,
            //            ProviderId = item.Provider.Id,
            //            UnitMeasurementId = item.UnitMeasurement.Id,
            //            Amount = item.Amount,
            //            Cost = item.Cost,
            //            IsContextual = item.IsContextual
            //        });
            //    }
            //}

            //if (model.EmployeeBridges != null)
            //{
            //    entity.EmployeeBridges.Clear();

            //    foreach (var item in model.EmployeeBridges)
            //    {
            //        entity.EmployeeBridges.Add(new PurchaseEmployeeBridge { ProwId = entity.Id, SternId = item.Employee.Id, Role = item.Role });
            //    }
            //}

            //if (model.ColaboratorBridges != null)
            //{
            //    entity.ColaboratorBridges.Clear();

            //    foreach (var item in model.ColaboratorBridges)
            //    {
            //        entity.ColaboratorBridges.Add(new PurchaseColaboratorBridge { ProwId = entity.Id, SternId = item.Colaborator.Id, Role = item.Role });
            //    }
            //}

            //if (model.SpentBridges != null)
            //{
            //    entity.SpentBridges.Clear();

            //    foreach (var item in model.SpentBridges)
            //    {
            //        entity.SpentBridges.Add(new PurchasePurchaseSpentBridge
            //        {
            //            ProwId = entity.Id,
            //            SternId = item.Spent.Id,
            //            Amount = item.Amount,
            //            Cost = item.Cost,
            //            IsContextual = item.IsContextual
            //        });
            //    }
            //}

            throw new System.InvalidOperationException();
        }
    }
}
