using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public sealed class ScientificTechnicalResultIntroductionInputModel : IEntityInputModel<ScientificTechnicalResultIntroduction, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Scenery { get; set; }

        public System.Guid ResultId { get; set; }

        public EmployeeDisplayModel[] Supervisors { get; set; }

        public ScientificTechnicalResultIntroduction Export()
        {
            var entity = new ScientificTechnicalResultIntroduction { Id = Id, Archived = false };

            Mergue(entity);

            return entity;
        }

        public void Import(ScientificTechnicalResultIntroduction entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(ScientificTechnicalResultIntroduction entity)
        {
            entity.Description = Description;
            entity.At = At;
            entity.Scenery = Scenery;

            if (entity.ResultId != ResultId)
            {
                entity.Result = null;
                entity.ResultId = ResultId;
            }

            entity.EmployeeBridges.Clear();

            foreach (var item in Supervisors)
            {
                entity.EmployeeBridges.Add(new ScientificTechnicalResultIntroductionEmployeeBridge { ProwId = entity.Id, SternId = item.Id });
            }
        }
    }
}
