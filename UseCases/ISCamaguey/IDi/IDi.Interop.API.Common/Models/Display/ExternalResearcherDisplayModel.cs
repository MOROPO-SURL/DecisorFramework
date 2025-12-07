namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public class ExternalResearcherDisplayModel : Contract.AbstractResearcherDisplayModel<Persistence.Entities.ExternalResearcher>
    {
        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get; set; }

        public ParticipatingOrganizationDisplayModel ParticipatingOrganization { get; set; }

        public decimal Salary { get; set; }

        public override void Import(Persistence.Entities.ExternalResearcher entity)
        {
            base.Import(entity);

            Salary = entity.Salary;

            if (entity.Contact != null)
            {
                Contact = new Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                Contact.Import(entity.Contact);
            }

            if (entity.ParticipatingOrganization != null)
            {
                ParticipatingOrganization = new ParticipatingOrganizationDisplayModel();

                ParticipatingOrganization.Import(entity.ParticipatingOrganization);
            }
        }
    }
}
