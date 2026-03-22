namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter
{
    public class ProjectFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Project, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Project, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Name.ToLower()) && entity.Alias.ToLower().Contains(entity.Alias.ToLower());
        }
    }
}