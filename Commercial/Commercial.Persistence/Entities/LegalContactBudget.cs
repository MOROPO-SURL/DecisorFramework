namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class LegalContactBudget : Contract.AbstractBudget
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public LegalContact Contact { get; set; }
        public System.Guid? ContactId { get; set; }
    }
}

