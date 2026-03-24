namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter
{
    public class SalaryStandardFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.SalaryStandard, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.SalaryStandard, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Parameter.ToLower());
        }
    }
}
