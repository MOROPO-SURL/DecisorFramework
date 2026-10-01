using MOROPO.Framework.Guama.Core.Persistence.Entities.Contract;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Persistence.Entities
{
    public sealed class RecomendationReport : IArchivableEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string Reference { get; set; }

        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(DocumentId))]
        public Document Document { get; set; }
        public System.Guid DocumentId { get; set; }

        public List<RecomendationReportEmployeeBridge> EmployeeBridges { get; set; } = new List<RecomendationReportEmployeeBridge>();
    }
}
