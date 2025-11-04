using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Frontend.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/purchasing/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class PurchaseRequestsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<PurchaseRequest, System.Guid, PurchaseRequestInputModel, PurchaseRequestDisplayModel>
    {
        private readonly IEntityRepository<PurchaseRequestExpectedProductAdquisition, System.Guid> expectedProductAdquisitionRepository;

        public PurchaseRequestsController(IEntityRepository<PurchaseRequestExpectedProductAdquisition, System.Guid> expectedProductAdquisitionRepository, IEntityRepository<PurchaseRequest, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PurchaseRequestsController> localizer, ILogger<PurchaseRequestsController> logger) : base(repository, localizer, logger)
        {
            this.expectedProductAdquisitionRepository = expectedProductAdquisitionRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<PurchaseRequest, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<PurchaseRequest, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override PurchaseRequestDisplayModel EntityToDisplayModel(PurchaseRequest entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Author.Contact.Identity.Image != null)
            {
                model.Author.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Author.Contact.Identity.Image.ContentType);
            }

            foreach (var _entity in entity.ExpectedProductAdquisitions)
            {
                var _model = new PurchaseRequestExpectedProductAdquisitionDisplayModel();

                _model.Import(_entity);

                if (_model.Product.FeatureImage != null)
                {
                    _model.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Product.FeatureImage.ContentType);
                }

                model.ExpectedProductAdquisitions.Add(_model);
            }

            return model;
        }

        protected override void PreCreate(PurchaseRequest entity, PurchaseRequestInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingExpectedProducttAdquisitions)
            {
                var _entity = _model.Export();

                _entity.RequestId = entity.Id;

                expectedProductAdquisitionRepository.Add(_entity, User.Identity.Name, false);
            }
        }

        protected override void PreEdit(PurchaseRequest entity, PurchaseRequestInputModel model)
        {
            base.PreEdit(entity, model);

            foreach (var _model in model.OutgoingExpectedProducttAdquisitions)
            {
                var _entity = expectedProductAdquisitionRepository.Get(_model.Id);

                expectedProductAdquisitionRepository.Delete(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionExpectedProducttAdquisitions)
            {
                var _entity = expectedProductAdquisitionRepository.Get(_model.Id);

                _model.Mergue(_entity);

                expectedProductAdquisitionRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingExpectedProducttAdquisitions)
            {
                var _entity = _model.Export();

                _entity.RequestId = entity.Id;

                expectedProductAdquisitionRepository.Add(_entity, User.Identity.Name, false);
            }
        }
    }
}
