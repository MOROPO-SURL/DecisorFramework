namespace MOROPO.Framework.Decisor.HumanResources.Persistence.Entities
{
    public class StaffStatsSnapshut : Guama.Core.Persistence.Entities.Contract.IEntity<long>
    {
        public long Id { get; set; }
        
        public System.DateTime At { get; set; } = System.DateTime.Now;

        public int VacantCount { get; set; }

        public int OcupationCount { get; set; }
    }
}
