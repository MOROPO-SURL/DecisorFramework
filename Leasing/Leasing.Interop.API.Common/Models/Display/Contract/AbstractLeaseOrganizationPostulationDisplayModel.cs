namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractLeaseOrganizationPostulationDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractLeaseOrganizationPostulation
    {
        public System.Guid Id { get; set; }

        public System.Guid OfferId { get; set; }

        public Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get; set; }

        public string TaxIdentificationNumber { get; set; }

        public string StateIdentificationCode { get; set; }

        public string Argument { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            TaxIdentificationNumber = entity.TaxIdentificationNumber;
            StateIdentificationCode = entity.StateIdentificationCode;
            Argument = entity.Argument;

            if (entity.Contact != null)
            {
                Contact = new Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel();

                Contact.Import(entity.Contact);
            }
        }
    }
}
