using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input.Contract
{
    public class AbstractNaturalRelationshipInputModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractNaturalRelationship, new()
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.Guid ContactId { get; set; }

        public System.Guid? BusinessKindId { get; set; }

        public string PersonalIdentificationNumber { get; set; }

        public System.Guid MainPostalContactId { get; set; }

        public System.Guid DefaultPaymentTermId { get; set; }

        public List<BankAccountInputModel> EditionBankAccounts { get; set; } = new List<BankAccountInputModel>();
        public List<BankAccountInputModel> IncomingBankAccounts { get; set; } = new List<BankAccountInputModel>();
        public List<BankAccountDisplayModel> OutgoingBankAccounts { get; set; } = new List<BankAccountDisplayModel>();

        public List<DocumentInputModel> EditionDocuments { get; set; } = new List<DocumentInputModel>();
        public List<DocumentInputModel> IncomingDocuments { get; set; } = new List<DocumentInputModel>();
        public List<DocumentDisplayModel> OutgoingDocuments { get; set; } = new List<DocumentDisplayModel>();

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

            if (DefaultPaymentTermId != entity.DefaultPaymentTermId)
            {
                entity.DefaultPaymentTerm = null;
                entity.DefaultPaymentTermId = DefaultPaymentTermId;
            }
        }
    }
}

