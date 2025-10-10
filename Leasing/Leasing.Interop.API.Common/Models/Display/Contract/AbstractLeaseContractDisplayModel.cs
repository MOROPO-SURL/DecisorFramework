namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractLeaseContractDisplayModel<TEntity> : Legal.Interop.API.Common.Models.Display.Contract.AbstractContractDisplayModel<TEntity> where TEntity : Persistence.Entities.Contract.AbstractLeaseContract
    {
        public double Feed { get; set; }

        public Commercial.Interop.API.Common.Models.Display.PaymentTermDisplayModel PaymentTerm { get; set; }

        public override void Import(TEntity entity)
        {
            base.Import(entity);

            Feed = entity.Feed;

            if (entity.PaymentTerm != null)
            {
                PaymentTerm = new Commercial.Interop.API.Common.Models.Display.PaymentTermDisplayModel();

                PaymentTerm.Import(entity.PaymentTerm);
            }
        }
    }
}
