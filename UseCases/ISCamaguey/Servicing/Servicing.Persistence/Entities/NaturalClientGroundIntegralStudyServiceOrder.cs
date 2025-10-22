namespace MOROPO.ISCamaguey.Decisor.Servicing.Persistence.Entities
{
    public class NaturalClientGroundIntegralStudyServiceOrder : Contract.AbstractGroundIntegralStudyServiceOrder
    {
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(GroundIntegralStudyNaturalClientId))]
        public Framework.Decisor.Commercial.Persistence.Entities.NaturalClient Client { get; set; }
        public System.Guid GroundIntegralStudyNaturalClientId { get; set; }
    }
}
