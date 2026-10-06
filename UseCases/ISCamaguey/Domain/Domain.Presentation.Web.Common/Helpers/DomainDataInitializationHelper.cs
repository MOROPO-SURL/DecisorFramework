using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Constants.Security;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Domain.Presentation.Web.Common.Helpers
{
    public class DomainDataInitializationHelper : Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission>();

            #region SampleKind
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.SampleKindViewerPermission)))
            {
                permissionDbSet.Add(Authorization.SampleKindViewerPermission.ToPermissionEntity(Authorization.SampleKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.SampleKindCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.SampleKindCreatorPermission.ToPermissionEntity(Authorization.SampleKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.SampleKindEditorPermission)))
            {
                permissionDbSet.Add(Authorization.SampleKindEditorPermission.ToPermissionEntity(Authorization.SampleKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.SampleKindRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.SampleKindRemoverPermission.ToPermissionEntity(Authorization.SampleKindManagementPermissionGroup));
            }
            #endregion

            #region Technique
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.TechniqueViewerPermission)))
            {
                permissionDbSet.Add(Authorization.TechniqueViewerPermission.ToPermissionEntity(Authorization.TechniqueManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.TechniqueCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.TechniqueCreatorPermission.ToPermissionEntity(Authorization.TechniqueManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.TechniqueEditorPermission)))
            {
                permissionDbSet.Add(Authorization.TechniqueEditorPermission.ToPermissionEntity(Authorization.TechniqueManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.TechniqueRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.TechniqueRemoverPermission.ToPermissionEntity(Authorization.TechniqueManagementPermissionGroup));
            }
            #endregion

            if (dbContext is Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext)
            {
                (dbContext as Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext).SaveChanges("system");
            }
            else
            {
                dbContext.SaveChanges();
            }
        }
    }
}

