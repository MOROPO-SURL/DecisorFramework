using System.Collections.Generic;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input
{
    public class PurchasePlanInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<PurchasePlan, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public System.DateTime PlannedFor { get; set; }

        public int Priority { get; set; }

        public System.Guid PlannerId { get; set; }

        public System.Guid ResponsibleId { get; set; }

        public System.Guid DecisorId { get; set; }

        public System.Guid ZoneId { get; set; }

        public string Description { get; set; }

        public decimal EstimatedAdvance { get; set; }

        public List<PurchasePlanCommonProductBridgeModel> OutputProductBridges { get; set; } = new List<PurchasePlanCommonProductBridgeModel>();

        public List<PurchasePlanCommonProductBridgeModel> InputProductBridges { get; set; } = new List<PurchasePlanCommonProductBridgeModel>();

        public List<PurchasePlanLegalProviderBridgeModel> LegalProviderBridges { get; set; } = new List<PurchasePlanLegalProviderBridgeModel>();

        public List<PurchasePlanNaturalProviderBridgeModel> NaturalProviderBridges { get; set; } = new List<PurchasePlanNaturalProviderBridgeModel>();

        public PurchasePlan Export()
        {
            var entity = new PurchasePlan { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(PurchasePlan entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(PurchasePlan entity)
        {
            entity.PlannedFor = PlannedFor;
            entity.Priority = Priority;
            entity.Description = Description;
            entity.EstimatedAdvance = EstimatedAdvance;

            if (entity.ZoneId != ZoneId)
            {
                entity.Zone = null;
                entity.ZoneId = ZoneId;
            }
            
            if (entity.PlannerId != PlannerId)
            {
                entity.Planner = null;
                entity.PlannerId = PlannerId;
            }

            if (entity.ResponsibleId != ResponsibleId)
            {
                entity.Responsible = null;
                entity.ResponsibleId = ResponsibleId;
            }

            if (entity.DecisorId != DecisorId)
            {
                entity.Decisor = null;
                entity.DecisorId = DecisorId;
            }
        }
    }
}
