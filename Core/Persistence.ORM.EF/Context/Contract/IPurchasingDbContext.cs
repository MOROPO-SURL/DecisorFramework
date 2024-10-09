namespace MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Context.Contract
{
    public interface IPurchasingDbContext : IEssentialDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Entities.LegalProvider> LegalProviders { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.NaturalProvider> NaturalProviders { get; set; }
    }
}

