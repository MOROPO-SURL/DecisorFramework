namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class PersonContactBudget : Contract.AbstractBudget
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public PersonContact Contact { get; set; }
        public System.Guid? ContactId { get; set; }
    }
}