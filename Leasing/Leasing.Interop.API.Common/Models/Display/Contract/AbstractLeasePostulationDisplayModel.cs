namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractLeasePostulationDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractLeasePostulation
    {
        public System.Guid Id { get; set; }

        public System.Guid OfferId { get; set; }

        public string Argument { get; set; }

        public Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel BankAccount { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel[] Documents { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            Argument = entity.Argument;

            if (entity.BankAccount != null)
            {
                BankAccount = new Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel();

                BankAccount.Import(entity.BankAccount);
            }
        }
    }
}
