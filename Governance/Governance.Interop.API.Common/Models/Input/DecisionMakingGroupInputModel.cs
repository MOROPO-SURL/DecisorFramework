namespace MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Input
{
    public class DecisionMakingGroupInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.DecisionMakingGroup, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.Guid StructureId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public System.Guid LeaderId { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public Persistence.Entities.DecisionMakingGroup Export()
        {
            var entity = new Persistence.Entities.DecisionMakingGroup { Id = System.Guid.NewGuid(), Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.DecisionMakingGroup entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.DecisionMakingGroup entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;

            if (entity.StructureId != StructureId)
            {
                entity.Structure = null;
                entity.StructureId = StructureId;
            }

            if (entity.LeaderId != LeaderId)
            {
                entity.Leader = null;
                entity.LeaderId = LeaderId;
            }
        }
    }
}
