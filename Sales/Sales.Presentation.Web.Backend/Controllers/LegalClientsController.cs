using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Sales.Persistence.Entities;
using MOROPO.Framework.Decisor.Sales.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Decisor.Sales.Interop.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.Sales.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("sales")]
    public class LegalClientsController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<LegalClient, System.Guid, LegalClientInputModel, LegalClientDisplayViewModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public LegalClientsController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<LegalClient, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalClientsController> localizer, ILogger<LegalClientsController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        [RequirePermissions(Constants.Security.Authorization.LegalClientViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(LegalClientInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(LegalClientInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Constants.Security.Authorization.LegalClientEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Constants.Security.Authorization.LegalClientEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Constants.Security.Authorization.LegalClientEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Constants.Security.Authorization.LegalClientEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Constants.Security.Authorization.LegalClientRemoverPermission)]
        public override IActionResult Delete(LegalClientDisplayViewModel model)
        {
            return base.Delete(model);
        }

        protected override void PostDelete(LegalClient entity)
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
