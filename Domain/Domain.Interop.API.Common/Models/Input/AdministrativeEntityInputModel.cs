namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class AdministrativeEntityInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.AdministrativeEntity, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string About { get; set; }

        public int Priority { get; set; }

        public Core.Interop.API.Common.Models.Input.ImageInputModel Image { get; set; }

        public System.Guid KindId { get; set; }

        public System.Guid OrganizationalStructureId { get; set; }

        public System.Guid? ParentId { get; set; }

        public System.Guid? SocialPropertyId { get; set; }

        public override Persistence.Entities.AdministrativeEntity Export()
        {
            var entity = new Persistence.Entities.AdministrativeEntity { Id = Id, Enabled = true, Identity = new Guama.Identity.Persistence.Entities.OrganizationIdentity() };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.AdministrativeEntity entity)
        {
            entity.Identity.Name = Name;
            entity.Identity.About = About;
            entity.Priority = Priority;

            if (entity.KindId != KindId)
            {
                entity.Kind = null;
                entity.KindId = KindId;
            }

            if (entity.OrganizationalStructureId != OrganizationalStructureId)
            {
                entity.OrganizationalStructure = null;
                entity.OrganizationalStructureId = OrganizationalStructureId;
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
