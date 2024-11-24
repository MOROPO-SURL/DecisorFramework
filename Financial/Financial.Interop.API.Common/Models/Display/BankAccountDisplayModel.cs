namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display
{
    public class BankAccountDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.BankAccount, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public BankBranchDisplayModel Branch { get; set; }

        public string Number { get; set; }

        public string Holder { get; set; }

        public CurrencyDisplayModel Currency { get; set; }

        public void Import(Persistence.Entities.BankAccount entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            At = entity.At;
            Number = entity.Number;
            Holder = entity.Holder;

            if (entity.Branch != null)
            {
                Branch = new BankBranchDisplayModel();

                Branch.Import(entity.Branch);
            }

            if (entity.Currency != null)
            {
                Currency = new CurrencyDisplayModel();

                Currency.Import(entity.Currency);
            }
        }
    }
}
