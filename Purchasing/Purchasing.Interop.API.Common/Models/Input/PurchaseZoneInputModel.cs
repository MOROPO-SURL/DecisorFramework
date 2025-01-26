using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Bridge;
using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input
{
    public class PurchaseZoneInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<PurchaseZone, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public List<PurchaseZoneSpentBridgeModel> SpentBridges { get; set; } = new List<PurchaseZoneSpentBridgeModel>();

        public PurchaseZone Export()
        {
            var entity = new PurchaseZone
            {
                Id = Id,
                Enabled = true
            };

            Mergue(entity);

            return entity;
        }

        public void Import(PurchaseZone entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(PurchaseZone entity)
        {
            entity.Name = Name;
            entity.Priority = Priority;
            entity.Description = Description;
        }
    }
}
