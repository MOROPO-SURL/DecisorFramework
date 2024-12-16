namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities
{
    public class NaturalContactBudget : Contract.AbstractBudget
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContactId))]
        public NaturalContact Contact { get; set; }
        public System.Guid? ContactId { get; set; }
    }
}