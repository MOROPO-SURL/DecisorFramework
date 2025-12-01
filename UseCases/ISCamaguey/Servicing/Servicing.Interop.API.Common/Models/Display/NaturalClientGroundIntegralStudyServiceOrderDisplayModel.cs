
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class NaturalClientGroundIntegralStudyServiceOrderDisplayModel : Contract.AbstractGroundIntegralStudyServiceOrderDisplayModel<Persistence.Entities.NaturalClientGroundIntegralStudyServiceOrder>
    {
        public NaturalClientServicingContractDisplayModel Contract { get; set; }

        public override void Import(Persistence.Entities.NaturalClientGroundIntegralStudyServiceOrder entity)
        {
            base.Import(entity);

            if (entity.Contract != null)
            {
                Contract = new NaturalClientServicingContractDisplayModel();

                Contract.Import(entity.Contract);
            }
        }
    }
}
