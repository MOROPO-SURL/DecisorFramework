namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class VacantDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Vacant, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public string Reference { get; set; }

        public VacantKindDisplayModel Kind { get; set; }

        public SchoolingDisplayModel Schooling { get; set; }

        public string Description { get; set; }

        public void Import(Persistence.Entities.Vacant entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Name = entity.Name;
            Reference = entity.Reference;
            Description = entity.Description;

            if (entity.Kind != null)
            {
                Kind = new VacantKindDisplayModel();

                Kind.Import(entity.Kind);
            }

            if (entity.Schooling != null)
            {
                Schooling = new SchoolingDisplayModel();

                Schooling.Import(entity.Schooling);
            }
        }
    }
}
