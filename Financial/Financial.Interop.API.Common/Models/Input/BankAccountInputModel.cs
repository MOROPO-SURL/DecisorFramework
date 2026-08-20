namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input
{
    public class BankAccountInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.BankAccount, System.Guid>
    {
        public int Priority { get; set; }

        public System.Guid BranchId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string Number { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Holder { get; set; }

        public System.Guid CurrencyId { get; set; }

        public bool IsExternal { get; set; }

        public override Persistence.Entities.BankAccount Export()
        {
            var entity = new Persistence.Entities.BankAccount { Id = Id, Enabled = true, External = IsExternal };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.BankAccount entity)
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
