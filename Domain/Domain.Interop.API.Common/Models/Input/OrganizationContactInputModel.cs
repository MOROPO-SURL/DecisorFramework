using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class OrganizationContactInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<OrganizationContact, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Alias { get; set; }

        public System.DateTime? BornDate { get; set; }

        public string About { get; set; }

        public int Priority { get; set; }

        public ImageInputModel Image { get; set; }

        public System.Guid BusinessKindId { get; set; }

        public List<PostalContactItemInputModel> EditionPostalContactItems { get; set; } = new List<PostalContactItemInputModel>();
        public List<PostalContactItemInputModel> IncomingPostalContactItems { get; set; } = new List<PostalContactItemInputModel>();
        public List<PostalContactItemDisplayModel> OutgoingPostalContactItems { get; set; } = new List<PostalContactItemDisplayModel>();

        public OrganizationContact Export()
        {
            var entity = new OrganizationContact { Id = Id, Enabled = true, Identity = new Guama.Identity.Persistence.Entities.OrganizationIdentity() };

            Mergue(entity);

            return entity;
        }

        public void Import(OrganizationContact entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(OrganizationContact entity)
        {
            entity.Identity.Name = Name;
            entity.Identity.Alias = Alias;
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
