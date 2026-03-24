using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class PersonContactInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<PersonContact, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string About { get; set; }

        public int Priority { get; set; }

        public ImageInputModel Image { get; set; }

        public string LastName { get; set; }

        public string Alias { get; set; }

        public Guama.Identity.Persistence.Enumerations.Sex Sex { get; set; }

        public Guama.Identity.Persistence.Enumerations.CivilStatus CivilStatus { get; set; }

        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]{11}$")]
        public string PersonalIdentificationNumber { get; set; }

        public Persistence.Enumerations.PersonSkinKind SkinKind { get; set; }

        public string UserId { get; set; }

        public List<PostalContactItemInputModel> EditionPostalContactItems { get; set; } = new List<PostalContactItemInputModel>();
        public List<PostalContactItemInputModel> IncomingPostalContactItems { get; set; } = new List<PostalContactItemInputModel>();
        public List<PostalContactItemDisplayModel> OutgoingPostalContactItems { get; set; } = new List<PostalContactItemDisplayModel>();

        public List<PhoneContactItemInputModel> EditionPhoneContactItems { get; set; } = new List<PhoneContactItemInputModel>();
        public List<PhoneContactItemInputModel> IncomingPhoneContactItems { get; set; } = new List<PhoneContactItemInputModel>();
        public List<PhoneContactItemDisplayModel> OutgoingPhoneContactItems { get; set; } = new List<PhoneContactItemDisplayModel>();

        public List<EmailContactItemInputModel> EditionEmailContactItems { get; set; } = new List<EmailContactItemInputModel>();
        public List<EmailContactItemInputModel> IncomingEmailContactItems { get; set; } = new List<EmailContactItemInputModel>();
        public List<EmailContactItemDisplayModel> OutgoingEmailContactItems { get; set; } = new List<EmailContactItemDisplayModel>();

        public List<WebContactItemInputModel> EditionWebContactItems { get; set; } = new List<WebContactItemInputModel>();
        public List<WebContactItemInputModel> IncomingWebContactItems { get; set; } = new List<WebContactItemInputModel>();
        public List<WebContactItemDisplayModel> OutgoingWebContactItems { get; set; } = new List<WebContactItemDisplayModel>();

        public List<AcademicAchievementInputModel> EditionAcademicAchievements { get; set; } = new List<AcademicAchievementInputModel>();
        public List<AcademicAchievementInputModel> IncomingAcademicAchievements { get; set; } = new List<AcademicAchievementInputModel>();
        public List<AcademicAchievementDisplayModel> OutgoingAcademicAchievements { get; set; } = new List<AcademicAchievementDisplayModel>();

        public override PersonContact Export()
        {
            var entity = new PersonContact { Id = Id, Enabled = true, Identity = new Guama.Identity.Persistence.Entities.PersonIdentity() };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(PersonContact entity)
        {
            entity.Identity.Name = Name;
            entity.Identity.About = About;
            entity.Priority = Priority;
            entity.Identity.LastName = LastName;
            entity.Identity.Alias = Alias;
            entity.Identity.Sex = Sex;
            entity.Identity.CivilStatus = CivilStatus;
            entity.PersonalIdentificationNumber = PersonalIdentificationNumber;
            entity.SkinKind = SkinKind;

            if (entity.UserId != UserId)
            {
                entity.User = null;
                entity.UserId = UserId;
            }
        }
    }
}
