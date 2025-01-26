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
        public Microsoft.EntityFrameworkCore.DbSet<Entities.ProclamationKind> ProclamationKinds { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Proclamation> Proclamations { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.CentralStateStructure> CentralStateStructures { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.RegulationKind> RegulationKinds { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Regulation> Regulations { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Disposition> Dispositions { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.DispositionTagBridge> DispositionTagBridges { get; set; }
    }
}
