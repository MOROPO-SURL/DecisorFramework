namespace MOROPO.Framework.Decisor.Servicing.Interop.API.Common.Models.Input
{
	public class ServiceInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Service, System.Guid>
	{
		public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public Core.Interop.API.Common.Models.Input.ImageInputModel FeatureImage { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public Persistence.Entities.Service Export()
        {
            var entity = new Persistence.Entities.Service { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Service entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Service entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}

