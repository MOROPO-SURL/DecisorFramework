namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities
{
    public class Clause : Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Guama.Core.Persistence.Entities.Contract.IPriorizableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Body { get; set; }

        public System.Collections.Generic.List<ClauseTagBridge> TagBridges { get; set; } = new System.Collections.Generic.List<ClauseTagBridge>();
    }
}
