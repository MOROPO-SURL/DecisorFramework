namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Filter
{
    public class ChangeNotificationFilterModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.ChangeNotification, System.Guid>
    {
        public string AuthorId { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.ChangeNotification, bool>> GetSelector()
        {
            return entity => entity.AuthorId == AuthorId;
        }
    }
}
