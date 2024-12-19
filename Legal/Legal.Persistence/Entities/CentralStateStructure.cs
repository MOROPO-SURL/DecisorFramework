namespace MOROPO.Framework.Decisor.Legal.Persistence.Entities
{
    public class CentralStateStructure : Guama.Core.Persistence.Entities.Contract.IArchivableEntity<System.Guid>, Guama.Core.Persistence.Entities.Contract.IPriorizableEntity<System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Archived { get; set; }

        public int Priority { get; set; }

        public Guama.Identity.Persistence.Entities.OrganizationIdentity Identity { get; set; }
        public System.Guid IdentityId { get; set; }
    }
}
