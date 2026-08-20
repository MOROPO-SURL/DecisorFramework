using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class StaffInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.Staff, System.Guid>
    {
        public System.Guid StructureId { get; set; }

        public System.Guid MainWorkforceId { get; set; }

        [System.ComponentModel.DataAnnotations.Range(1, 44)]
        public int WorkingWeekHourCount { get; set; } = 44;

        public float DoctorateExtraFeed { get; set; }

        public float MasteryExtraFeed { get; set; }

        public Bridge.AlternativeWorkforceBridgeModel[] AlternativeWorkforces { get; set; }

        public override Persistence.Entities.Staff Export()
        {
            var entity = new Persistence.Entities.Staff { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.Staff entity)
        {
            entity.WorkingWeekHourCount = WorkingWeekHourCount;
            entity.DoctorateExtraFeed = DoctorateExtraFeed;
            entity.MasteryExtraFeed = MasteryExtraFeed;

            entity.AlternativeWorkforceBridges = AlternativeWorkforces.Select(model => new Persistence.Entities.StaffWorkforceBridge
            {
                ProwId = entity.Id,
                SternId = model.Workforce.Id,
                Title = model.Title,
                Description = model.Description
            }).ToList();

            if (entity.AdministrativeEntityId != StructureId)
            {
                entity.AdministrativeEntity = null;
                entity.AdministrativeEntityId = StructureId;
            }

            if (entity.MainWorkforceId != MainWorkforceId)
            {
                entity.MainWorkforce = null;
                entity.MainWorkforceId = MainWorkforceId;
            }
        }
    }
}
