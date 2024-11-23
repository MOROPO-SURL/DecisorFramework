using Microsoft.EntityFrameworkCore;

namespace MOROPO.Framework.Decisor.Essential.Persistence.ORM.EF.Context.Contract
{
	public interface IEssentialDbContext
    {
        public DbSet<Entities.Colaborator> Colaborators { get; set; }
    }
}