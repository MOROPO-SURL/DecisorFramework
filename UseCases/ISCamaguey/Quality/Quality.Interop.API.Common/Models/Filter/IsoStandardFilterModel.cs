namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Filter
{
    public class IsoStandardFilterModel: Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.IsoStandard, System.Guid>
    {
        public string Parameter { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.IsoStandard, bool>> GetSelector()
        {
            return entity => entity.Index.ToString().Contains(Parameter) || entity.Name.ToLower().Contains(Parameter.ToLower());
        }
    }
}
