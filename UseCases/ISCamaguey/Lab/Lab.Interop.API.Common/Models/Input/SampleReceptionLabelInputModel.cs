namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Input
{
    public class SampleReceptionLabelInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.SampleReceptionLabel, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Reference { get; set; }

        public Persistence.Entities.SampleReceptionLabel Export()
        {
            var entity = new Persistence.Entities.SampleReceptionLabel { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.SampleReceptionLabel entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.SampleReceptionLabel entity)
        {
            entity.Priority = Priority;
            entity.Reference = Reference;
        }
    }
}
