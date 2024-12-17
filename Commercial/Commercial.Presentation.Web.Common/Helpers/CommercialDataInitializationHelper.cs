using System.Linq;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Constants.Security;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Common.Helpers
{
    public class CommercialDataInitializationHelper : Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Guama.Core.Security.Common.Persistence.Entities.Permission>();

            #region LegalBusinessKind
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalBusinessKindViewerPermission)))
            {
                permissionDbSet.Add(Authorization.LegalBusinessKindViewerPermission.ToPermissionEntity(Authorization.LegalBusinessKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalBusinessKindCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.LegalBusinessKindCreatorPermission.ToPermissionEntity(Authorization.LegalBusinessKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalBusinessKindEditorPermission)))
            {
                permissionDbSet.Add(Authorization.LegalBusinessKindEditorPermission.ToPermissionEntity(Authorization.LegalBusinessKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalBusinessKindRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.LegalBusinessKindRemoverPermission.ToPermissionEntity(Authorization.LegalBusinessKindManagementPermissionGroup));
            }
            #endregion

            #region NaturalBusinessKind
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalBusinessKindViewerPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalBusinessKindViewerPermission.ToPermissionEntity(Authorization.NaturalBusinessKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalBusinessKindCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalBusinessKindCreatorPermission.ToPermissionEntity(Authorization.NaturalBusinessKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalBusinessKindEditorPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalBusinessKindEditorPermission.ToPermissionEntity(Authorization.NaturalBusinessKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalBusinessKindRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalBusinessKindRemoverPermission.ToPermissionEntity(Authorization.NaturalBusinessKindManagementPermissionGroup));
            }
            #endregion

            #region LegalProvider
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalProviderViewerPermission)))
            {
                permissionDbSet.Add(Authorization.LegalProviderViewerPermission.ToPermissionEntity(Authorization.LegalProviderManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalProviderCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.LegalProviderCreatorPermission.ToPermissionEntity(Authorization.LegalProviderManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalProviderEditorPermission)))
            {
                permissionDbSet.Add(Authorization.LegalProviderEditorPermission.ToPermissionEntity(Authorization.LegalProviderManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalProviderRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.LegalProviderRemoverPermission.ToPermissionEntity(Authorization.LegalProviderManagementPermissionGroup));
            }
            #endregion

            #region NaturalProvider
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalProviderViewerPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalProviderViewerPermission.ToPermissionEntity(Authorization.NaturalProviderManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalProviderCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalProviderCreatorPermission.ToPermissionEntity(Authorization.NaturalProviderManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalProviderEditorPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalProviderEditorPermission.ToPermissionEntity(Authorization.NaturalProviderManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalProviderRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalProviderRemoverPermission.ToPermissionEntity(Authorization.NaturalProviderManagementPermissionGroup));
            }
            #endregion

            #region LegalClient
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientViewerPermission)))
            {
                permissionDbSet.Add(Authorization.LegalClientViewerPermission.ToPermissionEntity(Authorization.LegalClientManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.LegalClientCreatorPermission.ToPermissionEntity(Authorization.LegalClientManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientEditorPermission)))
            {
                permissionDbSet.Add(Authorization.LegalClientEditorPermission.ToPermissionEntity(Authorization.LegalClientManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.LegalClientRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.LegalClientRemoverPermission.ToPermissionEntity(Authorization.LegalClientManagementPermissionGroup));
            }
            #endregion

            #region NaturalClient
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientViewerPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalClientViewerPermission.ToPermissionEntity(Authorization.NaturalClientManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalClientCreatorPermission.ToPermissionEntity(Authorization.NaturalClientManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientEditorPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalClientEditorPermission.ToPermissionEntity(Authorization.NaturalClientManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.NaturalClientRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.NaturalClientRemoverPermission.ToPermissionEntity(Authorization.NaturalClientManagementPermissionGroup));
            }
            #endregion

            #region RequestableService
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.RequestableServiceViewerPermission)))
            {
                permissionDbSet.Add(Authorization.RequestableServiceViewerPermission.ToPermissionEntity(Authorization.RequestableServiceManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.RequestableServiceCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.RequestableServiceCreatorPermission.ToPermissionEntity(Authorization.RequestableServiceManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.RequestableServiceEditorPermission)))
            {
                permissionDbSet.Add(Authorization.RequestableServiceEditorPermission.ToPermissionEntity(Authorization.RequestableServiceManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.RequestableServiceRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.RequestableServiceRemoverPermission.ToPermissionEntity(Authorization.RequestableServiceManagementPermissionGroup));
            }
            #endregion

            #region ProvisionableService
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProvisionableServiceViewerPermission)))
            {
                permissionDbSet.Add(Authorization.ProvisionableServiceViewerPermission.ToPermissionEntity(Authorization.ProvisionableServiceManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProvisionableServiceCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.ProvisionableServiceCreatorPermission.ToPermissionEntity(Authorization.ProvisionableServiceManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProvisionableServiceEditorPermission)))
            {
                permissionDbSet.Add(Authorization.ProvisionableServiceEditorPermission.ToPermissionEntity(Authorization.ProvisionableServiceManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ProvisionableServiceRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.ProvisionableServiceRemoverPermission.ToPermissionEntity(Authorization.ProvisionableServiceManagementPermissionGroup));
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

