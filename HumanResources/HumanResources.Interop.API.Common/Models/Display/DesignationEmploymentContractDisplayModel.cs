namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class DesignationEmploymentContractDisplayModel : Contract.AbstractEmploymentContractDisplayModel<Persistence.Entities.DesignationEmploymentContract>
    {
        public DesignationResolutionDisplayModel Resolution { get; set; }

        public override void Import(Persistence.Entities.DesignationEmploymentContract entity)
        {
            base.Import(entity);

            if (entity.Resolution != null)
            {
                Resolution = new DesignationResolutionDisplayModel();

                Resolution.Import(entity.Resolution);
            }
        }
    }
}
