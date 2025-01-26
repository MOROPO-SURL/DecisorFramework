namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input
{
    public class BankDebitCardInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.BankDebitCard, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]{16}$")]
        public string Number { get; set; }

        public int Priority { get; set; }

        public System.Guid BankAccountId { get; set; }

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
            entity.Number = Number;
            entity.Priority = Priority;
            entity.ExpireOn = ExpireOn;

            if (BankAccountId != entity.BankAccountId)
            {
                entity.BankAccount = null;
                entity.BankAccountId = BankAccountId;
            }
        }
    }
}
