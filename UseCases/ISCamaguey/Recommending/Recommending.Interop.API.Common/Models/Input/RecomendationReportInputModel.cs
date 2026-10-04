using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Recommending.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Interop.API.Common.Models.Input
{
    public sealed class RecomendationReportInputModel : Framework.Decisor.Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<RecomendationReport, System.Guid>
    {
        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string Reference { get; set; }

        public string Description { get; set; }

        public DocumentInputModel Document { get; set; }

        public EmployeeDisplayModel[] Authors { get; set; }

        public override RecomendationReport Export()
        {
            var entity = new RecomendationReport { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(RecomendationReport entity)
        {
            entity.Title = Title;
            entity.Reference = Reference;
            entity.Description = Description;
            entity.At = At;

            entity.EmployeeBridges.Clear();

            foreach (var item in Authors)
            {
                entity.EmployeeBridges.Add(new RecomendationReportEmployeeBridge { ProwId = entity.Id, SternId = item.Id });
            }
        }
    }
}
