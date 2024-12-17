namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractServiceDisplayModel<TService> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TService, System.Guid>
        where TService : Persistence.Entities.Contract.AbstractService
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Core.Interop.API.Common.Models.Display.ImageDisplayModel FeatureImage { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public virtual void Import(TService entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            At = entity.At;
            Priority = entity.Priority;

            if (entity.FeatureImage != null)
            {
                FeatureImage = new Core.Interop.API.Common.Models.Display.ImageDisplayModel();

                FeatureImage.Import(entity.FeatureImage);
            }
        }
    }
}

