using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Essential.Persistence.Entities;
using MOROPO.Framework.Decisor.Essential.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Essential.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.Essential.Presentation.Web.Backend.Controllers.HHRR
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("HHRR")]
    public class EmployeesController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<Employee, System.Guid, EmployeeInputModel, EmployeeDisplayViewModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public EmployeesController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Employee, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<EmployeesController> localizer, ILogger<EmployeesController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        [RequirePermissions(Constants.Security.Authorization.EmployeeViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(EmployeeInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(EmployeeInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Constants.Security.Authorization.EmployeeEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Constants.Security.Authorization.EmployeeEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Constants.Security.Authorization.EmployeeEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Constants.Security.Authorization.EmployeeEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Constants.Security.Authorization.EmployeeRemoverPermission)]
        public override IActionResult Delete(EmployeeDisplayViewModel model)
        {
            return base.Delete(model);
        }

        protected override void PostDelete(Employee entity)
        {
            base.PostDelete(entity);

            if (entity.Identity.Image != null)
            {
                imageRepository.Delete(entity.Identity.Image, User.Identity.Name);

                imageFileManager.DeleteImageFile(entity.Identity.Image);
            }
        }
    }
}

