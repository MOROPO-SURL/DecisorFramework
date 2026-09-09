namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class KnowledgeAreaInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.KnowledgeArea, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public override Persistence.Entities.KnowledgeArea Export()
        {
            var entity = new Persistence.Entities.KnowledgeArea { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.KnowledgeArea entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
