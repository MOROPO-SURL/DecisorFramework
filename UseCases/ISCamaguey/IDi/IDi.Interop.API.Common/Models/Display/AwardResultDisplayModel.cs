using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Constants;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public sealed class AwardResultDisplayModel : IEntityDisplayModel<AwardResult, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public string Title { get; set; }

        public AwardKindDisplayModel AwardKind { get; set; }

        public Persistence.Enumerations.AwardModality AwardModality { get; set; }

        public ProjectDisplayModel Project { get; set; }

        public EmployeeDisplayModel Receptor { get; set; }

        public void Import(AwardResult entity)
        {
            Id = entity.Id; 
            Description = entity.Description;
            At = entity.At;
            Title = entity.Title;
            AwardModality = entity.AwardModality;

            if (entity.AwardKind != null)
            {
                AwardKind = new AwardKindDisplayModel();

                AwardKind.Import(entity.AwardKind);
            }

            if (entity.Receptor != null)
            {
                Receptor = new EmployeeDisplayModel();

                Receptor.Import(entity.Receptor);
            }

            if (entity.Project != null)
            {
                Project = new ProjectDisplayModel();

                Project.Import(entity.Project);
            }
        }
    }
}
