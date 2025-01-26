namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class NamingResolution : Legal.Persistence.Entities.Contract.AbstractResolution
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(NamedEmployeeId))]
        public Employee NamedEmployee { get; set; }
        public System.Guid NamedEmployeeId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(VacantId))]
        public Vacant Vacant { get; set; }
        public System.Guid VacantId { get; set; }
    }
}
