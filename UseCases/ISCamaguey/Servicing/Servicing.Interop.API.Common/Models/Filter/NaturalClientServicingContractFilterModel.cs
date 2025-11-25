namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Filter
{
    public class NaturalClientServicingContractFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.NaturalClientServicingContract, System.Guid>
    {
        public System.Guid? ClientId { get; set; }

        public string ClientParam { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.NaturalClientServicingContract, bool>> GetSelector()
        {
            if (ClientId != null)
            {
                if (!string.IsNullOrEmpty(ClientParam))
                {
                    return entity => entity.ServicingNaturalClientId == ClientId && (entity.Client.Contact.Identity.Name.ToLower().Contains(ClientParam.ToLower()) || entity.Client.Contact.Identity.LastName.ToLower().Contains(ClientParam.ToLower()));
                }

                return entity => entity.ServicingNaturalClientId == ClientId;
            }

            if (!string.IsNullOrEmpty(ClientParam))
            {
                return entity => entity.Client.Contact.Identity.Name.ToLower().Contains(ClientParam.ToLower()) || entity.Client.Contact.Identity.LastName.ToLower().Contains(ClientParam.ToLower());
            }

            throw new System.InvalidOperationException();
        }
    }
}
