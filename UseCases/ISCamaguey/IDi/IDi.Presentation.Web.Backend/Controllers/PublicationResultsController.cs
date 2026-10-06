using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Constants.Security;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("IDi")]
    public class PublicationResultsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEntityManagementController<PublicationResult, System.Guid, PublicationResultInputModel, PublicationResultDisplayViewModel>
    {
        private readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly IDocumentFileManagerFacade documentFileManager;

        public PublicationResultsController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<PublicationResult, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PublicationResultsController> localizer, ILogger<PublicationResultsController> logger) : base(repository, localizer, logger)
        {
            this.documentRepository = documentRepository;
            this.documentFileManager = documentFileManager;
        }

        [RequirePermissions(Authorization.PublicationResultViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(PublicationResultInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(PublicationResultInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.PublicationResultEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.PublicationResultEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.PublicationResultRemoverPermission)]
        public override IActionResult Delete(PublicationResultDisplayViewModel model)
        {
            return base.Delete(model);
        }

        protected override void PostDelete(PublicationResult entity)
        {
            base.PostDelete(entity);

            if (entity.Document == null) return;

            documentRepository.Delete(entity.Document, User.Identity.Name, false);

            documentFileManager.DeleteDocumentFile(entity.Document);
        }
    }
}
