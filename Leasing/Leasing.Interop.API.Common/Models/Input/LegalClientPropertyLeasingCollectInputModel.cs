namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class LegalClientPropertyLeasingCollectInputModel : Financial.Interop.API.Common.Models.Input.Contract.AbstractCollectInputModel<Persistence.Entities.LegalClientPropertyLeasingCollect>
    {
        public System.Guid LeasingId { get; set; }

        public override Persistence.Entities.LegalClientPropertyLeasingCollect Export()
        {
            var entity = new Persistence.Entities.LegalClientPropertyLeasingCollect { Id = Id, ExpectedAt = ExpectedAt };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.LegalClientPropertyLeasingCollect entity)
        {
            base.Mergue(entity);

            if (entity.LegalClientPropertyLeasingId != LeasingId)
            {
                entity.Leasing = null;
                entity.LegalClientPropertyLeasingId = LeasingId;
            }
        }
    }
}
