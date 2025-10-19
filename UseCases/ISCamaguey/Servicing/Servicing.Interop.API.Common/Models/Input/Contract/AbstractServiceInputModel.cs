using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractServiceInputModel<TEntity> : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, System.Guid> where TEntity : Persistence.Entities.Contract.AbstractService
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

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
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
