namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class LegalClientGroundIntegralStudyServiceOrder : Contract.AbstractGroundIntegralStudyServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(GroundIntegralStudyLegalClientId))]
        public Framework.Decisor.Commercial.Persistence.Entities.LegalClient Client { get; set; }
        public System.Guid GroundIntegralStudyLegalClientId { get; set; }
    }
}
