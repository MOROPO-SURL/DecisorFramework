using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using MOROPO.ISCamaguey.Decisor.Production.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Models.Display
{
    public class ProductionQualityCheckDisplayModel : IEntityDisplayModel<ProductionQualityCheck, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public Framework.Decisor.Production.Interop.API.Common.Models.Display.ProductionDisplayModel Production { get; set; }

        public EmployeeDisplayModel Author { get; set; }

        public double QualityPercent { get; set; }

        public string Description { get; set; }

        public virtual void Import(ProductionQualityCheck entity)
        {
            Id = entity.Id;
            At = entity.At;
            QualityPercent = entity.QualityPercent;
            Description = entity.Description;

            if (entity.Production != null)
            {
                Production = new Framework.Decisor.Production.Interop.API.Common.Models.Display.ProductionDisplayModel();

                Production.Import(entity.Production);
            }

            if (entity.Author != null)
            {
                Author = new EmployeeDisplayModel();

                Author.Import(entity.Author);
            }
        }
    }
}
