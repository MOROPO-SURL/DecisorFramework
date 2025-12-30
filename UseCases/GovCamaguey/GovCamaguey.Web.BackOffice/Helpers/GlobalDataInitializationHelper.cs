using System.Linq;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Constants.Security;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Helpers
{
    public class GlobalDataInitializationHelper : Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission>();

            #region Person
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PersonViewerPermission)))
            {
                permissionDbSet.Add(Authorization.PersonViewerPermission.ToPermissionEntity(Authorization.PersonManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PersonCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.PersonCreatorPermission.ToPermissionEntity(Authorization.PersonManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PersonEditorPermission)))
            {
                permissionDbSet.Add(Authorization.PersonEditorPermission.ToPermissionEntity(Authorization.PersonManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PersonRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.PersonRemoverPermission.ToPermissionEntity(Authorization.PersonManagementPermissionGroup));
            }
            #endregion

            #region Organization
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.OrganizationViewerPermission)))
            {
                permissionDbSet.Add(Authorization.OrganizationViewerPermission.ToPermissionEntity(Authorization.OrganizationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.OrganizationCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.OrganizationCreatorPermission.ToPermissionEntity(Authorization.OrganizationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.OrganizationEditorPermission)))
            {
                permissionDbSet.Add(Authorization.OrganizationEditorPermission.ToPermissionEntity(Authorization.OrganizationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.OrganizationRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.OrganizationRemoverPermission.ToPermissionEntity(Authorization.OrganizationManagementPermissionGroup));
            }
            #endregion

            #region Objective
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ObjectiveViewerPermission)))
            {
                permissionDbSet.Add(Authorization.ObjectiveViewerPermission.ToPermissionEntity(Authorization.ObjectiveManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ObjectiveCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.ObjectiveCreatorPermission.ToPermissionEntity(Authorization.ObjectiveManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ObjectiveEditorPermission)))
            {
                permissionDbSet.Add(Authorization.ObjectiveEditorPermission.ToPermissionEntity(Authorization.ObjectiveManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.ObjectiveRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.ObjectiveRemoverPermission.ToPermissionEntity(Authorization.ObjectiveManagementPermissionGroup));
            }
            #endregion

            #region Guideline
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.GuidelineViewerPermission)))
            {
                permissionDbSet.Add(Authorization.GuidelineViewerPermission.ToPermissionEntity(Authorization.GuidelineManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.GuidelineCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.GuidelineCreatorPermission.ToPermissionEntity(Authorization.GuidelineManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.GuidelineEditorPermission)))
            {
                permissionDbSet.Add(Authorization.GuidelineEditorPermission.ToPermissionEntity(Authorization.GuidelineManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.GuidelineRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.GuidelineRemoverPermission.ToPermissionEntity(Authorization.GuidelineManagementPermissionGroup));
            }
            #endregion

            #region UnitMeasurement
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.UnitMeasurementViewerPermission)))
            {
                permissionDbSet.Add(Authorization.UnitMeasurementViewerPermission.ToPermissionEntity(Authorization.UnitMeasurementManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.UnitMeasurementCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.UnitMeasurementCreatorPermission.ToPermissionEntity(Authorization.UnitMeasurementManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.UnitMeasurementEditorPermission)))
            {
                permissionDbSet.Add(Authorization.UnitMeasurementEditorPermission.ToPermissionEntity(Authorization.UnitMeasurementManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.UnitMeasurementRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.UnitMeasurementRemoverPermission.ToPermissionEntity(Authorization.UnitMeasurementManagementPermissionGroup));
            }
            #endregion

            #region GlobalIndicator
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.GlobalIndicatorViewerPermission)))
            {
                permissionDbSet.Add(Authorization.GlobalIndicatorViewerPermission.ToPermissionEntity(Authorization.GlobalIndicatorManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.GlobalIndicatorCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.GlobalIndicatorCreatorPermission.ToPermissionEntity(Authorization.GlobalIndicatorManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.GlobalIndicatorEditorPermission)))
            {
                permissionDbSet.Add(Authorization.GlobalIndicatorEditorPermission.ToPermissionEntity(Authorization.GlobalIndicatorManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.GlobalIndicatorRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.GlobalIndicatorRemoverPermission.ToPermissionEntity(Authorization.GlobalIndicatorManagementPermissionGroup));
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

