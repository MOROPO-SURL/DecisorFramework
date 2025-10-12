namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public class ProgramExpectResultInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.ProgramExpectResult, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public int Index { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        public Persistence.Entities.ProgramExpectResult Export()
        {
            var entity = new Persistence.Entities.ProgramExpectResult { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.ProgramExpectResult entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.ProgramExpectResult entity)
        {
            entity.Title = Title;
            entity.Index = Index;
            entity.Description = Description;
        }
    }
}
