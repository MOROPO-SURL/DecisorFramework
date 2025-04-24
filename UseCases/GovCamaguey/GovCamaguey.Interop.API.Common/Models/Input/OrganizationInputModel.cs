using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Collections.Generic;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class OrganizationInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Organization, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Alias { get; set; }

        public string About { get; set; }

        public int Priority { get; set; }

        public ImageInputModel Image { get; set; }

        public List<PhoneContactItemInputModel> EditionPhoneContactItems { get; set; } = new List<PhoneContactItemInputModel>();
        public List<PhoneContactItemInputModel> IncomingPhoneContactItems { get; set; } = new List<PhoneContactItemInputModel>();
        public List<PhoneContactItemDisplayModel> OutgoingPhoneContactItems { get; set; } = new List<PhoneContactItemDisplayModel>();

        public List<EmailContactItemInputModel> EditionEmailContactItems { get; set; } = new List<EmailContactItemInputModel>();
        public List<EmailContactItemInputModel> IncomingEmailContactItems { get; set; } = new List<EmailContactItemInputModel>();
        public List<EmailContactItemDisplayModel> OutgoingEmailContactItems { get; set; } = new List<EmailContactItemDisplayModel>();

        public Persistence.Entities.Organization Export()
        {
            var entity = new Persistence.Entities.Organization { Id = Id, Enabled = true, Identity = new Framework.Guama.Identity.Persistence.Entities.OrganizationIdentity() };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Organization entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Organization entity)
        {
            entity.Identity.Name = Name;
            entity.Identity.Alias = Alias;
            entity.Identity.About = About;
            entity.Priority = Priority;
        }
    }
}
