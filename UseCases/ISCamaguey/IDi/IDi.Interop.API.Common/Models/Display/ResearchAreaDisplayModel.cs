namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public class ResearchAreaDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ResearchArea, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public void Import(Persistence.Entities.ResearchArea entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Name = entity.Name;
            Description = entity.Description;
            Priority = entity.Priority;
            At = entity.At;
        }
    }
}
