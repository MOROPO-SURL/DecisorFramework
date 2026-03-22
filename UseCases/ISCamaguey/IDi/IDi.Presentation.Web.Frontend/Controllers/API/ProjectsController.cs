using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API;

[Route("api/idi/[controller]")]
[ApiController]
public class ProjectsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<Project, System.Guid, ProjectInputModel, ProjectDisplayModel, ProjectFilterModel>
{
    public ProjectsController(IEntityRepository<Project, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProjectsController> localizer, Microsoft.Extensions.Logging.ILogger<ProjectsController> logger)
        : base(repository, localizer, logger)
    {
    }

    protected override System.Linq.Expressions.Expression<System.Func<Project, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived && entity.Enabled;
    }

    protected override System.Func<Project, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override ProjectDisplayModel EntityToDisplayModel(Project entity)
    {
        var result = base.EntityToDisplayModel(entity);

        if (result.Chief.Employee.Contact.Identity.Image != null)
        {
            result.Chief.Employee.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Chief.Employee.Contact.Identity.Image.ContentType);
        }

        return result;
    }

    protected override void PreCreate(Project entity, ProjectInputModel model)
    {
        base.PreCreate(entity, model);

        //foreach (var _model in model.IncomingProjectExpectResults)
        //{
        //    var _entity = _model.Export();

        //    _entity.ProjectId = entity.Id;

        //    expectResultRepository.Add(_entity, User.Identity.Name, false);
        //}
    }

    protected override void PreEdit(Project entity, ProjectInputModel model)
    {
        base.PreEdit(entity, model);

        //foreach (var _model in model.OutgoingProjectExpectResults)
        //{
        //    expectResultRepository.Delete(new ProjectExpectResult { Id = _model.Id }, User.Identity.Name, false);
        //}

        //foreach (var _model in model.EditionProjectExpectResults)
        //{
        //    var _entity = _model.Export();

        //    _entity.ProjectId = entity.Id;

        //    expectResultRepository.Update(_entity, User.Identity.Name, false);
        //}

        //foreach (var _model in model.IncomingProjectExpectResults)
        //{
        //    var _entity = _model.Export();

        //    _entity.ProjectId = entity.Id;

        //    expectResultRepository.Add(_entity, User.Identity.Name, false);
        //}
    }
}
