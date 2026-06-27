namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Filter
{
    public sealed class OrganizationFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Organization, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Organization, bool>> GetSelector()
        {
            return entity => entity.Identity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}
