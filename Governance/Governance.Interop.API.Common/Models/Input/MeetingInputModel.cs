using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Input
{
    public class MeetingInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.Meeting, System.Guid>
    {
        public int Index { get; set; }

        public System.DateTime At { get; set; }

        public System.Guid DecisionMakingGroupId { get; set; }

        public System.Guid AuthorId { get; set; }

        public string Summary { get; set; }

        public string Rapporteurship { get; set; }

        public List<EmployeeDisplayModel> InternalInvitations { get; set; } = new List<EmployeeDisplayModel>();

        public List<PersonContactDisplayModel> ExternalInvitations { get; set; } = new List<PersonContactDisplayModel>();

        public List<AgreementInputModel> EditionAgreements { get; set; } = new List<AgreementInputModel>();
        public List<AgreementInputModel> IncomingAgreements { get; set; } = new List<AgreementInputModel>();
        public List<Display.AgreementDisplayModel> OutgoingAgreements { get; set; } = new List<Display.AgreementDisplayModel>();

        public override Persistence.Entities.Meeting Export()
        {
            var entity = new Persistence.Entities.Meeting { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.Meeting entity)
        {
            entity.Index = Index;
            entity.At = At;
            entity.Summary = Summary;
            entity.Rapporteurship = Rapporteurship;

            if (entity.DecisionMakingGroupId != DecisionMakingGroupId)
            {
                entity.DecisionMakingGroup = null;
                entity.DecisionMakingGroupId = DecisionMakingGroupId;
            }

            if (entity.AuthorId != AuthorId)
            {
                entity.Author = null;
                entity.AuthorId = AuthorId;
            }

            entity.EmployeeBridges.Clear();

            entity.EmployeeBridges = InternalInvitations.Select(model => new Persistence.Entities.MeetingEmployeeBridge
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();

            entity.ContactBridges.Clear();

            entity.ContactBridges = ExternalInvitations.Select(model => new Persistence.Entities.MeetingContactBridge
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();
        }
    }
}
