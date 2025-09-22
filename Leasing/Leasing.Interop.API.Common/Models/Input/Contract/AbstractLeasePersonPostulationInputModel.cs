namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractLeasePersonPostulationInputModel<TEntity> : AbstractLeasePostulationInputModel<TEntity> where TEntity : Persistence.Entities.Contract.AbstractLeasePersonPostulation
    {
        public System.Guid ContactId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string TaxIdentificationNumber { get; set; }

        public System.Guid BusinessKindId { get; set; }

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
