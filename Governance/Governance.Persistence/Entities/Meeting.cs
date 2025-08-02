using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Governance.Persistence.Entities
{
    public class Meeting : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public int Index { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DecisionMakingGroupId))]
        public DecisionMakingGroup DecisionMakingGroup { get; set; }
        public System.Guid DecisionMakingGroupId { get; set; }
        
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AuthorId))]
        public HumanResources.Persistence.Entities.Employee Author { get; set; }
        public System.Guid AuthorId { get; set; }

        public string Summary { get; set; }

        public string Rapporteurship { get; set; }

        public List<MeetingEmployeeBridge> EmployeeBridges { get; set; } = new List<MeetingEmployeeBridge>();

        public List<MeetingContactBridge> ContactBridges { get; set; } = new List<MeetingContactBridge>();

        public List<MeetingDocumentBridge> DocumentBridges { get; set; } = new List<MeetingDocumentBridge>();

        public Agreement[] Agreements { get; set; }

        public Statement[] Statements { get; set; }
    }
}