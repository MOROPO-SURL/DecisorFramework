namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Filter
{
    public class WorkingGroupFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.WorkingGroup, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.WorkingGroup, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}
