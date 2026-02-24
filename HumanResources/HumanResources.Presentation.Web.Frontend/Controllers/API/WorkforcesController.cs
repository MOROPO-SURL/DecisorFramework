using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class WorkforcesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<Workforce, System.Guid, WorkforceInputModel, WorkforceDisplayModel, WorkforceFilterModel>
    {
        private readonly IEntityRepository<Vacant, System.Guid> vacantRepository;
        private readonly IEntityRepository<WorkforceOrganizationalUnit, System.Guid> organizationalUnitRepository;
        private readonly IEntityRepository<OrganizationalStructuringUnit, System.Guid> organizationalStructuringUnityRepository;

        public WorkforcesController(IEntityRepository<OrganizationalStructuringUnit, System.Guid> organizationalStructuringUnityRepository, IEntityRepository<WorkforceOrganizationalUnit, System.Guid> organizationalUnitRepository, IEntityRepository<Vacant, System.Guid> vacantRepository, IEntityRepository<Workforce, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<WorkforcesController> localizer, Microsoft.Extensions.Logging.ILogger<WorkforcesController> logger)
            : base(repository, localizer, logger)
        {
            this.vacantRepository = vacantRepository;
            this.organizationalUnitRepository = organizationalUnitRepository;
            this.organizationalStructuringUnityRepository = organizationalStructuringUnityRepository;
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

            result.OrganizationalStructure.RootStructuringUnit = entity.OrganizationalStructure.RootStructuringUnit.GetInteropChildren(organizationalStructuringUnityRepository);

            result.OrganizationalUnits = organizationalUnitRepository.FindBy(_entity => _entity.WorkforceId == entity.Id).ToArray().Select(_entity =>
            {
                var _model = new WorkforceOrganizationalUnitDisplayModel();

                _model.Import(_entity);

                if (_entity.ChiefVacantId != null)
                {
                    _model.Vacants = vacantRepository.FindBy(__entity => __entity.WorkforceOrganizationalUnitId == _entity.Id && __entity.Id != _entity.ChiefVacant.Id).OrderBy(__entity => __entity.Priority).ToArray().Select(__entity =>
                    {
                        var __model = new VacantDisplayModel();

                        __model.Import(__entity);

                        return __model;
                    }).ToArray();
                }
                else
                {
                    _model.Vacants = vacantRepository.FindBy(__entity => __entity.WorkforceOrganizationalUnitId == _entity.Id).OrderBy(__entity => __entity.Priority).ToArray().Select(__entity =>
                    {
                        var __model = new VacantDisplayModel();

                        __model.Import(__entity);

                        return __model;
                    }).ToArray();
                }

                return _model;
            }).ToArray();

            return result;
        }

        protected override void PreCreate(Workforce entity, WorkforceInputModel model)
        {
            base.PreCreate(entity, model);

            foreach (var _model in model.IncomingOrganizationalUnits)
            {
                var _entity = _model.Export();

                _entity.WorkforceId = entity.Id;

                organizationalUnitRepository.Add(_entity, User.Identity.Name, false);
            }
        }

        protected override void PostCreate(Workforce entity, WorkforceInputModel model)
        {
            base.PostCreate(entity, model);

            foreach (var _model in model.IncomingOrganizationalUnits)
            {
                PostCreate(organizationalUnitRepository.Get(_model.Id), _model);
            }

            Repository.Update(entity, User.Identity.Name);
        }

        protected override void PreEdit(Workforce entity, WorkforceInputModel model)
        {
            base.PreEdit(entity, model);

            foreach (var _model in model.OutgoingOrganizationalUnits)
            {
                organizationalUnitRepository.Delete(new WorkforceOrganizationalUnit { Id = _model.Id }, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingOrganizationalUnits)
            {
                var _entity = _model.Export();

                _entity.WorkforceId = entity.Id;

                organizationalUnitRepository.Add(_entity, User.Identity.Name, false);

                //PreCreate(_entity, _model);
            }
        }

        protected override void PostEdit(Workforce entity, WorkforceInputModel model)
        {
            base.PostEdit(entity, model);

            foreach (var _model in model.EditionOrganizationalUnits)
            {
                PostEdit(organizationalUnitRepository.Get(_model.Id), _model);
            }

            foreach (var _model in model.IncomingOrganizationalUnits)
            {
                PostCreate(organizationalUnitRepository.Get(_model.Id), _model);
            }

            Repository.Update(entity, User.Identity.Name);
        }

        private void PostCreate(WorkforceOrganizationalUnit entity, WorkforceOrganizationalUnitInputModel model)
        {
            if (model.ChiefVacant != null)
            {
                entity.ChiefVacant = model.ChiefVacant.Export();
                entity.ChiefVacantId = entity.ChiefVacant.Id;
                entity.ChiefVacant.WorkforceOrganizationalUnitId = entity.Id;

                vacantRepository.Add(entity.ChiefVacant, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingVacants)
            {
                var _entity = _model.Export();

                _entity.WorkforceOrganizationalUnitId = entity.Id;

                vacantRepository.Add(_entity, User.Identity.Name, false);
            }
        }

        private void PostEdit(WorkforceOrganizationalUnit entity, WorkforceOrganizationalUnitInputModel model)
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
                    entity.ChiefVacant.WorkforceOrganizationalUnitId = entity.Id;

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

                _entity.WorkforceOrganizationalUnitId = entity.Id;

                vacantRepository.Add(_entity, User.Identity.Name, false);
            }

            //foreach (var _model in model.Children)
            //{
            //    PostEdit(organizationalUnityRepository.Get(_model.Id), _model);
            //}
        }
    }
}
