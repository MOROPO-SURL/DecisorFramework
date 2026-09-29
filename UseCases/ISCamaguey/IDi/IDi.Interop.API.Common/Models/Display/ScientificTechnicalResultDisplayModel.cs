using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Constants;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public sealed class ScientificTechnicalResultDisplayModel : IEntityDisplayModel<ScientificTechnicalResult, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public string Title { get; set; }

        public string Reference { get; set; }

        public ScientificTechnicalResultKindDisplayModel Kind { get; set; }

        public ProjectDisplayModel Project { get; set; }

        public void Import(ScientificTechnicalResult entity)
        {
            Id = entity.Id; 
            Description = entity.Description;
            At = entity.At;
            Title = entity.Title;
            Reference = entity.Reference;

            if (entity.Kind != null)
            {
                Kind = new ScientificTechnicalResultKindDisplayModel();

                Kind.Import(entity.Kind);
            }

            if (entity.Project != null)
            {
                Project = new ProjectDisplayModel();

                Project.Import(entity.Project);
            }
        }
    }
}
