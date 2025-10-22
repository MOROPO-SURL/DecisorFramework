namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities.Contract
{
    public class AbstractGroundIntegralStudyServiceOrder : AbstractServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(GroundIntegralStudyServiceId))]
        public GroundIntegralStudyService Service { get; set; }
        public System.Guid GroundIntegralStudyServiceId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(GroundIntegralStudyResponsibleId))]
        public Framework.Decisor.Domain.Persistence.Entities.Employee Responsible { get; set; }
        public System.Guid GroundIntegralStudyResponsibleId { get; set; }
    }
}
