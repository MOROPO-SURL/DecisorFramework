namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display
{
    public class SectionDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Section, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public void Import(Persistence.Entities.Section entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Priority = entity.Priority;
            Description = entity.Description;
        }
    }
}
