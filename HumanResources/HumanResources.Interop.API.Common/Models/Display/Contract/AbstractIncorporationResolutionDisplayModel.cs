namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.Contract
{
    public class AbstractIncorporationResolutionDisplayModel<TIncorporationResolution> : Legal.Interop.API.Common.Models.Display.Contract.AbstractResolutionDisplayModel<TIncorporationResolution> where TIncorporationResolution : Persistence.Entities.Contract.AbstractIncorporationResolution
    {
        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get; set; }

        public System.DateTime? ConcretedAt { get; set; }

        public override void Import(TIncorporationResolution entity)
        {
            base.Import(entity);

            ConcretedAt = entity.ConcretedAt;

            if (entity.Agreement != null)
            {
                Agreement = new Governance.Interop.API.Common.Models.Display.AgreementDisplayModel();

                Agreement.Import(entity.Agreement);
            }
        }
    }
}
