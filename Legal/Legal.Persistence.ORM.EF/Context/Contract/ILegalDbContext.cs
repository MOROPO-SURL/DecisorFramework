namespace MOROPO.Framework.Decisor.Legal.Persistence.ORM.EF.Context.Contract
{
    public interface ILegalDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Tag> ClauseTags { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Clause> Clauses { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.ClauseTagBridge> ClauseTagBridges { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Section> Sections { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Proforma> Proformas { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.ProformaClauseBridge> ProformaSectionClauseBridges { get; set; }
    }
}
