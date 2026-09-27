namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public sealed class LegalClientTrainingServiceExecutionDisplayModel : Contract.AbstractExecutionDisplayModel<Persistence.Entities.LegalClientTrainingServiceExecution>
    {
        public LegalClientTrainingServiceOrderDisplayModel Order { get; set; }

        public override void Import(Persistence.Entities.LegalClientTrainingServiceExecution entity)
        {
            base.Import(entity);

            if (entity.Order != null)
            {
                Order = new LegalClientTrainingServiceOrderDisplayModel();

                Order.Import(entity.Order);
            }
        }
    }
}