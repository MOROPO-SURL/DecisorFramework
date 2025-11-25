namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class LegalClientWidthContractStatusDisplayModel : Framework.Decisor.Commercial.Interop.API.Common.Models.Display.LegalClientDisplayModel
    {
        public int ActiveContractCount { get; set; }

        public int EndedContractCount { get; set; }
    }
}
