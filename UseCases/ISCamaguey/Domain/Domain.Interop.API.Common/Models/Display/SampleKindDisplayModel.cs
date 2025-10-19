namespace MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class SampleKindDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.SampleKind, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public bool Enabled { get; set; }

        public virtual void Import(Persistence.Entities.SampleKind entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Priority = entity.Priority;
            Enabled = entity.Enabled;
        }
    }
}
