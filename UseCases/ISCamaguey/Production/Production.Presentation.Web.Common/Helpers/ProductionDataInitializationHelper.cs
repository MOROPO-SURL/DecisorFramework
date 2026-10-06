using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Constants.Security;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Production.Presentation.Web.Common.Helpers;

public class ProductionDataInitializationHelper : Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
{
    public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
    {
        var permissionDbSet = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission>();

        #region ProductionQualityCheck
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionQualityCheckViewerPermission)))
        {
            permissionDbSet.Add(Authorization.ProductionQualityCheckViewerPermission.ToPermissionEntity(Authorization.ProductionQualityCheckManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionQualityCheckCreatorPermission)))
        {
            permissionDbSet.Add(Authorization.ProductionQualityCheckCreatorPermission.ToPermissionEntity(Authorization.ProductionQualityCheckManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionQualityCheckEditorPermission)))
        {
            permissionDbSet.Add(Authorization.ProductionQualityCheckEditorPermission.ToPermissionEntity(Authorization.ProductionQualityCheckManagementPermissionGroup));
        }
        if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProductionQualityCheckRemoverPermission)))
        {
            permissionDbSet.Add(Authorization.ProductionQualityCheckRemoverPermission.ToPermissionEntity(Authorization.ProductionQualityCheckManagementPermissionGroup));
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

