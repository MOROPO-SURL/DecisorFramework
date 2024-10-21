using MOROPO.Framework.Decisor.Purchasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Input
{
    public class PurchaseSpentInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<PurchaseSpent, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public PurchaseSpent Export()
        {
            var entity = new PurchaseSpent
            {
                Id = Id,
                Enabled = true
            };

            Mergue(entity);

            return entity;
        }

        public void Import(PurchaseSpent entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(PurchaseSpent entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
