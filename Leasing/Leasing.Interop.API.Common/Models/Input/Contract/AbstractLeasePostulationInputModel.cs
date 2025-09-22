using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractLeasePostulationInputModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractLeasePostulation
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Argument { get; set; }

        public System.Guid BankAccountId { get; set; }

        public List<DocumentInputModel> EditionDocuments { get; set; } = new List<DocumentInputModel>();
        public List<DocumentInputModel> IncomingDocuments { get; set; } = new List<DocumentInputModel>();
        public List<DocumentDisplayModel> OutgoingDocuments { get; set; } = new List<DocumentDisplayModel>();

        public abstract TEntity Export();

        public void Import(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TEntity entity)
        {
            entity.Argument = Argument;

            if (entity.BankAccountId != BankAccountId)
            {
                entity.BankAccount = null;
                entity.BankAccountId = BankAccountId;
            }
        }
    }
}
