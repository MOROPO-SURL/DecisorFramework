namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Input
{
    public class NaturalClientServicingContractInputModel : Contract.AbstractClientServicingContractInputModel<Persistence.Entities.NaturalClientServicingContract>
    {
        public override Persistence.Entities.NaturalClientServicingContract Export()
        {
            var entity = new Persistence.Entities.NaturalClientServicingContract { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.NaturalClientServicingContract entity)
        {
            base.Mergue(entity);

            if (entity.ServicingNaturalClientId != ClientId)
            {
                entity.Client = null;
                entity.ServicingNaturalClientId = ClientId;
            }
        }
    }
}