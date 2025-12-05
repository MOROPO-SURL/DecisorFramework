using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display
{
    public class PurchaseRequestDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PurchaseRequest, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public bool Enabled { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Author { get; set; }

        public string Argument { get; set; }

        public List<PurchaseRequestExpectedProductAdquisitionDisplayModel> ExpectedProductAdquisitions { get; set; } = new List<PurchaseRequestExpectedProductAdquisitionDisplayModel>();

        public void Import(Persistence.Entities.PurchaseRequest entity)
        {
            Id = entity.Id;
            At = entity.At;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Argument = entity.Argument;

            if (entity.Author != null)
            {
                Author = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();
                
                Author.Import(entity.Author);
            }
        }
    }
}
