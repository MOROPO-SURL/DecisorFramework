namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class PropertyKindDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PropertyKind, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public virtual void Import(Persistence.Entities.PropertyKind entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            At = entity.At;
            Priority = entity.Priority;
        }
    }
}
