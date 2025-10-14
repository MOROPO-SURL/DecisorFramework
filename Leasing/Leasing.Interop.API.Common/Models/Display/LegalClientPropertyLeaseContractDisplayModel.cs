namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class LegalClientPropertyLeaseContractDisplayModel : Contract.AbstractLeaseContractDisplayModel<Persistence.Entities.LegalClientPropertyLeaseContract>
    {
        public Domain.Interop.API.Common.Models.Display.PropertyDisplayModel Property { get; set; }

        public Commercial.Interop.API.Common.Models.Display.LegalClientDisplayModel Client { get; set; }

        public override void Import(Persistence.Entities.LegalClientPropertyLeaseContract entity)
        {
            base.Import(entity);

            if (entity.Postulation != null)
            {
                Property = new Domain.Interop.API.Common.Models.Display.PropertyDisplayModel();

                Property.Import(entity.Postulation.Offer.Propousal.Property);
            }

            if (entity.Client != null)
            {
                Client = new Commercial.Interop.API.Common.Models.Display.LegalClientDisplayModel();

                Client.Import(entity.Client);
            }
        }
    }
}
