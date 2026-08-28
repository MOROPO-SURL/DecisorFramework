using MOROPO.ISCamaguey.Decisor.Lab.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display
{
    public sealed class ProductionSampleDisplayModel : Contract.AbstractSampleDisplayModel<Persistence.Entities.ProductionSample>
    {
        public Framework.Decisor.Production.Interop.API.Common.Models.Display.ProductionDisplayModel Production { get; set; }

        public override void Import(ProductionSample entity)
        {
            base.Import(entity);

            if (entity.Production != null)
            {
                Production = new Framework.Decisor.Production.Interop.API.Common.Models.Display.ProductionDisplayModel();

                Production.Import(entity.Production);
            }
        }
    }
}
