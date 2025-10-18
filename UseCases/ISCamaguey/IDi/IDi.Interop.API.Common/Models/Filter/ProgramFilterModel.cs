namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter
{
    public class ProgramFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.Program, System.Guid>
    {
        public string Name { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Program, bool>> GetSelector()
        {
            return entity => entity.Name.ToLower().Contains(Name.ToLower());
        }
    }
}
