using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Core.Persistence.Entities;
using MOROPO.Framework.Decisor.Core.Presentation.Web.Backend.Models.View.Display;
using MOROPO.Framework.Decisor.Core.Web.API.Common.Models.Input;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Backend.Controllers.Backend.Purchasing
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("purchasing")]
    public class NaturalProvidersController : Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<NaturalProvider, System.Guid, NaturalProviderInputModel, NaturalProviderDisplayViewModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public NaturalProvidersController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<NaturalProvider, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalProvidersController> localizer, ILogger<NaturalProvidersController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalProviderViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(NaturalProviderInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(NaturalProviderInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalProviderEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalProviderEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalProviderEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalProviderEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Constants.Security.Authorization.NaturalProviderRemoverPermission)]
        public override IActionResult Delete(NaturalProviderDisplayViewModel model)
        {
            return base.Delete(model);
        }

        protected override void PostDelete(NaturalProvider entity)
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
