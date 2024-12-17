using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractLegalRelationshipInputModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractLegalRelationship, new()
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public System.DateTime? BornDate { get; set; }

        public string About { get; set; }

        public int Priority { get; set; }

        public ImageInputModel Image { get; set; }

        public List<Core.Interop.API.Common.Models.Display.EmailContactItemDisplayModel> EmailContacts { get; set; }

        public List<Core.Interop.API.Common.Models.Display.PhoneContactItemDisplayModel> PhoneContacts { get; set; }

        public List<Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel> PostalContacts { get; set; }

        public List<Core.Interop.API.Common.Models.Display.WebContactItemDisplayModel> WebContacts { get; set; }

        public System.Guid BusinessKindId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+$")]
        public string TaxIdentificationNumber { get; set; }

        public TEntity Export()
        {
            var entity = new TEntity { Id = Id, Enabled = true, Contact = new Persistence.Entities.OrganizationContact { Identity = new Guama.Identity.Persistence.Entities.OrganizationIdentity() } };

            Mergue(entity);

            return entity;
        }

        public void Import(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TEntity entity)
        {
            entity.Contact.Identity.Name = Name;
            entity.Contact.Identity.BornDate = BornDate;
            entity.Contact.Identity.About = About;
            entity.Priority = Priority;
            entity.TaxIdentificationNumber = TaxIdentificationNumber;

            if (BusinessKindId != entity.Contact.BusinessKindId)
            {
                entity.Contact.BusinessKind = null;
                entity.Contact.BusinessKindId = BusinessKindId;
            }
        }
    }
}

