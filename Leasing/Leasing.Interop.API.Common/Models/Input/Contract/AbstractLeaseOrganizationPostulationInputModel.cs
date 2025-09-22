namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractLeaseOrganizationPostulationInputModel<TEntity> : AbstractLeasePostulationInputModel<TEntity> where TEntity : Persistence.Entities.Contract.AbstractLeaseOrganizationPostulation
    {
        public System.Guid ContactId { get; set; }

        public System.Guid RepresentativeId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string TaxIdentificationNumber { get; set; }

        public string StateIdentificationCode { get; set; }

        public System.Guid MainPostalContactItemId { get; set; }

        public override void Mergue(TEntity entity)
        {
            base.Mergue(entity);

            if (entity.ContactId != ContactId)
            {
                entity.Contact = null;
                entity.ContactId = ContactId;
            }
        }
    }
}
