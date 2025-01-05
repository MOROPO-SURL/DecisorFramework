using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/purchasing/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class PurchasePlansController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<PurchasePlan, System.Guid, PurchasePlanInputModel, PurchasePlanDisplayModel, PurchasePlanFilterModel>
    {
        public PurchasePlansController(IEntityRepository<PurchasePlan, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PurchasePlansController> localizer, ILogger<PurchasePlansController> logger) : base(repository, localizer, logger)
        {
        }

        protected override System.Linq.Expressions.Expression<System.Func<PurchasePlan, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<PurchasePlan, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override PurchasePlanDisplayModel EntityToDisplayModel(PurchasePlan entity)
        {
            var model = base.EntityToDisplayModel(entity);

            foreach (var item in model.InputProductBridges)
            {
                if (item.Product.FeatureImage != null)
                {
                    item.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.InputProductBridges.First(bridge => bridge.SternId == item.Product.Id).Stern.FeatureImage.ContentType);
                }
            }

            foreach (var item in model.OutputProductBridges)
            {
                if (item.Product.FeatureImage != null)
                {
                    item.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.OutputProductBridges.First(bridge => bridge.SternId == item.Product.Id).Stern.FeatureImage.ContentType);
                }
            }

            return model;
        }

        protected override void PreCreate(PurchasePlan entity, PurchasePlanInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.LegalProviderBridges != null)
            {
                foreach (var item in model.LegalProviderBridges)
                {
                    entity.LegalProviderBridges.Add(new PurchasePlanLegalProviderBridge { ProwId = entity.Id, SternId = item.Provider.Id, Debt = item.Debt });
                }
            }

            if (model.NaturalProviderBridges != null)
            {
                foreach (var item in model.NaturalProviderBridges)
                {
                    entity.NaturalProviderBridges.Add(new PurchasePlanNaturalProviderBridge { ProwId = entity.Id, SternId = item.Provider.Id, Debt = item.Debt });
                }
            }

            if (model.InputProductBridges != null)
            {
                foreach (var item in model.InputProductBridges)
                {
                    entity.InputProductBridges.Add(new PurchasePlanInputProductBridge { ProwId = entity.Id, SternId = item.Product.Id, UnitMeasurementId = item.UnitMeasurement.Id, Amount = item.Amount });
                }
            }

            if (model.OutputProductBridges != null)
            {
                foreach (var item in model.OutputProductBridges)
                {
                    entity.OutputProductBridges.Add(new PurchasePlanOutputProductBridge { ProwId = entity.Id, SternId = item.Product.Id, UnitMeasurementId = item.UnitMeasurement.Id, Amount = item.Amount });
                }
            }
        }

        protected override void PreEdit(PurchasePlan entity, PurchasePlanInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.LegalProviderBridges != null)
            {
                entity.LegalProviderBridges.Clear();

                foreach (var item in model.LegalProviderBridges)
                {
                    entity.LegalProviderBridges.Add(new PurchasePlanLegalProviderBridge { ProwId = entity.Id, SternId = item.Provider.Id, Debt = item.Debt });
                }
            }

            if (model.NaturalProviderBridges != null)
            {
                entity.NaturalProviderBridges.Clear();

                foreach (var item in model.NaturalProviderBridges)
                {
                    entity.NaturalProviderBridges.Add(new PurchasePlanNaturalProviderBridge { ProwId = entity.Id, SternId = item.Provider.Id, Debt = item.Debt });
                }
            }

            if (model.InputProductBridges != null)
            {
                entity.InputProductBridges.Clear();

                foreach (var item in model.InputProductBridges)
                {
                    entity.InputProductBridges.Add(new PurchasePlanInputProductBridge { ProwId = entity.Id, SternId = item.Product.Id, UnitMeasurementId = item.UnitMeasurement.Id, Amount = item.Amount });
                }
            }

            if (model.OutputProductBridges != null)
            {
                entity.OutputProductBridges.Clear();

                foreach (var item in model.OutputProductBridges)
                {
                    entity.OutputProductBridges.Add(new PurchasePlanOutputProductBridge { ProwId = entity.Id, SternId = item.Product.Id, UnitMeasurementId = item.UnitMeasurement.Id, Amount = item.Amount });
                }
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpPut("approve/{key}")]
        public Microsoft.AspNetCore.Mvc.ActionResult Approve(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                entity.ApprovedAt = System.DateTime.Now;

                Repository.Update(entity, User.Identity.Name);

                return Ok();
            }
            catch (System.InvalidOperationException e)
            {
                logger.LogError(e.InnerException, e.Message);

                return NoContent();
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);

                return Conflict();
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpPut("invalidate/{key}")]
        public virtual Microsoft.AspNetCore.Mvc.ActionResult Invalidate(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                entity.ApprovedAt = null;

                Repository.Update(entity, User.Identity.Name);

                return Ok();
            }
            catch (System.InvalidOperationException e)
            {
                logger.LogError(e.InnerException, e.Message);

                return NoContent();
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);

                return Conflict();
            }
        }
    }
}
