namespace MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Context.Contract
{
	public interface ISalesDbContext : IEssentialDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Entities.LegalClient> LegalClients { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.NaturalClient> NaturalClients { get; set; }
    }
}

