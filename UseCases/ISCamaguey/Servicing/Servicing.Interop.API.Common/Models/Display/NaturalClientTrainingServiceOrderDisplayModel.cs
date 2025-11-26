
namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class NaturalClientTrainingServiceOrderDisplayModel : Contract.AbstractTrainingServiceOrderDisplayModel<Persistence.Entities.NaturalClientTrainingServiceOrder>
    {
        public NaturalClientServicingContractDisplayModel Contract { get; set; }

        public override void Import(Persistence.Entities.NaturalClientTrainingServiceOrder entity)
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
