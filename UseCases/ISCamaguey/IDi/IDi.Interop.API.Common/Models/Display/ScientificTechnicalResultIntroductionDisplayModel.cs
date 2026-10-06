using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public class ScientificTechnicalResultIntroductionDisplayModel : IEntityDisplayModel<ScientificTechnicalResultIntroduction, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public string Scenary { get; set; }

        public ScientificTechnicalResultDisplayModel Result { get; set; }

        public EmployeeDisplayModel[] Supervisors { get; set; }

        public virtual void Import(ScientificTechnicalResultIntroduction entity)
        {
            Id = entity.Id;
            Description = entity.Description;
            At = entity.At;
            Scenary = entity.Scenery;

            if (entity.Result != null)
            {
                Result = new ScientificTechnicalResultDisplayModel();

                Result.Import(entity.Result);
            }
        }
    }
}
