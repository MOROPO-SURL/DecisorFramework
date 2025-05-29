using MOROPO.Framework.Decisor.Production.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input
{
    public class ProductionOrderInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ProductionOrder, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public System.DateTime RequestedFor { get; set; }

        public System.Guid AuthorId { get; set; }

        public System.Guid ResponsibleId { get; set; }

        public System.Guid DecisorId { get; set; }

        public System.Guid ElaborationId { get; set; }

        public decimal Amount { get; set; }

        public ProductionOrder Export()
        {
            var entity = new ProductionOrder { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(ProductionOrder entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(ProductionOrder entity)
        {
            entity.RequestedFor = RequestedFor;
            entity.Priority = Priority;
            entity.Description = Description;
            entity.Amount = Amount;

            if (entity.ElaborationId != ElaborationId)
            {
                entity.Elaboration = null;
                entity.ElaborationId = ElaborationId;
            }

            if (entity.AuthorId != AuthorId)
            {
                entity.Author = null;
                entity.AuthorId = AuthorId;
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

