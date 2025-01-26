namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Input.Contract
{
	public abstract class AbstractServiceInputModel<TService> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TService, System.Guid>
        where TService : Persistence.Entities.Contract.AbstractService, new()
	{
		public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public Core.Interop.API.Common.Models.Input.ImageInputModel FeatureImage { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public virtual TService Export()
        {
            var entity = new TService { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(TService entity)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Mergue(TService entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}

