namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter
{
    public class ParticipatingOrganizationFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.ParticipatingOrganization, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.ParticipatingOrganization, bool>> GetSelector()
        {
            return entity => entity.Contact.Identity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}
