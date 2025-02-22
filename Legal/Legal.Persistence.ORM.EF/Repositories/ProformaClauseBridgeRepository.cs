namespace MOROPO.Framework.Decisor.Legal.Persistence.ORM.EF.Repositories
{
    public class ProformaClauseBridgeRepository : Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractBridgeRepository<Entities.ProformaClauseBridge, Entities.Proforma, System.Guid, Entities.Clause, System.Guid>
    {
        public ProformaClauseBridgeRepository(Microsoft.EntityFrameworkCore.DbContext dbContext) : base(dbContext)
        {
        }
    }
}
