using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Constants.Security;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Backend.Models.View.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("Servicing")]
    public class GroundIntegralStudyServicesController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<GroundIntegralStudyService, System.Guid, GroundIntegralStudyServiceInputModel, GroundIntegralStudyServiceDisplayViewModel>
    {
        private readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly IDocumentFileManagerFacade documentFileManager;

        public GroundIntegralStudyServicesController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<GroundIntegralStudyService, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<GroundIntegralStudyServicesController> localizer, ILogger<GroundIntegralStudyServicesController> logger) : base(repository, localizer, logger)
        {
            this.documentRepository = documentRepository;
            this.documentFileManager = documentFileManager;
        }

        [RequirePermissions(Authorization.GroundIntegralStudyServiceViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(GroundIntegralStudyServiceInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(GroundIntegralStudyServiceInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.GroundIntegralStudyServiceEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Authorization.GroundIntegralStudyServiceEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Authorization.GroundIntegralStudyServiceEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.GroundIntegralStudyServiceEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.GroundIntegralStudyServiceRemoverPermission)]
        public override IActionResult Delete(GroundIntegralStudyServiceDisplayViewModel model)
        {
            return base.Delete(model);
        }

        protected override void PostDelete(GroundIntegralStudyService entity)
        {
            base.PostDelete(entity);

            foreach (var bridge in entity.DocumentBridges)
            {
                documentRepository.Delete(bridge.Stern, User.Identity.Name, false);

                documentFileManager.DeleteDocumentFile(bridge.Stern);
            }
        }
    }
}
