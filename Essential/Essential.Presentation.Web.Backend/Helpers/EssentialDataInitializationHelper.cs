using System.Linq;
using MOROPO.Framework.Decisor.Essential.Presentation.Web.Backend.Constants.Security;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;

namespace MOROPO.Framework.Decisor.Essential.Presentation.Web.Backend.Helpers
{
    public class EssentialDataInitializationHelper : Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Guama.Core.Security.Common.Persistence.Entities.Permission>();

            #region Colaborator
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ColaboratorViewerPermission)))
            {
                permissionDbSet.Add(Authorization.ColaboratorViewerPermission.ToPermissionEntity(Authorization.ColaboratorManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ColaboratorCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.ColaboratorCreatorPermission.ToPermissionEntity(Authorization.ColaboratorManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ColaboratorEditorPermission)))
            {
                permissionDbSet.Add(Authorization.ColaboratorEditorPermission.ToPermissionEntity(Authorization.ColaboratorManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ColaboratorRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.ColaboratorRemoverPermission.ToPermissionEntity(Authorization.ColaboratorManagementPermissionGroup));
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
