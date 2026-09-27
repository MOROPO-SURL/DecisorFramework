namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public sealed class LegalClientGroundIntegralStudyServiceExecutionDisplayModel : Contract.AbstractExecutionDisplayModel<Persistence.Entities.LegalClientGroundIntegralStudyServiceExecution>
    {
        public LegalClientGroundIntegralStudyServiceOrderDisplayModel Order { get; set; }

        public override void Import(Persistence.Entities.LegalClientGroundIntegralStudyServiceExecution entity)
        {
            base.Import(entity);

            if (entity.Order != null)
            {
                Order = new LegalClientGroundIntegralStudyServiceOrderDisplayModel();

                Order.Import(entity.Order);
            }
        }
    }
}