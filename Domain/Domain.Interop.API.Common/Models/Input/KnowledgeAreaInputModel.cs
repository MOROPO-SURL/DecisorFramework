
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Input
{
    public class KnowledgeAreaInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<KnowledgeArea, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public KnowledgeArea Export()
        {
            var entity = new KnowledgeArea { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(KnowledgeArea entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(KnowledgeArea entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
