namespace MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Context.Contract
{
	public interface ICoreDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Entities.LegalBusinessKind> LegalBusinessKinds { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.NaturalBusinessKind> NaturalBusinessKinds { get; set; }
    }
}

