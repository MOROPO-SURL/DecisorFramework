namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Filter.Contract
{
    public abstract class AbstractServiceFilterModel<TService> : Guama.Core.Persistence.Presentation.Models.Filter.Contract.AbstractNamedEntityFilterModel<TService, System.Guid>
        where TService : Persistence.Entities.Contract.AbstractService
    {
    }
}
