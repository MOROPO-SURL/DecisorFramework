namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class AdmitionEmploymentContractDisplayModel : Contract.AbstractEmploymentContractDisplayModel<Persistence.Entities.AdmitionEmploymentContract>
    {
        public AdmitionPropousalDisplayModel AdmitionPropousal { get; set; }

        public override void Import(Persistence.Entities.AdmitionEmploymentContract entity)
        {
            base.Import(entity);

            if (entity.AdmitionPropousal != null)
            {
                AdmitionPropousal = new AdmitionPropousalDisplayModel();

                AdmitionPropousal.Import(entity.AdmitionPropousal);
            }
        }
    }
}
