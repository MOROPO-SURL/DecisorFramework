namespace MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Filter
{
    public class TechniqueFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Technique, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Technique, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}
