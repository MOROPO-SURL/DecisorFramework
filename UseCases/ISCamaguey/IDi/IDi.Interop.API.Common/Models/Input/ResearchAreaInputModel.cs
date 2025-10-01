namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public class ResearchAreaInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.ResearchArea, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public Persistence.Entities.ResearchArea Export()
        {
            var entity = new Persistence.Entities.ResearchArea { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.ResearchArea entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.ResearchArea entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
