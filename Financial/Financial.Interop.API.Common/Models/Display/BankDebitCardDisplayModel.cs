namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display
{
    public class BankDebitCardDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.BankDebitCard, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public string Number { get; set; }

        public BankAccountDisplayModel BankAccount { get; set; }

        public System.DateTime ExpireOn { get; set; }

        public void Import(Persistence.Entities.BankDebitCard entity)
        {
            Id = entity.Id;
            Number = entity.Number;
            Priority = entity.Priority;
            At = entity.At;
            ExpireOn = entity.ExpireOn;

            if (entity.BankAccount != null)
            {
                BankAccount = new BankAccountDisplayModel();

                BankAccount.Import(entity.BankAccount);
            }
        }
    }
}
