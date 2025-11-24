namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter
{
    public class LegalClientServicingContractFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.LegalClientServicingContract, System.Guid>
    {
        public System.Guid? ClientId { get; set; }

        public string ClientName { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.LegalClientServicingContract, bool>> GetSelector()
        {
            if (ClientId != null)
            {
                if (!string.IsNullOrEmpty(ClientName))
                {
                    return entity => entity.ServicingLegalClientId == ClientId && entity.Client.Contact.Identity.Name.ToLower().Contains(ClientName.ToLower());
                }

                return entity => entity.ServicingLegalClientId == ClientId;
            }

            if (!string.IsNullOrEmpty(ClientName))
            {
                return entity => entity.Client.Contact.Identity.Name.ToLower().Contains(ClientName.ToLower());
            }

            throw new System.InvalidOperationException();
        }
    }
}