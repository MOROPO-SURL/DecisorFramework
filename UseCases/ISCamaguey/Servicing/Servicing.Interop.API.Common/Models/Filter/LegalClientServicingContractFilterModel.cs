namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter
{
    public class LegalClientServicingContractFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.LegalClientServicingContract, int>
    {
        public System.Guid ClientId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.LegalClientServicingContract, bool>> GetSelector()
        {
            return entity => entity.ServicingLegalClientId == ClientId;
        }
    }
}