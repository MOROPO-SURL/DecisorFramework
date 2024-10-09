using System.Linq;

namespace MOROPO.Framework.Decisor.Core.Web.API.Common.Models.Display.Contract
{
	public abstract class AbstractNaturalRelationshipDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid>
		where TEntity : Persistence.Entities.Contract.AbstractNaturalRelationship
	{
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public string Name { get; set; }

        public System.DateTime? BornDate { get; set; }

        public string About { get; set; }

        public ImageDisplayModel Image { get; set; }

        public EmailContactItemDisplayModel[] EmailContacts { get; set; }

        public PhoneContactItemDisplayModel[] PhoneContacts { get; set; }

        public PostalContactItemDisplayModel[] PostalContacts { get; set; }

        public WebContactItemDisplayModel[] WebContacts { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public string LastName { get; set; }

        public string Alias { get; set; }

        public Guama.Identity.Persistence.Enumerations.Sex Sex { get; set; }

        public Guama.Identity.Persistence.Enumerations.CivilStatus CivilStatus { get; set; }

        public string PersonalIdentificationNumber { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            Name = entity.Identity.Name;
            BornDate = entity.Identity.BornDate;
            About = entity.Identity.About;
            Priority = entity.Priority;
            LastName = entity.Identity.LastName;
            Alias = entity.Identity.Alias;
            Sex = entity.Identity.Sex;
            CivilStatus = entity.Identity.CivilStatus;
            At = entity.At;
            PersonalIdentificationNumber = entity.PersonalIdentificationNumber;

            if (entity.Identity.Image != null)
            {
                Image = new ImageDisplayModel();

                Image.Import(entity.Identity.Image);
            }

            EmailContacts = entity.Identity.EmailContactItemBridges.Select(bridge =>
            {
                var model = new EmailContactItemDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
            PhoneContacts = entity.Identity.PhoneContactItemBridges.Select(bridge =>
            {
                var model = new PhoneContactItemDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
            WebContacts = entity.Identity.WebSiteContactItemBridges.Select(bridge =>
            {
                var model = new WebContactItemDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
            PostalContacts = entity.Identity.PostalContactItemBridges.Select(bridge =>
            {
                var model = new PostalContactItemDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
        }
    }
}

