namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class NaturalClientPropertyLeasingCollectInputModel : Financial.Interop.API.Common.Models.Input.Contract.AbstractCollectInputModel<Persistence.Entities.NaturalClientPropertyLeasingCollect>
    {
        public System.Guid LeasingId { get; set; }

        public override Persistence.Entities.NaturalClientPropertyLeasingCollect Export()
        {
            var entity = new Persistence.Entities.NaturalClientPropertyLeasingCollect { Id = Id, ExpectedAt = ExpectedAt };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.NaturalClientPropertyLeasingCollect entity)
        {
            base.Mergue(entity);

            if (entity.NaturalClientPropertyLeasingId != LeasingId)
            {
                entity.Leasing = null;
                entity.NaturalClientPropertyLeasingId = LeasingId;
            }
        }
    }
}
