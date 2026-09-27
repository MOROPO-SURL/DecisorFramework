using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Constants.Security;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Models.View.Display;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("Lab")]
    public class ServiceOrderSamplesController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<ServiceOrderSample, System.Guid, ServiceOrderSampleInputModel, ServiceOrderSampleDisplayViewModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public ServiceOrderSamplesController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<ServiceOrderSample, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ServiceOrderSamplesController> localizer, ILogger<ServiceOrderSamplesController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        [RequirePermissions(Authorization.ServiceOrderSampleViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(ServiceOrderSampleInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(ServiceOrderSampleInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.ServiceOrderSampleEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Authorization.ServiceOrderSampleEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Authorization.ServiceOrderSampleEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.ServiceOrderSampleEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.ServiceOrderSampleRemoverPermission)]
        public override IActionResult Delete(ServiceOrderSampleDisplayViewModel model)
        {
            return base.Delete(model);
        }

        protected override void PostDelete(Persistence.Entities.ServiceOrderSample entity)
        {
            base.PostDelete(entity);

            if (entity.FeatureImage != null)
            {
                imageRepository.Delete(entity.FeatureImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(entity.FeatureImage);
            }
        }
    }
}
