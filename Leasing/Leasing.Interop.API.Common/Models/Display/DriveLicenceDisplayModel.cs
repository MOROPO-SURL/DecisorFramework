namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class DriveLicenceDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.DriveLicence, System.Guid>
    {
        public System.Guid Id { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get; set; }

        public string Code { get; set; } // Number

        public string Reference { get; set; } // Document id (reverso ej: C577490)

        public System.DateTime ReleasedAt { get; set; }

        public System.DateTime ExpireAt { get; set; }

        public string Limitation { get; set; }

        public Bridge.Display.DriveLicenceVehicleKindBridgeDisplayModel[] VehicleKindBridges { get; set; }

        public void Import(Persistence.Entities.DriveLicence entity)
        {
            Id = entity.Id;
            Code = entity.Code;
            Reference = entity.Reference;
            ReleasedAt = entity.ReleasedAt;
            ExpireAt = entity.ExpireAt;
            Limitation = entity.Limitation;

            if (entity.Contact != null)
            {
                Contact = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                Contact.Import(entity.Contact);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DriveLicenceDisplayModel)) return false;

            return Id.Equals(((DriveLicenceDisplayModel)obj).Id);
        }
    }
}
