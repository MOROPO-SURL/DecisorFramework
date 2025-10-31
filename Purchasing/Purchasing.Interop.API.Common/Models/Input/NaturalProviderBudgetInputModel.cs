namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input
{
    public class NaturalProviderBudgetInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.NaturalProviderBudget, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Number { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public System.Guid CommercialId { get; set; }

        public System.Guid ProviderId { get; set; }

        public System.Collections.Generic.List<Bridge.CommonBugetProductBridgeModel> ProductBridges { get; set; } = new System.Collections.Generic.List<Bridge.CommonBugetProductBridgeModel>();

        public Core.Interop.API.Common.Models.Input.DocumentInputModel Document { get; set; }

        public Persistence.Entities.NaturalProviderBudget Export()
        {
            var entity = new Persistence.Entities.NaturalProviderBudget { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.NaturalProviderBudget entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.NaturalProviderBudget entity)
        {
            entity.Number = Number;
            entity.Year = Year;
            entity.Description = Description;

            if (entity.ProviderId != ProviderId)
            {
                entity.Provider = null;
                entity.ProviderId = ProviderId;
            }

            if (entity.CommercialId != CommercialId)
            {
                entity.Commercial = null;
                entity.CommercialId = CommercialId;
            }
        }
    }
}
