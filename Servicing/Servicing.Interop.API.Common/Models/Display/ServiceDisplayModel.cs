namespace MOROPO.Framework.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class ServiceDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Service, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Core.Interop.API.Common.Models.Display.ImageDisplayModel FeatureImage { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public virtual void Import(Persistence.Entities.Service entity)
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

