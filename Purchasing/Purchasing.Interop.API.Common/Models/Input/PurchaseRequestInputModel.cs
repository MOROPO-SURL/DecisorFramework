using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input
{
    public class PurchaseRequestInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.PurchaseRequest, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        public System.Guid AuthorId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Argument { get; set; }

        public List<PurchaseRequestExpectedProductAdquisitionInputModel> EditionExpectedProducttAdquisitions { get; set; } = new List<PurchaseRequestExpectedProductAdquisitionInputModel>();
        public List<PurchaseRequestExpectedProductAdquisitionInputModel> IncomingExpectedProducttAdquisitions { get; set; } = new List<PurchaseRequestExpectedProductAdquisitionInputModel>();
        public List<Display.PurchaseRequestExpectedProductAdquisitionDisplayModel> OutgoingExpectedProducttAdquisitions { get; set; } = new List<Display.PurchaseRequestExpectedProductAdquisitionDisplayModel>();

        public Persistence.Entities.PurchaseRequest Export()
        {
            var entity = new Persistence.Entities.PurchaseRequest { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.PurchaseRequest entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.PurchaseRequest entity)
        {
            entity.Priority = Priority;
            entity.Argument = Argument;

            if (entity.AuthorId != AuthorId)
            {
                entity.Author = null;
                entity.AuthorId = AuthorId;
            }
        }
    }
}
