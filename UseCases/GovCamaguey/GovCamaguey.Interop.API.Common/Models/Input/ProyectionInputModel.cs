namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class ProyectionInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Proyection, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Persistence.Entities.Proyection Export()
        {
            var entity = new Persistence.Entities.Proyection { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Proyection entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Proyection entity)
        {
            entity.Index = Index;
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}
