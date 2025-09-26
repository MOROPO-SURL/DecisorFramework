namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class PropertyLeaseOrganizationPostulationDisplayModel : Contract.AbstractLeaseOrganizationPostulationDisplayModel<Persistence.Entities.PropertyLeaseOrganizationPostulation>
    {
        public PropertySpaceLeasePropousalDisplayModel[] Spaces { get; set; }

        public override void Import(Persistence.Entities.PropertyLeaseOrganizationPostulation entity)
        {
            base.Import(entity);

            OfferId = entity.OfferId;
        }
    }
}
