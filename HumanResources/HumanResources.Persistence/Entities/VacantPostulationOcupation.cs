namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class VacantPostulationOcupation : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PostulationId))]
        public VacantPostulation Postulation { get; set; }
        public System.Guid PostulationId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string OrganizationName { get; set; }

        public string OrganizationAddress { get; set; }

        public string RepresentativeName { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(CentralStateStructureId))]
        public Legal.Persistence.Entities.CentralStateStructure CentralStateStructure { get; set; }
        public System.Guid? CentralStateStructureId { get; set; }

        public System.DateTime StartAt { get; set; }

        public System.DateTime EndAt { get; set; }
    }
}
