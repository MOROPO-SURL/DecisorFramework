using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input
{
    public class PersonContactInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.PersonContact, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string About { get; set; }

        public int Priority { get; set; }

        public ImageInputModel Image { get; set; }

        public List<Core.Interop.API.Common.Models.Display.EmailContactItemDisplayModel> EmailContacts { get; set; } = new List<Core.Interop.API.Common.Models.Display.EmailContactItemDisplayModel>();

        public List<Core.Interop.API.Common.Models.Display.PhoneContactItemDisplayModel> PhoneContacts { get; set; } = new List<Core.Interop.API.Common.Models.Display.PhoneContactItemDisplayModel>();

        public List<Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel> PostalContacts { get; set; } = new List<Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel>();

        public List<Core.Interop.API.Common.Models.Display.WebContactItemDisplayModel> WebContacts { get; set; } = new List<Core.Interop.API.Common.Models.Display.WebContactItemDisplayModel>();

        public string LastName { get; set; }

        public string Alias { get; set; }

        public Guama.Identity.Persistence.Enumerations.Sex Sex { get; set; }

        public Guama.Identity.Persistence.Enumerations.CivilStatus CivilStatus { get; set; }

        public System.Guid BusinessKindId { get; set; }

        public Persistence.Entities.PersonContact Export()
        {
            var entity = new Persistence.Entities.PersonContact { Id = Id, Enabled = true, Identity = new Guama.Identity.Persistence.Entities.PersonIdentity() };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.PersonContact entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.PersonContact entity)
        {
            entity.Identity.Name = Name;
            entity.Identity.About = About;
            entity.Priority = Priority;
            entity.Identity.LastName = LastName;
            entity.Identity.Alias = Alias;
            entity.Identity.Sex = Sex;
            entity.Identity.CivilStatus = CivilStatus;

            if (entity.BusinessKindId != BusinessKindId)
            {
                entity.BusinessKind = null;
                entity.BusinessKindId = BusinessKindId;
            }
        }
    }
}
