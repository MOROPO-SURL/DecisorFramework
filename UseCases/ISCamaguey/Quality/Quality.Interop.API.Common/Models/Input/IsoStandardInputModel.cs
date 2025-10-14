namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Input
{
    public class IsoStandardInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.IsoStandard, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Index { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public Persistence.Entities.IsoStandard Export()
        {
            var entity = new Persistence.Entities.IsoStandard { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.IsoStandard entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.IsoStandard entity)
        {
            entity.Name = Name;
            entity.Index = Index;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
