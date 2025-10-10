namespace MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Display
{
    public class MeetingDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Meeting, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        public System.DateTime At { get; set; }

        public DecisionMakingGroupDisplayModel DecisionMakingGroup { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Author { get; set; }

        public string Summary { get; set; }

        public string Rapporteurship { get; set; }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel[] InternalInvitations { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel[] ExternalInvitations { get; set; }

        public AgreementDisplayModel[] Agreements { get; set; }

        public void Import(Persistence.Entities.Meeting entity)
        {
            Id = entity.Id;
            Index = entity.Index;
            At = entity.At;
            Summary = entity.Summary;
            Rapporteurship = entity.Rapporteurship;

            if (entity.DecisionMakingGroup != null)
            {
                DecisionMakingGroup = new DecisionMakingGroupDisplayModel();

                DecisionMakingGroup.Import(entity.DecisionMakingGroup);
            }

            if (entity.Author != null)
            {
                Author = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                Author.Import(entity.Author);
            }
        }
    }
}
