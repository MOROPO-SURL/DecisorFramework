namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class OrganizationalUnitInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.OrganizationalUnit, System.Guid>
    {
        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(200)]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(1024)]
        public string Description { get; set; }

        public override Persistence.Entities.OrganizationalUnit Export()
        {
            var entity = new Persistence.Entities.OrganizationalUnit { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.OrganizationalUnit entity)
        {
            entity.Priority = Priority;
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}
