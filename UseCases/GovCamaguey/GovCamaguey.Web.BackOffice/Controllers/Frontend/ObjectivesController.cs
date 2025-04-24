using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input;
using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Controllers.Frontend
{
    [Route("api/governance/[controller]")]
    [ApiController]
    public class ObjectivesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<Objective, System.Guid, Interop.API.Common.Models.Input.ObjectiveInputModel, Interop.API.Common.Models.Display.ObjectiveDisplayModel>
    {
        private readonly IEntityRepository<Proyection, System.Guid> proyectionRepository;

        public ObjectivesController(IEntityRepository<Proyection, System.Guid> proyectionRepository, IEntityRepository<Objective, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ObjectivesController> localizer, Microsoft.Extensions.Logging.ILogger<ObjectivesController> logger)
            : base(repository, localizer, logger)
        {
            this.proyectionRepository = proyectionRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Objective, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Objective, object> GetOrderSelector()
        {
            return entity => entity.Index;
        }

        protected override ObjectiveDisplayModel EntityToDisplayModel(Objective entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Responsible.Identity.Image != null)
            {
                model.Responsible.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Responsible.Identity.Image.ContentType);
            }

            return model;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override void PreCreate(Objective entity, ObjectiveInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingProyections)
            {
                var _entity = _model.Export();

                _entity.ObjectiveId = entity.Id;

                proyectionRepository.Add(_entity, User.Identity.Name, false);
            }
        }

        protected override void PreEdit(Objective entity, ObjectiveInputModel model)
        {
            base.PreEdit(entity, model);

            foreach (var _model in model.OutgoingProyections)
            {
                var _entity = entity.Proyections.First(bridge => bridge.Id == _model.Id);

                _entity.Archived = true;

                proyectionRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionProyections)
            {
                var _entity = entity.Proyections.First(bridge => bridge.Id == _model.Id);

                _model.Mergue(_entity);

                proyectionRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingProyections)
            {
                var _entity = _model.Export();

                _entity.ObjectiveId = entity.Id;

                proyectionRepository.Add(_entity, User.Identity.Name, false);
            }
        }
    }
}
