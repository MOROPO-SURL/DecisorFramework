using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class WorkforcesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<Workforce, System.Guid, WorkforceInputModel, WorkforceDisplayModel>
    {
        private readonly IEntityRepository<Vacant, System.Guid> vacantRepository;
        private readonly IEntityRepository<Domain.Persistence.Entities.OrganizationalUnity, System.Guid> organizationalUnityRepository;

        public WorkforcesController(IEntityRepository<Domain.Persistence.Entities.OrganizationalUnity, System.Guid> organizationalUnityRepository, IEntityRepository<Vacant, System.Guid> vacantRepository, IEntityRepository<Workforce, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<WorkforcesController> localizer, Microsoft.Extensions.Logging.ILogger<WorkforcesController> logger)
            : base(repository, localizer, logger)
        {
            this.vacantRepository = vacantRepository;
            this.organizationalUnityRepository = organizationalUnityRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<Workforce, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<Workforce, object> GetOrderSelector()
        {
            return entity => entity.Priority;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override WorkforceDisplayModel EntityToDisplayModel(Workforce entity)
        {
            var result = base.EntityToDisplayModel(entity);

            var organizationalUnityModels = new System.Collections.Generic.List<OrganizationalUnityDisplayModel>();

            foreach (var bridge in entity.OrganizationalUnityBridges)
            {
                var model = new OrganizationalUnityDisplayModel();

                model.Import(bridge.Stern);

                model.Vacants = vacantRepository.FindBy(_entity => _entity.WorkforceId == entity.Id && _entity.OrganizationUnityId == bridge.SternId).OrderBy(_entity => _entity.Priority).ToArray().Select(_entity =>
                {
                    var _model = new VacantDisplayModel();

                    _model.Import(_entity);

                    return _model;
                }).ToArray();

                model.Children = GetOrganizationalUnityChildren(entity, bridge.Stern);

                organizationalUnityModels.Add(model);
            }

            result.OrganizationalUnities = organizationalUnityModels.OrderBy(model => model.Priority).ToArray();

            return result;
        }

        protected override void PreCreate(Workforce entity, WorkforceInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingVacants)
            {
                var _entity = _model.Export();

                _entity.WorkforceId = entity.Id;

                vacantRepository.Add(_entity, User.Identity.Name, false);
            }
        }

        protected override void PreEdit(Workforce entity, WorkforceInputModel model)
        {
            base.PreEdit(entity, model);

            foreach (var _model in model.OutgoingVacants)
            {
                vacantRepository.Delete(new Vacant { Id = _model.Id }, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionVacants)
            {
                var _entity = _model.Export();

                _entity.WorkforceId = entity.Id;

                vacantRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingVacants)
            {
                var _entity = _model.Export();

                _entity.WorkforceId = entity.Id;

                vacantRepository.Add(_entity, User.Identity.Name, false);
            }
        }

        private OrganizationalUnityDisplayModel[] GetOrganizationalUnityChildren(Workforce workforce, Domain.Persistence.Entities.OrganizationalUnity entity)
        {
            var result = new System.Collections.Generic.List<OrganizationalUnityDisplayModel>();

            var children = organizationalUnityRepository.FindBy(_entity => !_entity.Archived && _entity.ParentId == entity.Id).OrderBy(_entity => _entity.Priority).ToArray();

            foreach (var child in children)
            {
                var model = new OrganizationalUnityDisplayModel();
                model.Import(child);

                model.Vacants = vacantRepository.FindBy(_entity => _entity.WorkforceId == workforce.Id && _entity.OrganizationUnityId == child.Id).OrderBy(_entity => _entity.Priority).ToArray().Select(_entity =>
                {
                    var _model = new VacantDisplayModel();

                    _model.Import(_entity);

                    return _model;
                }).ToArray();

                model.Children = GetOrganizationalUnityChildren(workforce, child);

                result.Add(model);
            }

            return result.ToArray();
        }
    }
}
