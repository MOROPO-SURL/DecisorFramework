namespace MOROPO.Framework.Decisor.Governance.Persistence.ORM.EF.Context.Contract
{
    public interface IGovernanceDbContext : HumanResources.Persistence.ORM.EF.Context.Contract.IHumanResourcesDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Entities.DecisionMakingGroup> DecisionMakingGroups { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.DecisionMakingGroupEmployeeBridge> DecisionMakingGroupEmployeeBridges { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.DecisionMakingGroupContactBridge> DecisionMakingGroupContactBridges { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Meeting> Meetings { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.MeetingEmployeeBridge> MeetingEmployeeBridges { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.MeetingContactBridge> MeetingContactBridges { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.MeetingDocumentBridge> MeetingDocumentBridges { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Agreement> Agreements { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Entities.Statement> Statements { get; set; }
    }
}
