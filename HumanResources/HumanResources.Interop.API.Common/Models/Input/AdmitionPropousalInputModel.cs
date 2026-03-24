namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class AdmitionPropousalInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.AdmitionPropousal, System.Guid>
    {
        public System.DateTime At { get; set; }

        public System.Guid CandidateId { get; set; }

        public System.Guid AgreementId { get; set; }

        public string Argument { get; set; }

        public override Persistence.Entities.AdmitionPropousal Export()
        {
            var entity = new Persistence.Entities.AdmitionPropousal { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.AdmitionPropousal entity)
        {
            entity.At = At;
            entity.Argument = Argument;

            if (entity.OcupationCandidateId != CandidateId)
            {
                entity.OcupationCandidate = null;
                entity.OcupationCandidateId = CandidateId;
            }

            if (entity.AgreementId != AgreementId)
            {
                entity.Agreement = null;
                entity.AgreementId = AgreementId;
            }
        }
    }
}
