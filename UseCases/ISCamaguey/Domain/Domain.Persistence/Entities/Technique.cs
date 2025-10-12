namespace MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities
{
    public class Technique : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>, Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.Collections.Generic.List<TechniqueCubanStandardBridge> CubanStandardBridge {  get; set; } = new System.Collections.Generic.List<TechniqueCubanStandardBridge>();

        public System.Collections.Generic.List<TechniqueIsoStandardBridge> IsoStandardBridge { get; set;} = new System.Collections.Generic.List<TechniqueIsoStandardBridge>();

    }
}
