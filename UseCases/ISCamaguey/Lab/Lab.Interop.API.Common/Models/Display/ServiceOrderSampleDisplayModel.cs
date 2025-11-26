namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display
{
    public class ServiceOrderSampleDisplayModel : Contract.AbstractSampleDisplayModel<Persistence.Entities.ServiceOrderSample>
    {
        public CommonSampleAnalysisServiceOrderDisplayModel Order { get; set; }

        public override void Import(Persistence.Entities.ServiceOrderSample entity)
        {
            base.Import(entity);

            if (entity.Order != null)
            {
                Order = new CommonSampleAnalysisServiceOrderDisplayModel();

                Order.Import(entity.Order);
            }
        }
    }
}
