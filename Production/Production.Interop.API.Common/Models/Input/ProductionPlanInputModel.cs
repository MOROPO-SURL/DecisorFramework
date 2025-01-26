using MOROPO.Framework.Decisor.Production.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input
{
    public class ProductionPlanInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ProductionPlan, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public System.DateTime PlannedFor { get; set; }

        public System.Guid PlannerId { get; set; }

        public System.Guid ResponsibleId { get; set; }

        public System.Guid DecisorId { get; set; }

        public System.Guid ElaborationId { get; set; }

        public decimal Amount { get; set; }

        public ProductionPlan Export()
        {
            var entity = new ProductionPlan { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(ProductionPlan entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(ProductionPlan entity)
        {
            entity.PlannedFor = PlannedFor;
            entity.Priority = Priority;
            entity.Description = Description;
            entity.Amount = Amount;

            if (entity.ElaborationId != ElaborationId)
            {
                entity.Elaboration = null;
                entity.ElaborationId = ElaborationId;
            }

            if (entity.PlannerId != PlannerId)
            {
                entity.Planner = null;
                entity.PlannerId = PlannerId;
            }

            if (entity.ResponsibleId != ResponsibleId)
            {
                entity.Responsible = null;
                entity.ResponsibleId = ResponsibleId;
            }

            if (entity.DecisorId != DecisorId)
            {
                entity.Decisor = null;
                entity.DecisorId = DecisorId;
            }
        }
    }
}

