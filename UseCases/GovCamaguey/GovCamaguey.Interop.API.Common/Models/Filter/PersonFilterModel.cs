namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Filter
{
    public sealed class PersonFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Person, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Person, bool>> GetSelector()
        {
            return entity => entity.Identity.Name.ToLower().Contains(Parameter.ToLower()) || entity.Identity.LastName.ToLower().Contains(Parameter.ToLower());
        }
    }
}
