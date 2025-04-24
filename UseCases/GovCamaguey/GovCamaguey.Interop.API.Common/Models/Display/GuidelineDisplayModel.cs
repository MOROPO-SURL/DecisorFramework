namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class GuidelineDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Guideline, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public void Import(Persistence.Entities.Guideline entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Number = entity.Number;
            Name = entity.Name;
            Description = entity.Description;
        }
    }
}
