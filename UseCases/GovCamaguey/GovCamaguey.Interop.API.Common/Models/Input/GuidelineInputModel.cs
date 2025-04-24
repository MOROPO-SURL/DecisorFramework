namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class GuidelineInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Guideline, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public int Number { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Persistence.Entities.Guideline Export()
        {
            var entity = new Persistence.Entities.Guideline { Id = System.Guid.NewGuid(), Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Guideline entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Guideline entity)
        {
            entity.Priority = Priority;
            entity.Number = Number;
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}
