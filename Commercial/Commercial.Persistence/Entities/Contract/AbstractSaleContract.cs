using MOROPO.Framework.Decisor.Legal.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Commercial.Persistence.Entities.Contract
{
    public class AbstractSaleContract : Legal.Persistence.Entities.Contract.AbstractContract
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProformaId))]
        public Proforma Proforma { get; set; }
        public System.Guid ProformaId { get; set; }
    }
}
