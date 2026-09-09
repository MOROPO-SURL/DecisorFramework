using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Web.Frontend.Controllers.API;

[Route("api/lab/[controller]")]
[ApiController]
public sealed class WorkPlansController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementController<WorkPlan, System.Guid, WorkPlanInputModel, WorkPlanDisplayModel>
{
    private readonly IEntityRepository<ServiceOrderSample, System.Guid> serviceOrderSampleRepository;
    private readonly IEntityRepository<ResearchSample, System.Guid> researchSampleRepository;
    private readonly IEntityRepository<ProductionSample, System.Guid> productionSampleRepository;

    public WorkPlansController(IEntityRepository<ProductionSample, System.Guid> productionSampleRepository, IEntityRepository<ResearchSample, System.Guid> researchSampleRepository, IEntityRepository<ServiceOrderSample, System.Guid> serviceOrderSampleRepository, IEntityRepository<WorkPlan, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<WorkPlansController> localizer, Microsoft.Extensions.Logging.ILogger<WorkPlansController> logger) : base(repository, localizer, logger)
    {
        this.serviceOrderSampleRepository = serviceOrderSampleRepository;
        this.researchSampleRepository = researchSampleRepository;
        this.productionSampleRepository = productionSampleRepository;
    }

    protected override System.Linq.Expressions.Expression<System.Func<WorkPlan, bool>> GetGlobalSelector()
    {
        return entity => !entity.Archived;
    }

    protected override System.Func<WorkPlan, object> GetOrderSelector()
    {
        return entity => entity.At;
    }

    public override ActionResult Delete(System.Guid key)
    {
        return NotFound();
    }

    protected override void PreCreate(WorkPlan entity, WorkPlanInputModel model)
    {
        base.PreCreate(entity, model);

        foreach (System.Guid sampleId in model.InServiceOrderSampleIds)
        {
            entity.ServiceOrderSampleBridges.Add(new WorkPlanServiceOrderSampleBridge { ProwId = entity.Id, SternId = sampleId });

            ServiceOrderSample serviceOrderSample = serviceOrderSampleRepository.Get(sampleId);

            if (serviceOrderSample.PickedAt != null || serviceOrderSample.HandledAt != null) throw new Framework.Guama.Core.Presentation.Web.Common.Exceptions.NoContinuableActionException("Conflict!");

            serviceOrderSample.PickedAt = entity.At;

            serviceOrderSampleRepository.Update(serviceOrderSample, User.Identity.Name, false);
        }

        foreach (System.Guid sampleId in model.InResearchSampleIds)
        {
            entity.ResearchSampleBridges.Add(new WorkPlanResearchSampleBridge { ProwId = entity.Id, SternId = sampleId });

            ResearchSample researchSample = researchSampleRepository.Get(sampleId);

            if (researchSample.PickedAt != null || researchSample.HandledAt != null) throw new Framework.Guama.Core.Presentation.Web.Common.Exceptions.NoContinuableActionException("Conflict!");

            researchSample.PickedAt = entity.At;

            researchSampleRepository.Update(researchSample, User.Identity.Name, false);
        }

        foreach (System.Guid sampleId in model.InProductionSampleIds)
        {
            entity.ProductionSampleBridges.Add(new WorkPlanProductionSampleBridge { ProwId = entity.Id, SternId = sampleId });

            ProductionSample productionSample = productionSampleRepository.Get(sampleId);

            if (productionSample.PickedAt != null || productionSample.HandledAt != null) throw new Framework.Guama.Core.Presentation.Web.Common.Exceptions.NoContinuableActionException("Conflict!");

            productionSample.PickedAt = entity.At;

            productionSampleRepository.Update(productionSample, User.Identity.Name, false);
        }
    }

    protected override void PreEdit(WorkPlan entity, WorkPlanInputModel model)
    {
        base.PreEdit(entity, model);

        foreach (System.Guid sampleId in model.OutServiceOrderSampleIds)
        {
            entity.ServiceOrderSampleBridges.Remove(entity.ServiceOrderSampleBridges.Single(bridge => bridge.SternId == sampleId));

            ServiceOrderSample serviceOrderSample = serviceOrderSampleRepository.Get(sampleId);

            if (serviceOrderSample.HandledAt != null) throw new Framework.Guama.Core.Presentation.Web.Common.Exceptions.NoContinuableActionException("Conflict!");

            serviceOrderSample.PickedAt = null;

            serviceOrderSampleRepository.Update(serviceOrderSample, User.Identity.Name, false);
        }

        foreach (System.Guid sampleId in model.OutResearchSampleIds)
        {
            entity.ResearchSampleBridges.Remove(entity.ResearchSampleBridges.Single(bridge => bridge.SternId == sampleId));

            ResearchSample researchSample = researchSampleRepository.Get(sampleId);

            if (researchSample.HandledAt != null) throw new Framework.Guama.Core.Presentation.Web.Common.Exceptions.NoContinuableActionException("Conflict!");

            researchSample.PickedAt = null;

            researchSampleRepository.Update(researchSample, User.Identity.Name, false);
        }

        foreach (System.Guid sampleId in model.OutProductionSampleIds)
        {
            entity.ProductionSampleBridges.Remove(entity.ProductionSampleBridges.Single(bridge => bridge.SternId == sampleId));

            ProductionSample productionSample = productionSampleRepository.Get(sampleId);

            if (productionSample.HandledAt != null) throw new Framework.Guama.Core.Presentation.Web.Common.Exceptions.NoContinuableActionException("Conflict!");

            productionSample.PickedAt = null;

            productionSampleRepository.Update(productionSample, User.Identity.Name, false);
        }

        foreach (System.Guid sampleId in model.InServiceOrderSampleIds)
        {
            entity.ServiceOrderSampleBridges.Add(new WorkPlanServiceOrderSampleBridge { ProwId = entity.Id, SternId = sampleId });

            ServiceOrderSample serviceOrderSample = serviceOrderSampleRepository.Get(sampleId);

            if (serviceOrderSample.PickedAt != null || serviceOrderSample.HandledAt != null) throw new Framework.Guama.Core.Presentation.Web.Common.Exceptions.NoContinuableActionException("Conflict!");

            serviceOrderSample.PickedAt = entity.At;

            serviceOrderSampleRepository.Update(serviceOrderSample, User.Identity.Name, false);
        }

        foreach (System.Guid sampleId in model.InResearchSampleIds)
        {
            entity.ResearchSampleBridges.Add(new WorkPlanResearchSampleBridge { ProwId = entity.Id, SternId = sampleId });

            ResearchSample researchSample = researchSampleRepository.Get(sampleId);

            if (researchSample.PickedAt != null || researchSample.HandledAt != null) throw new Framework.Guama.Core.Presentation.Web.Common.Exceptions.NoContinuableActionException("Conflict!");

            researchSample.PickedAt = entity.At;

            researchSampleRepository.Update(researchSample, User.Identity.Name, false);
        }

        foreach (System.Guid sampleId in model.InProductionSampleIds)
        {
            entity.ProductionSampleBridges.Add(new WorkPlanProductionSampleBridge { ProwId = entity.Id, SternId = sampleId });

            ProductionSample productionSample = productionSampleRepository.Get(sampleId);

            if (productionSample.PickedAt != null || productionSample.HandledAt != null) throw new Framework.Guama.Core.Presentation.Web.Common.Exceptions.NoContinuableActionException("Conflict!");

            productionSample.PickedAt = entity.At;

            productionSampleRepository.Update(productionSample, User.Identity.Name, false);
        }
    }
}
