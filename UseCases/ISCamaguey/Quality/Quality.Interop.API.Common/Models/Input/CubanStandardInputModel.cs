namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Input
{
    public class CubanStandardInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.CubanStandard, System.Guid>
    {
        public System.Guid Id { get; set ; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Index { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public Persistence.Entities.CubanStandard Export()
        {
            var entity = new Persistence.Entities.CubanStandard { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.CubanStandard entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.CubanStandard entity)
        {
            entity.Name = Name;
            entity.Index = Index;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
