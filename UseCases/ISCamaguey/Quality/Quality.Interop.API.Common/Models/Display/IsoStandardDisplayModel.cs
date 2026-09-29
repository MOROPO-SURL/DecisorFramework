namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Display
{
    public class IsoStandardDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.IsoStandard, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public int Index { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public virtual void Import(Persistence.Entities.IsoStandard entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Index = entity.Index;
            Description = entity.Description;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
        }
    }
}
