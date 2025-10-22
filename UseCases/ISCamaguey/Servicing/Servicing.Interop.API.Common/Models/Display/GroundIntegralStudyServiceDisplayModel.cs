namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class GroundIntegralStudyServiceDisplayModel : Contract.AbstractServiceDisplayModel<Persistence.Entities.GroundIntegralStudyService>
    {
        public GroundIntegralStudyServiceStepDisplayModel[] Steps { get; set; }
    }
}
