using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public class ProgramDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Program, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Code { get; set; }

        public ProgramKindDisplayModel Kind { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Chief { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Manager { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public ProgramExpectResultDisplayModel[] ExpectResults { get; set; }

        public virtual void Import(Persistence.Entities.Program entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Name = entity.Name;
            Alias = entity.Alias;
            Code = entity.Code;
            Description = entity.Description;
            Priority = entity.Priority;
            ExpectResults = entity.ExpectResults?.Select(_entity =>
            {
                var model = new ProgramExpectResultDisplayModel();

                model.Import(_entity);

                return model;
            }).ToArray();

            if (entity.Kind != null)
            {
                Kind = new ProgramKindDisplayModel();

                Kind.Import(entity.Kind);
            }

            if (entity.Chief != null)
            {
                Chief = new Framework.Decisor.Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                Chief.Import(entity.Chief);
            }

            if (entity.Manager != null)
            {
                Manager = new Framework.Decisor.Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel();

                Manager.Import(entity.Manager);
            }
        }
    }
}
