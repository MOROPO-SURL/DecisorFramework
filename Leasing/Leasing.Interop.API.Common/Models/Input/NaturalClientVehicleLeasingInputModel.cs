using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class NaturalClientVehicleLeasingInputModel : Contract.AbstractLeasingInputModel<Persistence.Entities.NaturalClientVehicleLeasing>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string OperativeLicenceCode { get; set; }

        public List<DriveLicenceInputModel> IncomingDriveLicences { get; set; } = new List<DriveLicenceInputModel>();

        public override Persistence.Entities.NaturalClientVehicleLeasing Export()
        {
            var entity = new Persistence.Entities.NaturalClientVehicleLeasing { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.NaturalClientVehicleLeasing entity)
        {
            base.Mergue(entity);

            entity.OperativeLicenceCode = OperativeLicenceCode;
        }
    }
}
