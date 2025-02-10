namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display
{
    public class PaymentTermDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PaymentTerm, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public string Name { get; set; }

        public int Term { get; set; }

        public virtual void Import(Persistence.Entities.PaymentTerm entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            At = entity.At;
            Name = entity.Name;
            Term = entity.Term;
        }
    }
}
