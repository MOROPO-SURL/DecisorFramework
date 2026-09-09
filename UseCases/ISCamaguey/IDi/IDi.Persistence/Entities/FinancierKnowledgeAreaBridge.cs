using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities
{
    public class FinancierKnowledgeAreaBridge : Framework.Guama.Core.Persistence.Entities.Contract.IBridge<Financier, System.Guid, KnowledgeArea, System.Guid>
    {
        public System.Guid ProwId { get; set; }
        public Financier Prow { get; set; }

        public System.Guid SternId { get; set; }
        public KnowledgeArea Stern { get; set; }
    }
}
