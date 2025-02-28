namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities
{
    public class Section : Guama.Core.Persistence.Entities.Contract.INamedEntity<int>, Guama.Core.Persistence.Entities.Contract.IPriorizableEntity<int>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ParentId))]
        public Section Parent { get; set; }
        public int? ParentId { get; set; }
    }
}
