namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class LegalClientServicingContractDisplayModel : Contract.AbstractClientServicingContractDisplayModel<Persistence.Entities.LegalClientServicingContract>
    {
        public Framework.Decisor.Commercial.Interop.API.Common.Models.Display.LegalClientDisplayModel Client { get; set; }

        public override void Import(Persistence.Entities.LegalClientServicingContract entity)
        {
            base.Import(entity);

            if (entity.Client != null)
            {
                Client = new Framework.Decisor.Commercial.Interop.API.Common.Models.Display.LegalClientDisplayModel();

                Client.Import(entity.Client);
            }
        }
    }
}
