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
    public class FinanciersController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.Contract.AbstractArchivableEnableableEntityManagementController<Financier, System.Guid, FinancierInputModel, FinancierDisplayViewModel>
    {
        private readonly IEntityRepository<Document, System.Guid> documentRepository;
        private readonly IDocumentFileManagerFacade documentFileManager;

        public FinanciersController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<Financier, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<FinanciersController> localizer, ILogger<FinanciersController> logger) : base(repository, localizer, logger)
        {
            this.documentRepository = documentRepository;
            this.documentFileManager = documentFileManager;
        }

        [RequirePermissions(Authorization.FinancierViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(FinancierInputModel model)
        {
            return NotFound();
        }

        public override IActionResult Edit(System.Guid key)
        {
            return NotFound();
        }

        public override IActionResult Edit(FinancierInputModel model)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.FinancierEditorPermission)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequirePermissions(Authorization.FinancierEditorPermission)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequirePermissions(Authorization.FinancierEditorPermission)]
        public override IActionResult Archive(System.Guid key)
        {
            return base.Archive(key);
        }

        [RequirePermissions(Authorization.FinancierEditorPermission)]
        public override IActionResult Unarchive(System.Guid key)
        {
            return base.Unarchive(key);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Authorization.FinancierRemoverPermission)]
        public override IActionResult Delete(FinancierDisplayViewModel model)
        {
            return base.Delete(model);
        }

        protected override void PostDelete(Financier entity)
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
