namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter
{
    public class NaturalClientServicingContractFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.NaturalClientServicingContract, System.Guid>
    {
        public System.Guid ClientId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.NaturalClientServicingContract, bool>> GetSelector()
        {
            return entity => entity.ServicingNaturalClientId == ClientId;
        }
    }
}
