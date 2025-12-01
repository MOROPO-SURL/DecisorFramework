
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class LegalClientGroundIntegralStudyServiceOrderDisplayModel : Contract.AbstractGroundIntegralStudyServiceOrderDisplayModel<Persistence.Entities.LegalClientGroundIntegralStudyServiceOrder>
    {
        public LegalClientServicingContractDisplayModel Contract { get; set; }

        public override void Import(Persistence.Entities.LegalClientGroundIntegralStudyServiceOrder entity)
        {
            base.Import(entity);

            if (entity.Contract != null)
            {
                Contract = new LegalClientServicingContractDisplayModel();

                Contract.Import(entity.Contract);
            }
        }
    }
}
