namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractLeaseOrganizationPostulationInputModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractLeaseOrganizationPostulation
    {
        public System.Guid Id { get; set; }

        public System.Guid ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string TaxIdentificationNumber { get; set; }

        public string StateIdentificationCode { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Argument { get; set; }

        public abstract TEntity Export();

        public void Import(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TEntity entity)
        {
            entity.TaxIdentificationNumber = TaxIdentificationNumber;
            entity.StateIdentificationCode = StateIdentificationCode;
            entity.Argument = Argument;

            if (entity.ContactId != ContactId)
            {
                entity.Contact = null;
                entity.ContactId = ContactId;
            }
        }
    }
}
