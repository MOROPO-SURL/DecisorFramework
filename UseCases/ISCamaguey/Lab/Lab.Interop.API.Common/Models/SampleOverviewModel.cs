using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Models.Display;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models
{
    public sealed class SampleOverviewModel
    {
        public System.Guid Id { get; set; }

        public Enumerations.SampleType Type { get; set; }

        public int Index { get; set; }

        public int Year { get; set; }

        public SampleKindDisplayModel Kind { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public decimal Amount { get; set; }

        public UnitMeasurementDisplayModel UnitMeasurement { get; set; }

        public string Observation { get; set; }
    }
}
