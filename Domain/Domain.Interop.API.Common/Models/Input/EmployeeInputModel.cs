namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class EmployeeInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Employee, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.Guid ContactId { get; set; }

        public Persistence.Entities.Employee Export()
        {
            var entity = new Persistence.Entities.Employee { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(Persistence.Entities.Employee entity)
        {
            if (entity.ContactId != ContactId)
            {
                entity.Contact = null;
                entity.ContactId = ContactId;
            }
        }
    }
}
