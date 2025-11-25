namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class NaturalClientServicingContractDisplayModel : Contract.AbstractClientServicingContractDisplayModel<Persistence.Entities.NaturalClientServicingContract>
    {
        public Framework.Decisor.Commercial.Interop.API.Common.Models.Display.NaturalClientDisplayModel Client { get; set; }

        public override void Import(Persistence.Entities.NaturalClientServicingContract entity)
        {
            base.Import(entity);

            if (entity.Client != null)
            {
                Client = new Framework.Decisor.Commercial.Interop.API.Common.Models.Display.NaturalClientDisplayModel();

                Client.Import(entity.Client);
            }
        }
    }
}
