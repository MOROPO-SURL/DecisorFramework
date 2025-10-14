namespace MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities
{
    public class CubanStandard : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<System.Guid>, Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }
       
        public bool Archived { get; set; }
       
        public bool Enabled { get; set; }
        
        public int Priority { get; set; }

        
    }
}
