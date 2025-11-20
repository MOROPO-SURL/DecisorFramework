using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input
{
    public class LegalProviderBudgetInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.LegalProviderBudget, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Number { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public System.Guid CommercialId { get; set; }

        public System.Guid ProviderId { get; set; }

        public List<LegalProviderBudgetProductInputModel> EditionBudgetProducts { get; set; } = new List<LegalProviderBudgetProductInputModel>();
        public List<LegalProviderBudgetProductInputModel> IncomingBudgetProducts { get; set; } = new List<LegalProviderBudgetProductInputModel>();
        public List<Display.LegalProviderBudgetProductDisplayModel> OutgoingBudgetProducts { get; set; } = new List<Display.LegalProviderBudgetProductDisplayModel>();

        public Core.Interop.API.Common.Models.Input.DocumentInputModel Document { get; set; }

        public Persistence.Entities.LegalProviderBudget Export()
        {
            var entity = new Persistence.Entities.LegalProviderBudget { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.LegalProviderBudget entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.LegalProviderBudget entity)
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
