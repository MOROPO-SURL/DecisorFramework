namespace MOROPO.Framework.Decisor.Leasing.Persistence.Entities
{
    public class LegalClientVehicleLeaseContract : Contract.AbstractLeaseContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VehicleLeaseLegalPostulationId))]
        public VehicleLeaseOrganizationPostulation Postulation { get; set; }
        public System.Guid? VehicleLeaseLegalPostulationId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VehicleLeaseLegalClientId))]
        public Commercial.Persistence.Entities.LegalClient Client { get; set; }
        public System.Guid? VehicleLeaseLegalClientId { get; set; }
    }
}
