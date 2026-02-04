using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class PropertyLeaseOfferDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PropertyLeaseOffer, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public System.DateTime OpenAt { get; set; }

        public System.DateTime? ClosedAt { get; set; }

        public string Description { get; set; }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get; set; }

        public PropertyLeasePropousalDisplayModel Propousal { get; set; }

        public decimal BaselineAmount { get; set; }

        public Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel BaselineCurrency { get; set; }

        public PropertyLeaseOrganizationPostulationDisplayModel[] OrganizationPostulations { get; set; }

        public PropertyLeasePersonPostulationDisplayModel[] PersonPostulations { get; set; }

        public void Import(Persistence.Entities.PropertyLeaseOffer entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            At = entity.At;
            OpenAt = entity.OpenAt;
            ClosedAt = entity.ClosedAt;
            Description = entity.Description;
            BaselineAmount = entity.BaselineAmount;

            if (entity.Agreement != null)
            {
                Agreement = new Governance.Interop.API.Common.Models.Display.AgreementDisplayModel();

                Agreement.Import(entity.Agreement);
            }

            if (entity.Propousal != null)
            {
                Propousal = new PropertyLeasePropousalDisplayModel();

                Propousal.Import(entity.Propousal);
            }

            if (entity.BaselineCurrency != null)
            {
                BaselineCurrency = new Financial.Interop.API.Common.Models.Display.CurrencyDisplayModel();

                BaselineCurrency.Import(entity.BaselineCurrency);
            }
        }
    }
}
