namespace MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input
{
    public class ExternalResearcherInputModel : Contract.AbstractResearcherInputModel<Persistence.Entities.ExternalResearcher>
    {
        public System.Guid ContactId { get; set; }

        public System.Guid ParticipatingOrganizationId { get; set; }

        public decimal Salary { get; set; }

        public override Persistence.Entities.ExternalResearcher Export()
        {
            var entity = new Persistence.Entities.ExternalResearcher { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.ExternalResearcher entity)
        {
            base.Mergue(entity);

            entity.Salary = Salary;

            if (entity.ContactId != ContactId)
            {
                entity.Contact = null;
                entity.ContactId = ContactId;
            }

            if (entity.ParticipatingOrganizationId != ParticipatingOrganizationId)
            {
                entity.ParticipatingOrganization = null;
                entity.ParticipatingOrganizationId = ParticipatingOrganizationId;
            }
        }
    }
}
