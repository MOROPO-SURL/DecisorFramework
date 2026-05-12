namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display
{
    public class ProgramExpectResultDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ProgramExpectResult, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Title { get; set; }

        public int Index { get; set; }

        public string Description { get; set; }

        public void Import(Persistence.Entities.ProgramExpectResult entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Index = entity.Index;
            Description = entity.Description;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ProgramExpectResultDisplayModel target)) return false;

            return Id.Equals(target.Id);
        }
    }
}
