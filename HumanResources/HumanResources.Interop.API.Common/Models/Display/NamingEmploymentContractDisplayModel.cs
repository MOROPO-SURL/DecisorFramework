namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class NamingEmploymentContractDisplayModel : Contract.AbstractEmploymentContractDisplayModel<Persistence.Entities.NamingEmploymentContract>
    {
        public NamingResolutionDisplayModel Resolution { get; set; }

        public System.DateTime? InterviewAt { get; set; }

        public string Description { get; set; }

        public override void Import(Persistence.Entities.NamingEmploymentContract entity)
        {
            base.Import(entity);

            InterviewAt = entity.InterviewAt;
            Description = entity.Description;

            if (entity.Resolution != null)
            {
                Resolution = new NamingResolutionDisplayModel();

                Resolution.Import(entity.Resolution);
            }
        }
    }
}
