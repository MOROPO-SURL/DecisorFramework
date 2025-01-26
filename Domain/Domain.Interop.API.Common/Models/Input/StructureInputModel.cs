using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class StructureInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Structure, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string About { get; set; }

        public int Priority { get; set; }

        public Core.Interop.API.Common.Models.Input.ImageInputModel Image { get; set; }

        public System.Guid KindId { get; set; }

        public System.Guid? ParentId { get; set; }

        public System.Guid? SocialPropertyId { get; set; }

        public List<OrganizationalUnityTreeDisplayModel> OrganizationalUnities { get; set; } = new List<OrganizationalUnityTreeDisplayModel>();

        public Persistence.Entities.Structure Export()
        {
            var entity = new Persistence.Entities.Structure { Id = Id, Enabled = true, Identity = new Guama.Identity.Persistence.Entities.OrganizationIdentity() };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Structure entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Structure entity)
        {
            entity.Identity.Name = Name;
            entity.Identity.About = About;
            entity.Priority = Priority;
            entity.OrganizationalUnityBridges = OrganizationalUnities.Select(model => new Persistence.Entities.StructureOrganizationalUnityBridge 
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();

            if (entity.KindId != KindId)
            {
                entity.Kind = null;
                entity.KindId = KindId;
            }

            if (entity.ParentId != ParentId)
            {
                entity.Parent = null;
                entity.ParentId = ParentId;
            }

            if (entity.SocialPropertyId != SocialPropertyId)
            {
                entity.SocialProperty = null;
                entity.SocialPropertyId = SocialPropertyId;
            }
        }
    }
}
