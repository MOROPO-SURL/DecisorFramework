namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class GroundIntegralStudyService : Contract.AbstractService
    {
        public System.Collections.Generic.ICollection<GroundIntegralStudyServiceStep> Steps { get; set; }

        public System.Collections.Generic.List<GroundIntegralStudyServiceEmployeeBridge> EmployeeBridges { get; set; } = new System.Collections.Generic.List<GroundIntegralStudyServiceEmployeeBridge>();

        public System.Collections.Generic.List<GroundIntegralStudyServiceDocumentBridge> DocumentBridges { get; set; } = new System.Collections.Generic.List<GroundIntegralStudyServiceDocumentBridge>();
    }
}
