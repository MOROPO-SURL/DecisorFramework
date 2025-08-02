namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class CommonLeasePersonPostulationDisplayModel
    {
        public System.Guid Id { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get; set; }

        public Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel BusinessKind { get; set; }

        public string TaxIdentificationNumber { get; set; }

        public string Argument { get; set; }
    }
}
