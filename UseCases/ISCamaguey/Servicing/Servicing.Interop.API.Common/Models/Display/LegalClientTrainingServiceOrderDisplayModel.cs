
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class LegalClientTrainingServiceOrderDisplayModel : Contract.AbstractTrainingServiceOrderDisplayModel<Persistence.Entities.LegalClientTrainingServiceOrder>
    {
        public LegalClientServicingContractDisplayModel Contract { get; set; }

        public override void Import(Persistence.Entities.LegalClientTrainingServiceOrder entity)
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
