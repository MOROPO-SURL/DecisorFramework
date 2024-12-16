namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class VehicleEngineKindDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.VehicleEngineKind, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public void Import(Persistence.Entities.VehicleEngineKind entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            At = entity.At;
            Priority = entity.Priority;
        }
    }
}
