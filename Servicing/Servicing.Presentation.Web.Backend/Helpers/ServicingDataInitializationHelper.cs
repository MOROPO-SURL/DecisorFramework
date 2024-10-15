using System.Linq;
using MOROPO.Framework.Decisor.Servicing.Presentation.Web.Backend.Constants.Security;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;

namespace MOROPO.Framework.Decisor.Servicing.Presentation.Web.Backend.Helpers
{
    public class ServicingDataInitializationHelper : Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Guama.Core.Security.Common.Persistence.Entities.Permission>();

            #region Service
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ServiceViewerPermission)))
            {
                permissionDbSet.Add(Authorization.ServiceViewerPermission.ToPermissionEntity(Authorization.ServiceManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ServiceCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.ServiceCreatorPermission.ToPermissionEntity(Authorization.ServiceManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ServiceEditorPermission)))
            {
                permissionDbSet.Add(Authorization.ServiceEditorPermission.ToPermissionEntity(Authorization.ServiceManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ServiceRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.ServiceRemoverPermission.ToPermissionEntity(Authorization.ServiceManagementPermissionGroup));
            }
            #endregion

            if (dbContext is Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext)
            {
                (dbContext as Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext).SaveChanges("system");
            }
            else
            {
                dbContext.SaveChanges();
            }
        }
    }
}
