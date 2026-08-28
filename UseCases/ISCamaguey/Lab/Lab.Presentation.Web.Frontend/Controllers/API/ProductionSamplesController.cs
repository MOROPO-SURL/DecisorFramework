using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Frontend.Controllers.API;

[Route("api/lab/[controller]")]
[ApiController]
public class ProductionSamplesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<ProductionSample, System.Guid, ProductionSampleInputModel, ProductionSampleDisplayModel>
{
    private readonly IEntityRepository<Image, System.Guid> imageRepository;
    private readonly IImageFileManagerFacade imageFileManager;

    public ProductionSamplesController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<ProductionSample, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ProductionSamplesController> localizer, Microsoft.Extensions.Logging.ILogger<ProductionSamplesController> logger) : base(repository, localizer, logger)
    {
        this.imageRepository = imageRepository;
        this.imageFileManager = imageFileManager;
    }

    protected override System.Linq.Expressions.Expression<System.Func<ProductionSample, bool>> GetGlobalSelector()
    {
        return base.GetGlobalSelector();
    }

    protected override System.Func<ProductionSample, object> GetOrderSelector()
    {
        return entity => entity.At;
    }

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override ProductionSampleDisplayModel EntityToDisplayModel(ProductionSample entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.FeatureImage != null)
        {
            model.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.FeatureImage.ContentType);
        }

        return model;
    }

    protected override void PreCreate(ProductionSample entity, ProductionSampleInputModel model)
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

    protected override void PreEdit(ProductionSample entity, ProductionSampleInputModel model)
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

    protected override void PostEdit(ProductionSample entity, ProductionSampleInputModel model)
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