namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter
{
    public class InternalResearcherFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.InternalResearcher, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.InternalResearcher, bool>> GetSelector()
        {
            return entity => entity.Employee.Contact.Identity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}