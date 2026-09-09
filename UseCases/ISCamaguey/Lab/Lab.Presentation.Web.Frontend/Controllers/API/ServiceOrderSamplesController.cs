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
public class ServiceOrderSamplesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<ServiceOrderSample, System.Guid, ServiceOrderSampleInputModel, ServiceOrderSampleDisplayModel, Interop.API.Common.Models.Filter.CommonSampleFilterModel<ServiceOrderSampleDisplayModel, ServiceOrderSample>>
{
    private readonly IEntityRepository<Servicing.Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder, long> orderRepository;
    private readonly IEntityRepository<Image, System.Guid> imageRepository;
    private readonly IImageFileManagerFacade imageFileManager;

    public ServiceOrderSamplesController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Servicing.Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder, long> orderRepository, IEntityRepository<ServiceOrderSample, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ServiceOrderSamplesController> localizer, Microsoft.Extensions.Logging.ILogger<ServiceOrderSamplesController> logger) : base(repository, localizer, logger)
    {
        this.orderRepository = orderRepository;
        this.imageRepository = imageRepository;
        this.imageFileManager = imageFileManager;
    }

    protected override System.Linq.Expressions.Expression<System.Func<ServiceOrderSample, bool>> GetGlobalSelector()
    {
        return base.GetGlobalSelector();
    }

    protected override System.Func<ServiceOrderSample, object> GetOrderSelector()
    {
        return entity => entity.At;
    }

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override ServiceOrderSampleDisplayModel EntityToDisplayModel(ServiceOrderSample entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.FeatureImage != null)
        {
            model.FeatureImage.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.FeatureImage.ContentType);
        }

        return model;
    }

    protected override void PreCreate(ServiceOrderSample entity, ServiceOrderSampleInputModel model)
    {
        base.PreCreate(entity, model);

        var _entity = orderRepository.Get(model.ServiceOrderId);

        _entity.SampleReceptionAt = System.DateTime.Now;

        orderRepository.Update(_entity, $"_{User.Identity.Name}", false);

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

    protected override void PreEdit(ServiceOrderSample entity, ServiceOrderSampleInputModel model)
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

    protected override void PostEdit(ServiceOrderSample entity, ServiceOrderSampleInputModel model)
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