namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class NamingResolutionDisplayModel : Legal.Interop.API.Common.Models.Display.Contract.AbstractResolutionDisplayModel<Persistence.Entities.NamingResolution>
    {
        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get; set; }

        public OcupationCandidateDisplayModel Candidate { get; set; }

        public Governance.Interop.API.Common.Models.Display.AgreementDisplayModel Agreement { get; set; }

        public VacantDisplayModel Vacant { get; set; }

        public StaffDisplayModel Staff { get; set; }

        public System.DateTime? ConcretedAt { get; set; }

        public override void Import(Persistence.Entities.NamingResolution entity)
        {
            base.Import(entity);

            ConcretedAt = entity.ConcretedAt;

            if (entity.Contact != null)
            {
                Contact = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                Contact.Import(entity.Contact);
            }

            if (entity.Candidate != null)
            {
                Candidate = new OcupationCandidateDisplayModel();

                Candidate.Import(entity.Candidate);
            }

            if (entity.Agreement != null)
            {
                Agreement = new Governance.Interop.API.Common.Models.Display.AgreementDisplayModel();

                Agreement.Import(entity.Agreement);
            }

            if (entity.Vacant != null)
            {
                Vacant = new VacantDisplayModel();

                Vacant.Import(entity.Vacant);
            }

            if (entity.Staff != null)
            {
                Staff = new StaffDisplayModel();

                Staff.Import(entity.Staff);
            }
        }
    }
}
