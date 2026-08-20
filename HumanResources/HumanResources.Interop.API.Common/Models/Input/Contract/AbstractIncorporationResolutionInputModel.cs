namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input.Contract
{
    public abstract class AbstractIncorporationResolutionInputModel<TIncorporationResolution> : Legal.Interop.API.Common.Models.Input.Contract.AbstractResolutionInputModel<TIncorporationResolution> where TIncorporationResolution : Persistence.Entities.Contract.AbstractIncorporationResolution, new()
    {
        public System.Guid? AgreementId { get; set; }

        public override void Mergue(TIncorporationResolution entity)
        {
            base.Mergue(entity);

            if (entity.AgreementId != AgreementId)
            {
                entity.Agreement = null;
                entity.AgreementId = AgreementId;
            }
        }
    }
}
