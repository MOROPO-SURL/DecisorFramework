namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public sealed class NaturalClientTrainingServiceExecutionDisplayModel : Contract.AbstractExecutionDisplayModel<Persistence.Entities.NaturalClientTrainingServiceExecution>
    {
        public NaturalClientTrainingServiceOrderDisplayModel Order { get; set; }

        public override void Import(Persistence.Entities.NaturalClientTrainingServiceExecution entity)
        {
            base.Import(entity);

            if (entity.Order != null)
            {
                Order = new NaturalClientTrainingServiceOrderDisplayModel();

                Order.Import(entity.Order);
            }
        }
    }
}