using MOROPO.Framework.Decisor.Production.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Input
{
    public class ProductionOrderInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<ProductionOrder, System.Guid>
    {
        public int Priority { get; set; }

        public string Description { get; set; }

        public System.DateTime RequestedFor { get; set; }

        public System.Guid AgreementId { get; set; }

        public System.Guid ResponsibleId { get; set; }

        public System.Guid ElaborationId { get; set; }

        public decimal Amount { get; set; }

        public override ProductionOrder Export()
        {
            var entity = new ProductionOrder { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(ProductionOrder entity)
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

            if (entity.AgreementId != AgreementId)
            {
                entity.Agreement = null;
                entity.AgreementId = AgreementId;
            }

            if (entity.ResponsibleId != ResponsibleId)
            {
                entity.Responsible = null;
                entity.ResponsibleId = ResponsibleId;
            }
        }
    }
}

