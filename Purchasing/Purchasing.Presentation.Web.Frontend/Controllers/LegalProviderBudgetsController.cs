using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Frontend.Controllers
{
    [Route("api/fwrk/purchasing/[controller]")]
    [ApiController]
    public class LegalProviderBudgetsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<LegalProviderBudget, System.Guid, LegalProviderBudgetInputModel, LegalProviderBudgetDisplayModel, LegalProviderBudgetFilterModel>
    {
        public LegalProviderBudgetsController(Guama.Core.Persistence.Repositories.IEntityRepository<LegalProviderBudget, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalProviderBudgetsController> localizer, Microsoft.Extensions.Logging.ILogger<LegalProviderBudgetsController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<LegalProviderBudget, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<LegalProviderBudget, object> GetOrderSelector()
        {
            return entity => entity.Year * 1000 + entity.Number;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override LegalProviderBudgetDisplayModel EntityToDisplayModel(LegalProviderBudget entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Provider.Contact.Identity.Image != null)
            {
                model.Provider.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Provider.Contact.Identity.Image.ContentType);
            }

            if (entity.Commercial.Contact.Identity.Image != null)
            {
                model.Commercial.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Commercial.Contact.Identity.Image.ContentType);
            }

            foreach (var bridge in entity.ProductBridges)
            {
                var _model = new CommonBugetProductBridgeModel
                {
                    Product = new Inventory.Interop.API.Common.Models.Display.ProductDisplayModel(),
                    Amount = bridge.Amount,
                    UnitMeasurement = new Domain.Interop.API.Common.Models.Display.UnitMeasurementDisplayModel(),
                    UnitPrice = bridge.UnitPrice,
                    Currency = new Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel()
                };

                _model.Product.Import(bridge.Stern);
                _model.UnitMeasurement.Import(bridge.UnitMeasurement);
                _model.Currency.Import(bridge.Currenty);

                if (bridge.Classification != null)
                {
                    _model.Classification = new Inventory.Interop.API.Common.Models.Display.ClassificationDisplayModel();

                    _model.Classification.Import(bridge.Classification);
                }

                if (_model.Product.FeatureImage != null)
                {
                    _model.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.FeatureImage.ContentType);
                }

                model.ProductBridges.Add(_model);
            }

            return model;
        }

        protected override void PreCreate(LegalProviderBudget entity, LegalProviderBudgetInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.ProductBridges != null)
            {
                foreach (var item in model.ProductBridges)
                {
                    entity.ProductBridges.Add(new LegalProviderBudgetProductBridge 
                    { 
                        ProwId = entity.Id, 
                        SternId = item.Product.Id,
                        Amount = item.Amount,
                        UnitMeasurementId = item.UnitMeasurement.Id,
                        UnitPrice = item.UnitPrice,
                        CurrentyId = item.Currency.Id,
                        ClassificationId = item.Classification?.Id ?? null
                    });
                }
            }
        }

        protected override void PreEdit(LegalProviderBudget entity, LegalProviderBudgetInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.ProductBridges != null)
            {
                entity.ProductBridges.Clear();

                foreach (var item in model.ProductBridges)
                {
                    entity.ProductBridges.Add(new LegalProviderBudgetProductBridge 
                    {
                        ProwId = entity.Id,
                        SternId = item.Product.Id,
                        Amount = item.Amount,
                        UnitMeasurementId = item.UnitMeasurement.Id,
                        UnitPrice = item.UnitPrice,
                        CurrentyId = item.Currency.Id,
                        ClassificationId = item.Classification?.Id ?? null
                    });
                }
            }
        }
    }
}
