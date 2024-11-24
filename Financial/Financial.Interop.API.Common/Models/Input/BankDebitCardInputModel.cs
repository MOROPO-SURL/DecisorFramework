namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input
{
    public class BankDebitCardInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.BankDebitCard, string>
    {
        [System.ComponentModel.DataAnnotations.RegularExpression("{0-9}*16")]
        public string Id { get; set; }

        public int Priority { get; set; }

        public BankAccountInputModel BankAccount { get; set; }

        public System.DateTime ExpireOn { get; set; }

        public Persistence.Entities.BankDebitCard Export()
        {
            var entity = new Persistence.Entities.BankDebitCard { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.BankDebitCard entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.BankDebitCard entity)
        {
            entity.Priority = Priority;
            entity.ExpireOn = ExpireOn;
        }
    }
}
