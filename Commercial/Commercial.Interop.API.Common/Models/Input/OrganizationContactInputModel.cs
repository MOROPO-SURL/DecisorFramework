using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input
{
    public class OrganizationContactInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.OrganizationContact, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public System.DateTime? BornDate { get; set; }

        public string About { get; set; }

        public int Priority { get; set; }

        public ImageInputModel Image { get; set; }

        public List<Core.Interop.API.Common.Models.Display.EmailContactItemDisplayModel> EmailContacts { get; set; } = new List<Core.Interop.API.Common.Models.Display.EmailContactItemDisplayModel>();

        public List<Core.Interop.API.Common.Models.Display.PhoneContactItemDisplayModel> PhoneContacts { get; set; } = new List<Core.Interop.API.Common.Models.Display.PhoneContactItemDisplayModel>();

        public List<Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel> PostalContacts { get; set; } = new List<Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel>();

        public List<Core.Interop.API.Common.Models.Display.WebContactItemDisplayModel> WebContacts { get; set; } = new List<Core.Interop.API.Common.Models.Display.WebContactItemDisplayModel>();

        public System.Guid BusinessKindId { get; set; }

        public Persistence.Entities.OrganizationContact Export()
        {
            var entity = new Persistence.Entities.OrganizationContact { Id = Id, Enabled = true, Identity = new Guama.Identity.Persistence.Entities.OrganizationIdentity() };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.OrganizationContact entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.OrganizationContact entity)
        {
            entity.Identity.Name = Name;
            entity.Identity.BornDate = BornDate;
            entity.Identity.About = About;
            entity.Priority = Priority;

            if (BusinessKindId != entity.BusinessKindId)
            {
                entity.BusinessKind = null;
                entity.BusinessKindId = BusinessKindId;
            }
        }
    }
}
