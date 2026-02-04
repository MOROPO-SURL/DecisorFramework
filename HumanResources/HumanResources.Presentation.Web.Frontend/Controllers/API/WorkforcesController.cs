using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Entities.Contract;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class WorkforcesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<Workforce, System.Guid, WorkforceInputModel, WorkforceDisplayModel, WorkforceFilterModel>
    {
        private readonly IEntityRepository<Vacant, System.Guid> vacantRepository;
        private readonly IEntityRepository<WorkforceOrganizationalUnity, System.Guid> organizationalUnityRepository;

        public WorkforcesController(IEntityRepository<WorkforceOrganizationalUnity, System.Guid> organizationalUnityRepository, IEntityRepository<Vacant, System.Guid> vacantRepository, IEntityRepository<Workforce, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<WorkforcesController> localizer, Microsoft.Extensions.Logging.ILogger<WorkforcesController> logger)
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

            result.OrganizationalUnities = GetOrganizationalUnityChildren(entity.OrganizationalUnities.Where(_entity => _entity.ParentId == null).OrderBy(_entity => _entity.OrganizationalUnity.Priority).ToArray());

            return result;
        }

        protected override void PreCreate(Workforce entity, WorkforceInputModel model)
        {
            base.PreCreate(entity, model);

            entity.ChiefVacant = vacantRepository.Add(model.ChiefVacant.Export(), User.Identity.Name, false);
            entity.ChiefVacantId = entity.ChiefVacant.Id;

            foreach (var _model in model.IncomingOrganizationalUnities)
            {
                var _entity = _model.Export();

                _entity.WorkforceId = entity.Id;

                organizationalUnityRepository.Add(_entity, User.Identity.Name, false);

                PreCreate(_entity, _model);
            }
        }

        protected override void PostCreate(Workforce entity, WorkforceInputModel model)
        {
            base.PostCreate(entity, model);

            foreach (var _model in model.IncomingOrganizationalUnities)
            {
                PostCreate(organizationalUnityRepository.Get(_model.Id), _model);
            }

            Repository.Update(entity, User.Identity.Name);
        }

        protected override void PreEdit(Workforce entity, WorkforceInputModel model)
        {
            base.PreEdit(entity, model);

            model.ChiefVacant.Mergue(entity.ChiefVacant);

            foreach (var _model in model.OutgoingOrganizationalUnities)
            {
                organizationalUnityRepository.Delete(new WorkforceOrganizationalUnity { Id = _model.Id }, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingOrganizationalUnities)
            {
                var _entity = _model.Export();

                _entity.WorkforceId = entity.Id;

                organizationalUnityRepository.Add(_entity, User.Identity.Name, false);

                PreCreate(_entity, _model);
            }
        }

        protected override void PostEdit(Workforce entity, WorkforceInputModel model)
        {
            base.PostEdit(entity, model);

            foreach (var _model in model.EditionOrganizationalUnities)
            {
                PostEdit(organizationalUnityRepository.Get(_model.Id), _model);
            }

            foreach (var _model in model.IncomingOrganizationalUnities)
            {
                PostCreate(organizationalUnityRepository.Get(_model.Id), _model);
            }

            Repository.Update(entity, User.Identity.Name);
        }

        private void PreCreate(WorkforceOrganizationalUnity entity, WorkforceOrganizationalUnityInputModel model)
        {
            foreach (var _model in model.Children)
            {
                var _entity = _model.Export();

                _entity.ParentId = entity.Id;
                _entity.WorkforceId = entity.WorkforceId;

                organizationalUnityRepository.Add(_entity, User.Identity.Name, false);

                PreCreate(_entity, _model);
            }
        }

        private void PostCreate(WorkforceOrganizationalUnity entity, WorkforceOrganizationalUnityInputModel model)
        {
            if (model.ChiefVacant != null)
            {
                entity.ChiefVacant = model.ChiefVacant.Export();
                entity.ChiefVacantId = entity.ChiefVacant.Id;
                entity.ChiefVacant.WorkforceOrganizationalUnityId = entity.Id;

                vacantRepository.Add(entity.ChiefVacant, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingVacants)
            {
                var _entity = _model.Export();

                _entity.WorkforceOrganizationalUnityId = entity.Id;

                vacantRepository.Add(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.Children)
            {
                PostCreate(organizationalUnityRepository.Get(_model.Id), _model);
            }
        }

        private void PostEdit(WorkforceOrganizationalUnity entity, WorkforceOrganizationalUnityInputModel model)
        {
            if (model.ChiefVacant != null)
            {
                if (entity.ChiefVacant != null)
                {
                    model.ChiefVacant.Mergue(entity.ChiefVacant);

                    vacantRepository.Update(entity.ChiefVacant, User.Identity.Name, false);
                }
                else
                {
                    entity.ChiefVacant = model.ChiefVacant.Export();
                    entity.ChiefVacantId = entity.ChiefVacant.Id;
                    entity.ChiefVacant.WorkforceOrganizationalUnityId = entity.Id;

                    vacantRepository.Add(entity.ChiefVacant, User.Identity.Name, false);
                }
            }

            foreach (var _model in model.OutgoingVacants)
            {
                vacantRepository.Delete(new Vacant { Id = _model.Id }, User.Identity.Name, false);
            }

            foreach (var _model in model.EditionVacants)
            {
                var _entity = vacantRepository.Get(_model.Id);

                _model.Mergue(_entity);

                vacantRepository.Update(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingVacants)
            {
                var _entity = _model.Export();

                _entity.WorkforceOrganizationalUnityId = entity.Id;

                vacantRepository.Add(_entity, User.Identity.Name, false);
            }

            foreach (var _model in model.Children)
            {
                PostEdit(organizationalUnityRepository.Get(_model.Id), _model);
            }
        }

        private WorkforceOrganizationalUnityDisplayModel[] GetOrganizationalUnityChildren(WorkforceOrganizationalUnity[] organizationalUnities)
        {
            var result = new System.Collections.Generic.List<WorkforceOrganizationalUnityDisplayModel>();

            foreach (var entity in organizationalUnities)
            {
                var model = new WorkforceOrganizationalUnityDisplayModel();

                model.Import(entity);

                if (entity.ChiefVacant != null)
                {
                    model.Vacants = vacantRepository.FindBy(_entity => _entity.WorkforceOrganizationalUnityId == entity.Id && _entity.Id != entity.ChiefVacant.Id).OrderBy(_entity => _entity.Priority).ToArray().Select(_entity =>
                    {
                        var _model = new VacantDisplayModel();

                        _model.Import(_entity);

                        return _model;
                    }).ToArray();
                }
                else
                {
                    model.Vacants = vacantRepository.FindBy(_entity => _entity.WorkforceOrganizationalUnityId == entity.Id).OrderBy(_entity => _entity.Priority).ToArray().Select(_entity =>
                    {
                        var _model = new VacantDisplayModel();

                        _model.Import(_entity);

                        return _model;
                    }).ToArray();
                }

                var children = organizationalUnityRepository.FindBy(_entity => _entity.ParentId == entity.Id).OrderBy(_entity => _entity.OrganizationalUnity.Priority).ToArray();

                model.Children = GetOrganizationalUnityChildren(children);

                result.Add(model);
            }

            return [.. result.OrderBy(model => model.OrganizationalUnity.Priority)];
        }
    }
}
