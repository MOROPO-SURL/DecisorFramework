namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Bridge
{
    public class RequestableServiceContactBridgeModel
    {
        public Display.RequestableServiceDisplayModel Service { get; set; }

        public string Description { get; set; }

        public int Evaluation { get; set; }
    }
}
