namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class WorkPositionDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.WorkPosition, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public WorkPositionKindDisplayModel Kind { get; set; }

        public Domain.Persistence.Enumerations.EducationLevel EducationLevel { get; set; }

        public string Description { get; set; }

        public void Import(Persistence.Entities.WorkPosition entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Name = entity.Name;
            Reference = entity.Reference;
            EducationLevel = entity.EducationLevel;
            Description = entity.Description;

            if (entity.Kind != null)
            {
                Kind = new WorkPositionKindDisplayModel();

                Kind.Import(entity.Kind);
            }
        }
    }
}
