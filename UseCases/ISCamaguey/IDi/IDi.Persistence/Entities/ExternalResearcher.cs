namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class ExternalResearcher : Contract.AbstractResearcher
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public Framework.Decisor.Domain.Persistence.Entities.PersonContact Contact { get; set; }
        public System.Guid ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ParticipatingOrganizationId))]
        public ParticipatingOrganization ParticipatingOrganization { get; set; }
        public System.Guid ParticipatingOrganizationId { get; set; }

        public decimal Salary { get; set; }
    }
}
