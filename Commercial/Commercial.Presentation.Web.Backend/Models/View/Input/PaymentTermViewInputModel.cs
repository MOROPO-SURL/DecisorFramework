using MOROPO.Framework.Decisor.Commercial.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Models.View.Input
{
    public class PaymentTermViewInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<PaymentTerm, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Term { get; set; }

        public PaymentTerm Export()
        {
            var entity = new PaymentTerm { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(PaymentTerm entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            Name = entity.Name;
            Term = entity.Term;
        }

        public void Mergue(PaymentTerm entity)
        {
            entity.Name = Name;
            entity.Term = Term;
            entity.Priority = Priority;
        }
    }
}
