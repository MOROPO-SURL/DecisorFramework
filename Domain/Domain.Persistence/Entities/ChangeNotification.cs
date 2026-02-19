namespace MOROPO.Framework.Decisor.Domain.Persistence.Entities
{
    public class ChangeNotification : Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public Enumerations.NotificationKind Kind { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AuthorId))]
        public Guama.Security.Personal.Persistence.Entities.User Author { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string AuthorId { get; set; }

        public Enumerations.NotificationKind Kind { get; set; }

        public Enumerations.ChangeKind ChangeKind { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(AuthorId))]
        public Guama.Security.Personal.Persistence.Entities.User Author { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string AuthorId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string EntityName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(10240)]
        public string Cached { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string Description { get; set; }

        public System.Collections.Generic.List<ChangeNotificationUserBridge> UserBridges { get; set; } = new System.Collections.Generic.List<ChangeNotificationUserBridge>();
    }
}
