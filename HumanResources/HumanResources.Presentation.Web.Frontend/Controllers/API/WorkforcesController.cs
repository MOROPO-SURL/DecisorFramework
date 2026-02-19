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

        public WorkforcesController(IEntityRepository<WorkforceOrganizationalUnit, System.Guid> organizationalUnitRepository, IEntityRepository<Vacant, System.Guid> vacantRepository, IEntityRepository<Workforce, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<WorkforcesController> localizer, Microsoft.Extensions.Logging.ILogger<WorkforcesController> logger)
            : base(repository, localizer, logger)
        {
            this.vacantRepository = vacantRepository;
            this.organizationalUnitRepository = organizationalUnitRepository;
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

            //result.OrganizationalUnities = GetOrganizationalUnityChildren(entity.OrganizationalUnits.Where(_entity => _entity.ParentId == null).OrderBy(_entity => _entity.OrganizationalStructuringUnit.Priority).ToArray());

            return result;
        }

        protected override void PreCreate(Workforce entity, WorkforceInputModel model)
        {
            base.PreCreate(entity, model);

            //entity.ChiefVacant = vacantRepository.Add(model.ChiefVacant.Export(), User.Identity.Name, false);
            //entity.ChiefVacantId = entity.ChiefVacant.Id;

            foreach (var _model in model.IncomingOrganizationalUnits)
            {
                var _entity = _model.Export();

                _entity.WorkforceId = entity.Id;

                organizationalUnitRepository.Add(_entity, User.Identity.Name, false);

                PreCreate(_entity, _model);
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

            //model.ChiefVacant.Mergue(entity.ChiefVacant);

            foreach (var _model in model.OutgoingOrganizationalUnits)
            {
                organizationalUnitRepository.Delete(new WorkforceOrganizationalUnit { Id = _model.Id }, User.Identity.Name, false);
            }

            foreach (var _model in model.IncomingOrganizationalUnits)
            {
                var _entity = _model.Export();

                _entity.WorkforceId = entity.Id;

                organizationalUnitRepository.Add(_entity, User.Identity.Name, false);

                PreCreate(_entity, _model);
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

        private void PreCreate(WorkforceOrganizationalUnit entity, WorkforceOrganizationalUnitInputModel model)
        {
            //foreach (var _model in model.Children)
            //{
            //    var _entity = _model.Export();

            //    _entity.ParentId = entity.Id;
            //    _entity.WorkforceId = entity.WorkforceId;

            //    organizationalUnityRepository.Add(_entity, User.Identity.Name, false);

            //    PreCreate(_entity, _model);
            //}
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

            //foreach (var _model in model.Children)
            //{
            //    PostCreate(organizationalUnityRepository.Get(_model.Id), _model);
            //}
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

        //private WorkforceOrganizationalUnitDisplayModel[] GetOrganizationalUnityChildren(WorkforceOrganizationalUnit[] organizationalUnities)
        //{
        //    var result = new System.Collections.Generic.List<WorkforceOrganizationalUnitDisplayModel>();

        //    foreach (var entity in organizationalUnities)
        //    {
        //        var model = new WorkforceOrganizationalUnitDisplayModel();

        //        model.Import(entity);

        //        if (entity.ChiefVacant != null)
        //        {
        //            model.Vacants = vacantRepository.FindBy(_entity => _entity.WorkforceOrganizationalUnitId == entity.Id && _entity.Id != entity.ChiefVacant.Id).OrderBy(_entity => _entity.Priority).ToArray().Select(_entity =>
        //            {
        //                var _model = new VacantDisplayModel();

        //                _model.Import(_entity);

        //                return _model;
        //            }).ToArray();
        //        }
        //        else
        //        {
        //            model.Vacants = vacantRepository.FindBy(_entity => _entity.WorkforceOrganizationalUnitId == entity.Id).OrderBy(_entity => _entity.Priority).ToArray().Select(_entity =>
        //            {
        //                var _model = new VacantDisplayModel();

        //                _model.Import(_entity);

        //                return _model;
        //            }).ToArray();
        //        }

        //        var children = organizationalUnitRepository.FindBy(_entity => _entity.ParentId == entity.Id).OrderBy(_entity => _entity.OrganizationalStructuringUnit.Priority).ToArray();

        //        model.Children = GetOrganizationalUnityChildren(children);

        //        result.Add(model);
        //    }

        //    return [.. result.OrderBy(model => model.OrganizationalStructuringUnit.OrganizationalUnit.Priority)];
        //}
    }
}
