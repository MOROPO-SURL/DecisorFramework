namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Bridge
{
    public class AlternativeWorkforceBridgeModel
    {
        public Display.WorkforceDisplayModel Workforce { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
