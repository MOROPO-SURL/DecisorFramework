namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class NamingResolutionDisplayModel : Contract.AbstractIncorporationResolutionDisplayModel<Persistence.Entities.NamingResolution>
    {
        public AdmitionPropousalDisplayModel AdmitionPropousal { get; set; }

        public override void Import(Persistence.Entities.NamingResolution entity)
        {
            base.Import(entity);

            ConcretedAt = entity.ConcretedAt;

            if (entity.AdmitionPropousal != null)
            {
                AdmitionPropousal = new AdmitionPropousalDisplayModel();

                AdmitionPropousal.Import(entity.AdmitionPropousal);
            }
        }
    }
}
