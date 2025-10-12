using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/idi/[controller]")]
    [ApiController]
    public class ProgramsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<Program, System.Guid, ProgramInputModel, ProgramDisplayModel, ProgramFilterModel>
    {
        private readonly IEntityRepository<ProgramExpectResult, System.Guid> expectResultRepository;

        public ProgramsController(IEntityRepository<ProgramExpectResult, System.Guid> expectResultRepository, IEntityRepository<Program, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProgramsController> localizer, Microsoft.Extensions.Logging.ILogger<ProgramsController> logger)
            : base(repository, localizer, logger)
        {
            this.expectResultRepository = expectResultRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Program, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        protected override System.Func<Program, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override ProgramDisplayModel EntityToDisplayModel(Program entity)
        {
            var result = base.EntityToDisplayModel(entity);

            if (result.Chief.Identity.Image != null)
            {
                result.Chief.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Chief.Identity.Image.ContentType);
            }

            if (result.Manager.Identity.Image != null)
            {
                result.Manager.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Manager.Identity.Image.ContentType);
            }

            result.ExpectResults = expectResultRepository.FindBy(_entity => _entity.ProgramId == entity.Id).OrderBy(entity => entity.Index).ToArray().Select(_entity =>
            {
                var model = new ProgramExpectResultDisplayModel();

                model.Import(_entity);

                return model;
            }).ToArray();

            return result;
        }

        protected override void PreCreate(Program entity, ProgramInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingProgramExpectResults)
            {
                var _entity = _model.Export();

                _entity.ProgramId = entity.Id;

                expectResultRepository.Add(_entity, User.Identity.Name, false);
            }
        }

        protected override void PreEdit(Program entity, ProgramInputModel model)
        {
            base.PreEdit(entity, model);

            foreach (var _model in model.OutgoingProgramExpectResults)
            {
                expectResultRepository.Delete(new ProgramExpectResult { Id = _model.Id }, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionProgramExpectResults)
            {
                var _entity = _model.Export();

                _entity.ProgramId = entity.Id;

                expectResultRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingProgramExpectResults)
            {
                var _entity = _model.Export();

                _entity.ProgramId = entity.Id;

                expectResultRepository.Add(_entity, User.Identity.Name, false);
            }
        }
    }
}
