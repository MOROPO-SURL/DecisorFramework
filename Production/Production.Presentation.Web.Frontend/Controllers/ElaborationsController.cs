using Microsoft.Extensions.Logging;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Production.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Frontend.Controllers;

[Microsoft.AspNetCore.Mvc.Route("api/fwrk/production/[controller]")]
[Microsoft.AspNetCore.Mvc.ApiController]
public class ElaborationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<Elaboration, System.Guid, ElaborationInputModel, ElaborationDisplayModel, ElaborationFilterModel>
{
    private readonly IEntityRepository<ElaborationStep, System.Guid> stepRepository;
    private readonly IEntityRepository<Document, System.Guid> documentRepository;
    private readonly IDocumentFileManagerFacade documentFileManager;

    public ElaborationsController(IDocumentFileManagerFacade documentFileManager, IEntityRepository<Document, System.Guid> documentRepository, IEntityRepository<ElaborationStep, System.Guid> stepRepository, IEntityRepository<Elaboration, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ElaborationsController> localizer, ILogger<ElaborationsController> logger) : base(repository, localizer, logger)
    {
        this.stepRepository = stepRepository;
        this.documentRepository = documentRepository;
        this.documentFileManager = documentFileManager;
    }

    protected override System.Linq.Expressions.Expression<System.Func<Elaboration, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<Elaboration, object> GetOrderSelector()
    {
        return entity => entity.Priority;
    }

    public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override ElaborationDisplayModel EntityToDisplayModel(Elaboration entity)
    {
        var steps = stepRepository.FindBy(_entity => _entity.ElaborationId == entity.Id).ToArray();

        var model = base.EntityToDisplayModel(entity);

        if (entity.Product.FeatureImage != null)
        {
            model.Product.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Product.FeatureImage.ContentType);
        }

        model.Documents = entity.DocumentBridges.Select(bridge =>
        {
            var _model = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

            _model.Import(bridge.Stern);

            _model.Extension = MimeTypes.MimeTypeMap.GetExtension(bridge.Stern.ContentType);

            return _model;
        }).ToArray();

        model.Steps = steps.Select(_entity =>
        {
            var _model = new ElaborationStepDisplayModel();

            _model.Import(_entity);

            return _model;
        }).ToArray();

        return model;
    }

    protected override void PreCreate(Elaboration entity, ElaborationInputModel model)
    {
        base.PreCreate(entity, model);

        foreach (var _model in model.IncomingDocuments)
        {
            var __entity = documentRepository.Add(new Document
            {
                Id = _model.Id,
                Name = _model.Name,
                ContentType = _model.ContentType,
                Description = _model.Description,
                Length = _model.ContentData.Length
            }, User.Identity.Name, false);

            entity.DocumentBridges.Add(new ElaborationDocumentBridge
            {
                ProwId = entity.Id,
                SternId = __entity.Id
            });

            documentFileManager.SaveDocumentFileContent(__entity.Id, _model.ContentData, __entity.ContentType);
        }

        if (model.Steps != null)
        {
            foreach (var _model in model.Steps)
            {
                var _entity = stepRepository.Add(new ElaborationStep
                {
                    Id = _model.Id,
                    Name = _model.Name,
                    ElaborationId = entity.Id,
                    Description = _model.Description,
                    MinDecrease = _model.MinDecrease,
                    MaxDecrease = _model.MaxDecrease,
                    Priority = _model.Priority,
                    WorkPositionBridges = _model.WorkPositions.Select(__model => new ElaborationStepWorkPositionBridge
                    {
                        ProwId = _model.Id,
                        SternId = __model.WorkPosition.Id,
                        Participation = __model.Participation,
                        Relative = __model.Relative,
                        Description = __model.Description
                    }).ToList()
                }, User.Identity.Name, false);
            }
        }
    }

    protected override void PreEdit(Elaboration entity, ElaborationInputModel model)
    {
        base.PreEdit(entity, model);

        var steps = stepRepository.FindBy(_entity => _entity.ElaborationId == entity.Id).ToArray();

        foreach (var _entity in steps)
        {
            stepRepository.Delete(_entity, User.Identity.Name, false);
        }

        if (model.Steps != null)
        {
            foreach (var _model in model.Steps)
            {
                stepRepository.Add(new ElaborationStep
                {
                    Id = _model.Id,
                    Name = _model.Name,
                    ElaborationId = entity.Id,
                    Description = _model.Description,
                    MinDecrease = _model.MinDecrease,
                    MaxDecrease = _model.MaxDecrease,
                    Priority = _model.Priority,
                    WorkPositionBridges = _model.WorkPositions.Select(__model => new ElaborationStepWorkPositionBridge
                    {
                        ProwId = _model.Id,
                        SternId = __model.WorkPosition.Id,
                        Participation = __model.Participation,
                        Relative = __model.Relative,
                        Description = __model.Description
                    }).ToList()
                }, User.Identity.Name, false);
            }
        }

        #region Documents

        foreach (var _model in model.OutgoingDocuments)
        {
            var _entity = entity.DocumentBridges.First(bridge => bridge.SternId == _model.Id).Stern;

            documentRepository.Delete(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.EditionDocuments)
        {
            var _entity = entity.DocumentBridges.First(bridge => bridge.SternId == _model.Id).Stern;

            _model.Mergue(_entity);

            documentRepository.Update(_entity, User.Identity.Name, false);
        }

        foreach (var _model in model.IncomingDocuments)
        {
            var _entity = documentRepository.Add(new Document
            {
                Id = _model.Id,
                Name = _model.Name,
                ContentType = _model.ContentType,
                Description = _model.Description,
                Length = _model.ContentData.Length
            }, User.Identity.Name, false);

            entity.DocumentBridges.Add(new ElaborationDocumentBridge
            {
                ProwId = entity.Id,
                SternId = _entity.Id
            });

            documentFileManager.SaveDocumentFileContent(_entity.Id, _model.ContentData, _entity.ContentType);
        }

        #endregion
    }
}
