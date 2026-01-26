using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class DriveLicenceInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.DriveLicence, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        public string Code { get; set; } // Number

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        public string Reference { get; set; } // Document id (reverso ej: C577490)

        public System.DateTime ReleasedAt { get; set; }

        public System.DateTime ExpireAt { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(100)]
        public string Limitation { get; set; }

        public Bridge.Input.DriveLicenceVehicleKindBridgeInputModel[] VehicleKindBridges { get; set; }

        public Persistence.Entities.DriveLicence Export()
        {
            var entity = new Persistence.Entities.DriveLicence { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.DriveLicence entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.DriveLicence entity)
        {
            entity.Code = Code;
            entity.Reference = Reference;
            entity.ReleasedAt = ReleasedAt;
            entity.ExpireAt = ExpireAt;
            entity.Limitation = Limitation;

            if (entity.ContactId != ContactId)
            {
                entity.Contact = null;
                entity.ContactId = ContactId;
            }

            entity.VehicleKindBridges.Clear();

            entity.VehicleKindBridges = VehicleKindBridges.Select(item => new Persistence.Entities.DriveLicenceVehicleKindBridge
            {
                ProwId = entity.Id,
                SternId = item.SternId,
                Category = item.Category,
                Specification = item.Specification,
                AchievedAt = item.AchievedAt
            }).ToList();
        }
    }
}
