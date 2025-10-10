using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class LegalClientVehicleLeasingInputModel : Contract.AbstractLeasingInputModel<Persistence.Entities.LegalClientVehicleLeasing>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string OperativeLicenceCode { get; set; }

        public override Persistence.Entities.LegalClientVehicleLeasing Export()
        {
            var entity = new Persistence.Entities.LegalClientVehicleLeasing { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.LegalClientVehicleLeasing entity)
        {
            base.Mergue(entity);

            entity.OperativeLicenceCode = OperativeLicenceCode;

            entity.ContactBridges.Clear();

            entity.ContactBridges = Contacts.Select(model => new Persistence.Entities.LegalClientVehicleLeasingPersonContactBridge
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();
        }
    }
}
