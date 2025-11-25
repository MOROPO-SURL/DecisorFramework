namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class LegalClientServicingContractInputModel : Contract.AbstractClientServicingContractInputModel<Persistence.Entities.LegalClientServicingContract>
    {
        public override Persistence.Entities.LegalClientServicingContract Export()
        {
            var entity = new Persistence.Entities.LegalClientServicingContract { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.LegalClientServicingContract entity)
        {
            base.Mergue(entity);

            if (entity.ServicingLegalClientId != ClientId)
            {
                entity.Client = null;
                entity.ServicingLegalClientId = ClientId;
            }
        }
    }
}
