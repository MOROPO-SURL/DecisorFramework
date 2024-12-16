using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input.Contract
{
    public class AbstractNaturalRelationshipInputModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractNaturalRelationship, new()
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string About { get; set; }

        public int Priority { get; set; }

        public ImageInputModel Image { get; set; }

        public List<Core.Interop.API.Common.Models.Display.EmailContactItemDisplayModel> EmailContacts { get; set; }

        public List<Core.Interop.API.Common.Models.Display.PhoneContactItemDisplayModel> PhoneContacts { get; set; }

        public List<Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel> PostalContacts { get; set; }

        public List<Core.Interop.API.Common.Models.Display.WebContactItemDisplayModel> WebContacts { get; set; }

        public string LastName { get; set; }

        public string Alias { get; set; }

        public Guama.Identity.Persistence.Enumerations.Sex Sex { get; set; }

        public Guama.Identity.Persistence.Enumerations.CivilStatus CivilStatus { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]{11}$")]
        public string PersonalIdentificationNumber { get; set; }

        public TEntity Export()
        {
            var entity = new TEntity { Id = Id, Enabled = true, Contact = new Persistence.Entities.NaturalContact { Identity = new Guama.Identity.Persistence.Entities.PersonIdentity() } };

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
            entity.Contact.Identity.About = About;
            entity.Priority = Priority;
            entity.Contact.Identity.LastName = LastName;
            entity.Contact.Identity.Alias = Alias;
            entity.Contact.Identity.Sex = Sex;
            entity.Contact.Identity.CivilStatus = CivilStatus;
            entity.PersonalIdentificationNumber = PersonalIdentificationNumber;
        }
    }
}

