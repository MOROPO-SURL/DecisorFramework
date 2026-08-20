namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Filter
{
    public class BankBranchFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.BankBranch, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.BankBranch, bool>> GetSelector()
        {
            return entity => entity.Number.ToString().Contains(Parameter) || entity.Agency.Name.ToLower().Contains(Parameter.ToLower());
        }
    }
}
