using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Frontend.Controllers.API;

[Route("api/lab/[controller]")]
[ApiController]
public class ResearchSamplesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<ResearchSample, System.Guid, ResearchSampleInputModel, ResearchSampleDisplayModel, Interop.API.Common.Models.Filter.CommonSampleFilterModel<ResearchSampleDisplayModel, ResearchSample>>
{
    private readonly IEntityRepository<Image, System.Guid> imageRepository;
    private readonly IImageFileManagerFacade imageFileManager;

    public ResearchSamplesController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<ResearchSample, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ResearchSamplesController> localizer, Microsoft.Extensions.Logging.ILogger<ResearchSamplesController> logger) : base(repository, localizer, logger)
    {
        this.imageRepository = imageRepository;
        this.imageFileManager = imageFileManager;
    }

    protected override System.Linq.Expressions.Expression<System.Func<ResearchSample, bool>> GetGlobalSelector()
    {
        return base.GetGlobalSelector();
    }

    protected override System.Func<ResearchSample, object> GetOrderSelector()
    {
        return entity => entity.At;
    }

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override ResearchSampleDisplayModel EntityToDisplayModel(ResearchSample entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.FeatureImage != null)
        {
            model.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.FeatureImage.ContentType);
        }

        foreach (var _entity in entity.Project.InternalResearcherParticipations)
        {
            InternalResearcherProjectParticipationDisplayModel _model = new();

            _model.Import(_entity);

            if (_model.Researcher.Employee.Contact.Identity.Image != null)
            {
                _model.Researcher.Employee.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Researcher.Employee.Contact.Identity.Image.ContentType);
            }

            model.Project.InternalResearcherProjectParticipations.Add(_model);
        }

        foreach (var _entity in entity.Project.ExternalResearcherParticipations)
        {
            ExternalResearcherProjectParticipationDisplayModel _model = new();

            _model.Import(_entity);

            if (_model.Researcher.Contact.Identity.Image != null)
            {
                _model.Researcher.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(_entity.Researcher.Contact.Identity.Image.ContentType);
            }

            model.Project.ExternalResearcherProjectParticipations.Add(_model);
        }

        return model;
    }

    protected override void PreCreate(ResearchSample entity, ResearchSampleInputModel model)
    {
        base.PreCreate(entity, model);

        if (model.FeatureImage != null)
        {
            using var imageMemoryStream = new System.IO.MemoryStream(model.FeatureImage.ContentData);

            using var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream);

            using var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData);

            entity.FeatureImage = imageRepository.Add(new Image
            {
                ContentType = model.FeatureImage.ContentType,
                Length = model.FeatureImage.ContentData.LongLength,
                Width = imageSkBitmap.Width,
                Height = imageSkBitmap.Height,
                About = string.Format("Image for Sample: {0}", model.Id)
            }, User.Identity.Name, false);

            imageFileManager.SaveImageFileContent(entity.FeatureImage.Id, model.FeatureImage.ContentData, model.FeatureImage.ContentType);
        }
    }

    protected override void PreEdit(ResearchSample entity, ResearchSampleInputModel model)
    {
        base.PreEdit(entity, model);

        if (model.FeatureImage != null)
        {
            using var imageMemoryStream = new System.IO.MemoryStream(model.FeatureImage.ContentData);

            using var imageSkData = SkiaSharp.SKData.Create(imageMemoryStream);

            using var imageSkBitmap = SkiaSharp.SKBitmap.Decode(imageSkData);

            entity.FeatureImage = imageRepository.Add(new Image
            {
                ContentType = model.FeatureImage.ContentType,
                Length = model.FeatureImage.ContentData.LongLength,
                Width = imageSkBitmap.Width,
                Height = imageSkBitmap.Height,
                About = string.Format("Image for Sample: {0}", model.Id)
            }, User.Identity.Name, false);

            imageFileManager.SaveImageFileContent(entity.FeatureImage.Id, model.FeatureImage.ContentData, model.FeatureImage.ContentType);
        }
    }

    protected override void PostEdit(ResearchSample entity, ResearchSampleInputModel model)
    {
        base.PostEdit(entity, model);

        try
        {
            if (model.FeatureImage != null)
            {
                var oldLogoImage = imageRepository.Get(model.FeatureImage.Id);

                imageRepository.Delete(oldLogoImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(oldLogoImage);
            }
        }
        catch { }
    }
}