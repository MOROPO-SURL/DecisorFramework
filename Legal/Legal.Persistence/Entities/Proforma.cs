namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities
{
    public class Proforma : Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Guama.Core.Persistence.Entities.Contract.IEnableableEntity<System.Guid>, Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        public bool Archived { get; set; }

        public string Description { get; set; }

        public System.Collections.Generic.List<ProformaClauseBridge> ClauseBridges { get; set; } = new System.Collections.Generic.List<ProformaClauseBridge> { };
    }
}
