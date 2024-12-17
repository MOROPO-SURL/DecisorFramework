namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class OrganizationContactBudget : Contract.AbstractBudget
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public OrganizationContact Contact { get; set; }
        public System.Guid? ContactId { get; set; }
    }
}

