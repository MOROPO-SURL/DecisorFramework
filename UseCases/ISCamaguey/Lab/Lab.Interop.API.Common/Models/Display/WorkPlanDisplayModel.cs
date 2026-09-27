using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display
{
    public class WorkPlanDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.WorkPlan, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public System.DateTime At { get; set; }

        public WorkingGroupDisplayModel WorkingGroup { get; set; }

        public string Description { get; set; }

        public IEnumerable<ServiceOrderSampleDisplayModel> ServiceOrderSamples { get; set; }

        public IEnumerable<ResearchSampleDisplayModel> ResearchSamples { get; set; }

        public IEnumerable<ProductionSampleDisplayModel> ProductionSamples { get; set; }

        public virtual void Import(Persistence.Entities.WorkPlan entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            At = entity.At;
            Description = entity.Description;
            ServiceOrderSamples = entity.ServiceOrderSampleBridges.Select(bridge =>
            {
                var model = new ServiceOrderSampleDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
            ResearchSamples = entity.ResearchSampleBridges.Select(bridge =>
            {
                var model = new ResearchSampleDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
            ProductionSamples = entity.ProductionSampleBridges.Select(bridge =>
            {
                var model = new ProductionSampleDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();

            if (entity.WorkingGroup != null)
            {
                WorkingGroup = new WorkingGroupDisplayModel();

                WorkingGroup.Import(entity.WorkingGroup);
            }
        }
    }
}
