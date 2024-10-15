using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input.Contract
{
	public class AbstractNaturalRelationshipInputModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractNaturalRelationship, new()
	{
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public System.DateTime? BornDate { get; set; }

        public string About { get; set; }

        public int Priority { get; set; }

        public ImageInputModel Image { get; set; }

        public List<Display.EmailContactItemDisplayModel> EmailContacts { get; set; }

        public List<Display.PhoneContactItemDisplayModel> PhoneContacts { get; set; }

        public List<Display.PostalContactItemDisplayModel> PostalContacts { get; set; }

        public List<Display.WebContactItemDisplayModel> WebContacts { get; set; }

        public string LastName { get; set; }

		public Guama.Identity.Persistence.Enumerations.Sex Sex { get; set; }

        public Guama.Identity.Persistence.Enumerations.CivilStatus CivilStatus { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]{11}$")]
        public string PersonalIdentificationNumber { get; set; }

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
            entity.Identity.Name = Name;
            entity.Identity.BornDate = BornDate;
            entity.Identity.About = About;
            entity.Priority = Priority;
            entity.Identity.LastName = LastName;
            entity.Identity.Sex = Sex;
            entity.Identity.CivilStatus = CivilStatus;
            entity.PersonalIdentificationNumber = PersonalIdentificationNumber;
        }
    }
}

