using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Recommending.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Interop.API.Common.Models.Display
{
    public sealed class RecomendationReportDisplayModel : IEntityDisplayModel<RecomendationReport, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public string Title { get; set; }

        public string Reference { get; set; }

        public EmployeeDisplayModel[] Authors { get; set; }

        public DocumentDisplayModel Document { get; set; }

        public void Import(RecomendationReport entity)
        {
            Id = entity.Id;
            Description = entity.Description;
            At = entity.At;
            Title = entity.Title;
            Reference = entity.Reference;
        }
    }
}
