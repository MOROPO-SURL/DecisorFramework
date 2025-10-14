namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class NaturalClientPropertyLeaseContractDisplayModel : Contract.AbstractLeaseContractDisplayModel<Persistence.Entities.NaturalClientPropertyLeaseContract>
    {
        public Domain.Interop.API.Common.Models.Display.PropertyDisplayModel Property { get; set; }

        public Commercial.Interop.API.Common.Models.Display.NaturalClientDisplayModel Client { get; set; }

        public override void Import(Persistence.Entities.NaturalClientPropertyLeaseContract entity)
        {
            base.Import(entity);

            if (entity.Postulation != null)
            {
                Property = new Domain.Interop.API.Common.Models.Display.PropertyDisplayModel();

                Property.Import(entity.Postulation.Offer.Propousal.Property);
            }

            if (entity.Client != null)
            {
                Client = new Commercial.Interop.API.Common.Models.Display.NaturalClientDisplayModel();

                Client.Import(entity.Client);
            }
        }
    }
}
