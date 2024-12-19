namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractLegalRelationshipDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractLegalRelationship
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public OrganizationContactDisplayModel Contact { get; set; }

        public string TaxIdentificationNumber { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            At = entity.At;
            TaxIdentificationNumber = entity.TaxIdentificationNumber;

            if (entity.Contact != null)
            {
                Contact = new OrganizationContactDisplayModel();

                Contact.Import(entity.Contact);
            }
        }

        public override string ToString()
        {
            return Contact?.ToString();
        }
    }
}

