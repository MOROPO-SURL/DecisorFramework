namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Filter
{
    public class CubanStandardFilterModel: Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.CubanStandard, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.CubanStandard, bool>> GetSelector()
        {
            return entity => entity.Index.ToString().Contains(Parameter) || entity.Name.ToLower().Contains(Parameter.ToLower());
        }
    }
}
