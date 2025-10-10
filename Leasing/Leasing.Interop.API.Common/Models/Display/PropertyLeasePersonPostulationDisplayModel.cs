namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class PropertyLeasePersonPostulationDisplayModel : Contract.AbstractLeasePersonPostulationDisplayModel<Persistence.Entities.PropertyLeasePersonPostulation>
    {
        public PropertySpaceLeasePropousalDisplayModel[] Spaces { get; set; }

        public override void Import(Persistence.Entities.PropertyLeasePersonPostulation entity)
        {
            base.Import(entity);

            OfferId = entity.OfferId;
        }
    }
}
