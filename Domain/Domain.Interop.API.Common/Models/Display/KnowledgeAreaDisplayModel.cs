namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class KnowledgeAreaDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.KnowledgeArea, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public void Import(Persistence.Entities.KnowledgeArea entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Name = entity.Name;
            Description = entity.Description;
            At = entity.At;
            Priority = entity.Priority;
        }
    }
}
