using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class PropertyLeasePropousalInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.PropertyLeasePropousal, System.Guid>
    {
        public int Priority { get; set; }

        public System.Guid AuthorId { get; set; }

        public string Description { get; set; }

        public System.Guid AgreementId { get; set; }

        public System.Guid PropertyId { get; set; }

        public decimal BaselineAmount { get; set; }

        public System.Guid BaselineCurrencyId { get; set; }

        public List<PropertySpaceLeasePropousalInputModel> IncomingSpaces { get; set; } = new List<PropertySpaceLeasePropousalInputModel>();
        public List<Display.PropertySpaceLeasePropousalDisplayModel> OutgoingSpaces { get; set; } = new List<Display.PropertySpaceLeasePropousalDisplayModel>();

        public override Persistence.Entities.PropertyLeasePropousal Export()
        {
            var entity = new Persistence.Entities.PropertyLeasePropousal { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.PropertyLeasePropousal entity)
        {
            entity.Priority = Priority;
            entity.Description = Description;
            entity.BaselineAmount = BaselineAmount;

            if (entity.AuthorId != AuthorId)
            {
                entity.Author = null;
                entity.AuthorId = AuthorId;
            }

            if (entity.AgreementId != AgreementId)
            {
                entity.Agreement = null;
                entity.AgreementId = AgreementId;
            }

            if (entity.PropertyId != PropertyId)
            {
                entity.Property = null;
                entity.PropertyId = PropertyId;
            }

            if (entity.BaselineCurrencyId != BaselineCurrencyId)
            {
                entity.BaselineCurrency = null;
                entity.BaselineCurrencyId = BaselineCurrencyId;
            }
        }
    }
}
