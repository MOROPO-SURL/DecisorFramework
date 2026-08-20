namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class NamingResolutionInputModel : Contract.AbstractIncorporationResolutionInputModel<Persistence.Entities.NamingResolution>
    {
        public System.Guid AdmitionPropousalId { get; set; }

        public override void Mergue(Persistence.Entities.NamingResolution entity)
        {
            base.Mergue(entity);

            if (entity.AdmitionPropousalId != AdmitionPropousalId)
            {
                entity.AdmitionPropousal = null;
                entity.AdmitionPropousalId = AdmitionPropousalId;
            }
        }
    }
}
