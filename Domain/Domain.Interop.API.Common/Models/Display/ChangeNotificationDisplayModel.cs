namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class ChangeNotificationDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ChangeNotification, System.Guid>
    {
        public ChangeNotificationDisplayModel(System.DateTime at)
        {
            At = at;
        }

        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public System.DateTime? ReadedAt { get; set; }

        public Persistence.Enumerations.NotificationKind Kind { get; set; }

        public Persistence.Enumerations.ChangeKind ChangeKind { get; set; }

        public Core.Interop.API.Common.Models.Display.UserDisplayModel Author { get; set; }

        public string EntityName { get; set; }

        public string Cached { get; set; }

        public string Description { get; set; }

        public void Import(Persistence.Entities.ChangeNotification entity)
        {
            Id = entity.Id;
            Kind = entity.Kind;
            ChangeKind = entity.ChangeKind;
            EntityName = entity.EntityName;
            Cached = entity.Cached;
            Description = entity.Description;

            if (entity.Author != null)
            {
                Author = new Core.Interop.API.Common.Models.Display.UserDisplayModel();

                Author.Import(entity.Author);
            }
        }
    }
}
