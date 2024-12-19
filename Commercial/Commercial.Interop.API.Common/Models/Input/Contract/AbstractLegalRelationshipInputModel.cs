namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractLegalRelationshipInputModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractLegalRelationship, new()
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.Guid ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string TaxIdentificationNumber { get; set; }

        public TEntity Export()
        {
            var entity = new TEntity { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TEntity entity)
        {
            entity.Priority = Priority;
            entity.TaxIdentificationNumber = TaxIdentificationNumber;

            if (ContactId != entity.ContactId)
            {
                entity.Contact = null;
                entity.ContactId = ContactId;
            }
        }
    }
}

