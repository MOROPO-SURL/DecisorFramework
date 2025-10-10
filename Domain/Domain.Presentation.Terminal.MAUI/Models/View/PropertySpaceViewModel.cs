namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.View
{
    public class PropertySpaceViewModel
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Area { get; set; }

        public Core.Interop.API.Common.Models.Input.ImageInputModel InputFeatureImage { get; set; }

        public Core.Interop.API.Common.Models.Display.ImageDisplayModel CurrentFeatureImage { get; set; }
    }
}
