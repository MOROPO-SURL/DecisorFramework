namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public sealed class NaturalClientGroundIntegralStudyServiceExecutionDisplayModel : Contract.AbstractExecutionDisplayModel<Persistence.Entities.NaturalClientGroundIntegralStudyServiceExecution>
    {
        public NaturalClientGroundIntegralStudyServiceOrderDisplayModel Order { get; set; }

        public override void Import(Persistence.Entities.NaturalClientGroundIntegralStudyServiceExecution entity)
        {
            base.Import(entity);

            if (entity.Order != null)
            {
                Order = new NaturalClientGroundIntegralStudyServiceOrderDisplayModel();

                Order.Import(entity.Order);
            }
        }
    }
}
