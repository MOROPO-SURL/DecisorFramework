namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class OrganizationalStructuringUnitInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.OrganizationalStructuringUnit, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid OrganizationalUnitId { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(120)]
        public string Reference { get; set; }

        public System.Guid? ParentId { get; set; }

        public Persistence.Entities.OrganizationalStructuringUnit Export()
        {
            var entity = new Persistence.Entities.OrganizationalStructuringUnit { Id = Id, ParentId = ParentId };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.OrganizationalStructuringUnit entity) => throw new System.NotImplementedException();

        public void Mergue(Persistence.Entities.OrganizationalStructuringUnit entity)
        {
            entity.Reference = Reference;

            if (entity.OrganizationalUnitId != OrganizationalUnitId)
            {
                entity.OrganizationalUnit = null;
                entity.OrganizationalUnitId = OrganizationalUnitId;
            }
        }
    }
}
