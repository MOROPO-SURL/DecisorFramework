namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter
{
    public class EmployeeFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Employee, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Employee, bool>> GetSelector()
        {
            return entity => entity.Contact.Identity.Name.ToLower().Contains(Parameter.ToLower()) || entity.Contact.Identity.LastName.ToLower().Contains(Parameter.ToLower());
        }
    }
}