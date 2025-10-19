using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/servicing/[controller]")]
    [ApiController]
    public class TrainingServicesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<TrainingService, System.Guid, TrainingServiceInputModel, TrainingServiceDisplayModel, TrainingServiceFilterModel>
    {
        private readonly IEntityRepository<TrainingServiceStep, System.Guid> stepRepository;

        public TrainingServicesController(IEntityRepository<TrainingServiceStep, System.Guid> stepRepository, IEntityRepository<TrainingService, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TrainingServicesController> localizer, Microsoft.Extensions.Logging.ILogger<TrainingServicesController> logger) : base(repository, localizer, logger)
        {
            this.stepRepository = stepRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<TrainingService, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<TrainingService, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override TrainingServiceDisplayModel EntityToDisplayModel(TrainingService entity)
        {
            var model = base.EntityToDisplayModel(entity);

            model.Steps = stepRepository.FindBy(_entity => _entity.ServiceId == entity.Id && _entity.ParentId == null).OrderBy(_entity => _entity.Priority).ToArray().Select(_entity =>
            {
                var _model = new TrainingServiceStepDisplayModel();

                _model.Import(_entity);

                return _model;
            }).ToArray();

            return model;
        }

        protected override void PreCreate(TrainingService entity, TrainingServiceInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingSteps)
            {
                var _entity = _model.Export();

                _entity.ServiceId = entity.Id;

                stepRepository.Add(_entity, User.Identity.Name, false);
            }
        }

        protected override void PreEdit(TrainingService entity, TrainingServiceInputModel model)
        {
            base.PreEdit(entity, model);

            #region Spaces

            foreach (var _model in model.OutgoingSteps)
            {
                stepRepository.Delete(new TrainingServiceStep { Id = _model.Id }, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionSteps)
            {
                var _entity = stepRepository.Get(_model.Id);

                _model.Mergue(_entity);

                stepRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingSteps)
            {
                var _entity = _model.Export();

                _entity.ServiceId = entity.Id;

                stepRepository.Add(_entity, User.Identity.Name, false);
            }

            #endregion
        }
    }
}
