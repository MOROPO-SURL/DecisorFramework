namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractIndicatorResultInputModel<TModel> : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TModel, long>
        where TModel : Persistence.Entities.Contract.AbstractIndicatorResult
    {
        public long Id { get; set; }

        public double Amount { get; set; }

        public abstract TModel Export();

        public void Import(TModel entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TModel entity)
        {
            entity.Amount = Amount;
        }
    }
}
