namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class ChangeNotificationUserBridge : Guama.Core.Persistence.Entities.Contract.IBridge<ChangeNotification, System.Guid, Guama.Security.Personal.Persistence.Entities.User, string>
    {
        public System.Guid ProwId { get; set; }
        public ChangeNotification Prow { get; set; }

        public string SternId { get; set; }
        public Guama.Security.Personal.Persistence.Entities.User Stern { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public System.DateTime? ReadedAt { get; set; }
    }
}