using MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Domain.Persistence.Entities
{
    public class Technique : Framework.Decisor.Core.Persistence.Entities.Contract.IFullFeatureEntity<Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Archived { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AbstracBaseFormulaId))]
        public AbstracBaseFormula AbstracBaseFormula { get; set; }
        public System.Guid AbstracBaseFormulaId { get; set; }

        public System.Collections.Generic.List<TechniqueCubanStandardBridge> CubanStandardBridge {  get; set; } = new System.Collections.Generic.List<TechniqueCubanStandardBridge>();

        public System.Collections.Generic.List<TechniqueIsoStandardBridge> IsoStandardBridge { get; set;} = new System.Collections.Generic.List<TechniqueIsoStandardBridge>();

    }
}
