namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class InternalResearcher : Contract.AbstractResearcher
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(EmployeeId))]
        public Framework.Decisor.Domain.Persistence.Entities.Employee Employee { get; set; }
        public System.Guid EmployeeId { get; set; }
    }
}
