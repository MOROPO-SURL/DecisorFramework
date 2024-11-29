namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Filter
{
    public class BankAccountFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.BankAccount, System.Guid>
    {
        public bool IsExternal { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.BankAccount, bool>> GetSelector()
        {
            return entity => entity.External == IsExternal;
        }
    }
}
