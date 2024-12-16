namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class StructureKindDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.StructureKind, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public void Import(Persistence.Entities.StructureKind entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            At = entity.At;
            Priority = entity.Priority;
        }
    }
}
