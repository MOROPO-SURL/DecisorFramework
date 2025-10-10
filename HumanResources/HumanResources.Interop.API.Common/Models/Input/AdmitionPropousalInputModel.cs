namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class AdmitionPropousalInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.AdmitionPropousal, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public System.Guid CandidateId { get; set; }

        public System.Guid AgreementId { get; set; }

        public string Argument { get; set; }

        public Persistence.Entities.AdmitionPropousal Export()
        {
            var entity = new Persistence.Entities.AdmitionPropousal { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.AdmitionPropousal entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.AdmitionPropousal entity)
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
