namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input
{
    public class BankAccountInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.BankAccount, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.Guid BranchId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string Number { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Holder { get; set; }

        public System.Guid CurrencyId { get; set; }

        public bool IsExternal { get; set; }

        public Persistence.Entities.BankAccount Export()
        {
            var entity = new Persistence.Entities.BankAccount { Id = Id, Enabled = true, External = IsExternal };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.BankAccount entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.BankAccount entity)
        {
            entity.Priority = Priority;
            entity.Number = Number;
            entity.Holder = Holder;

            if (entity.BranchId != BranchId)
            {
                entity.Branch = null;
                entity.BranchId = BranchId;
            }

            if (entity.CurrencyId != CurrencyId) 
            {
                entity.Currency = null;
                entity.CurrencyId = CurrencyId;
            }
        }
    }
}
