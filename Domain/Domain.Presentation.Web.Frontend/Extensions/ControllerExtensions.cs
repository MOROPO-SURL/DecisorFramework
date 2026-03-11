using MOROPO.Framework.Guama.Core.Persistence.Entities.Contract;
using MOROPO.Framework.Guama.Core.Persistence.Presentation.Models.Contract;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Frontend.Extensions;

public static class ControllerExtensions
{
    public static void ChangeNotificationOnPostCreate<TEntity, TId, TInputModel, TDisplayModel>(this Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<TEntity, TId, TInputModel, TDisplayModel> target, TEntity entity, TInputModel model, Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.ChangeNotification, System.Guid> changeNotificationRepository) where TEntity : class, IEntity<TId> where TInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<TEntity, TId>, IEntityInputModel<TEntity, TId>, new() where TDisplayModel : class, IEntityDisplayModel<TEntity, TId>, new()
    {
        if (model.NotificationUserIds == null || model.NotificationUserIds.Length <= 0) return;

        var _model = new TDisplayModel();

        _model.Import(entity);

        var notificationId = System.Guid.NewGuid();

        changeNotificationRepository.Add(new Persistence.Entities.ChangeNotification
        {
            Id = notificationId,
            Kind = Persistence.Enumerations.NotificationKind.Requested,
            AuthorId = target.User.Identity.Name,
            ChangeKind = Persistence.Enumerations.ChangeKind.Creation,
            EntityName = entity.GetType().AssemblyQualifiedName,
            Cached = Newtonsoft.Json.JsonConvert.SerializeObject(_model),
            UserBridges = model.NotificationUserIds.Select(item => new Persistence.Entities.ChangeNotificationUserBridge { ProwId = notificationId, SternId = item }).ToList()
        }, target.User.Identity.Name);
    }

    public static void ChangeNotificationOnPostEdit<TEntity, TId, TInputModel, TDisplayModel>(this Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementController<TEntity, TId, TInputModel, TDisplayModel> target, TEntity entity, TInputModel model, Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.ChangeNotification, System.Guid> changeNotificationRepository) where TEntity : class, IEntity<TId> where TInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<TEntity, TId>, IEntityInputModel<TEntity, TId>, new() where TDisplayModel : class, IEntityDisplayModel<TEntity, TId>, new()
    {
        if (model.NotificationUserIds == null || model.NotificationUserIds.Length <= 0) return;

        var _model = new TDisplayModel();

        _model.Import(entity);

        var notificationId = System.Guid.NewGuid();

        changeNotificationRepository.Add(new Persistence.Entities.ChangeNotification
        {
            Id = notificationId,
            Kind = Persistence.Enumerations.NotificationKind.Requested,
            AuthorId = target.User.Identity.Name,
            ChangeKind = Persistence.Enumerations.ChangeKind.Edition,
            EntityName = entity.GetType().AssemblyQualifiedName,
            Cached = Newtonsoft.Json.JsonConvert.SerializeObject(_model),
            UserBridges = model.NotificationUserIds.Select(item => new Persistence.Entities.ChangeNotificationUserBridge { ProwId = notificationId, SternId = item }).ToList()
        }, target.User.Identity.Name);
    }
}
