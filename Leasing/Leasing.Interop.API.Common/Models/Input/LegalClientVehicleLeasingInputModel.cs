using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class LegalClientVehicleLeasingInputModel : Contract.AbstractLeasingInputModel<Persistence.Entities.LegalClientVehicleLeasing>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string OperativeLicenceCode { get; set; }

        public List<DriveLicenceInputModel> IncomingDriveLicences { get; set; } = new List<DriveLicenceInputModel>();

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
        }
    }
}
