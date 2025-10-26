using System.Linq;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Constants.Security;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Common.Helpers
{
    public class DomainDataInitializationHelper : Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
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

            #region Brand
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.BrandViewerPermission)))
            {
                permissionDbSet.Add(Authorization.BrandViewerPermission.ToPermissionEntity(Authorization.BrandManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.BrandCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.BrandCreatorPermission.ToPermissionEntity(Authorization.BrandManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.BrandEditorPermission)))
            {
                permissionDbSet.Add(Authorization.BrandEditorPermission.ToPermissionEntity(Authorization.BrandManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.BrandRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.BrandRemoverPermission.ToPermissionEntity(Authorization.BrandManagementPermissionGroup));
            }
            #endregion

            #region Employee
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.EmployeeViewerPermission)))
            {
                permissionDbSet.Add(Authorization.EmployeeViewerPermission.ToPermissionEntity(Authorization.EmployeeManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.EmployeeCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.EmployeeCreatorPermission.ToPermissionEntity(Authorization.EmployeeManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.EmployeeEditorPermission)))
            {
                permissionDbSet.Add(Authorization.EmployeeEditorPermission.ToPermissionEntity(Authorization.EmployeeManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.EmployeeRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.EmployeeRemoverPermission.ToPermissionEntity(Authorization.EmployeeManagementPermissionGroup));
            }
            #endregion

            #region OrganizationalUnity
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.OrganizationalUnityViewerPermission)))
            {
                permissionDbSet.Add(Authorization.OrganizationalUnityViewerPermission.ToPermissionEntity(Authorization.OrganizationalUnityManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.OrganizationalUnityCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.OrganizationalUnityCreatorPermission.ToPermissionEntity(Authorization.OrganizationalUnityManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.OrganizationalUnityEditorPermission)))
            {
                permissionDbSet.Add(Authorization.OrganizationalUnityEditorPermission.ToPermissionEntity(Authorization.OrganizationalUnityManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.OrganizationalUnityRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.OrganizationalUnityRemoverPermission.ToPermissionEntity(Authorization.OrganizationalUnityManagementPermissionGroup));
            }
            #endregion

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

            #region OrganizationContact
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.OrganizationContactViewerPermission)))
            {
                permissionDbSet.Add(Authorization.OrganizationContactViewerPermission.ToPermissionEntity(Authorization.OrganizationContactManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.OrganizationContactCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.OrganizationContactCreatorPermission.ToPermissionEntity(Authorization.OrganizationContactManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.OrganizationContactEditorPermission)))
            {
                permissionDbSet.Add(Authorization.OrganizationContactEditorPermission.ToPermissionEntity(Authorization.OrganizationContactManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.OrganizationContactRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.OrganizationContactRemoverPermission.ToPermissionEntity(Authorization.OrganizationContactManagementPermissionGroup));
            }
            #endregion

            #region PersonContact
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PersonContactViewerPermission)))
            {
                permissionDbSet.Add(Authorization.PersonContactViewerPermission.ToPermissionEntity(Authorization.PersonContactManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PersonContactCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.PersonContactCreatorPermission.ToPermissionEntity(Authorization.PersonContactManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PersonContactEditorPermission)))
            {
                permissionDbSet.Add(Authorization.PersonContactEditorPermission.ToPermissionEntity(Authorization.PersonContactManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PersonContactRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.PersonContactRemoverPermission.ToPermissionEntity(Authorization.PersonContactManagementPermissionGroup));
            }
            #endregion

            #region Property
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PropertyViewerPermission)))
            {
                permissionDbSet.Add(Authorization.PropertyViewerPermission.ToPermissionEntity(Authorization.PropertyManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PropertyCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.PropertyCreatorPermission.ToPermissionEntity(Authorization.PropertyManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PropertyEditorPermission)))
            {
                permissionDbSet.Add(Authorization.PropertyEditorPermission.ToPermissionEntity(Authorization.PropertyManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PropertyRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.PropertyRemoverPermission.ToPermissionEntity(Authorization.PropertyManagementPermissionGroup));
            }
            #endregion

            #region PropertyKind
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PropertyKindViewerPermission)))
            {
                permissionDbSet.Add(Authorization.PropertyKindViewerPermission.ToPermissionEntity(Authorization.PropertyKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PropertyKindCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.PropertyKindCreatorPermission.ToPermissionEntity(Authorization.PropertyKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PropertyKindEditorPermission)))
            {
                permissionDbSet.Add(Authorization.PropertyKindEditorPermission.ToPermissionEntity(Authorization.PropertyKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.PropertyKindRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.PropertyKindRemoverPermission.ToPermissionEntity(Authorization.PropertyKindManagementPermissionGroup));
            }
            #endregion

            #region Structure
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.StructureViewerPermission)))
            {
                permissionDbSet.Add(Authorization.StructureViewerPermission.ToPermissionEntity(Authorization.StructureManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.StructureCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.StructureCreatorPermission.ToPermissionEntity(Authorization.StructureManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.StructureEditorPermission)))
            {
                permissionDbSet.Add(Authorization.StructureEditorPermission.ToPermissionEntity(Authorization.StructureManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.StructureRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.StructureRemoverPermission.ToPermissionEntity(Authorization.StructureManagementPermissionGroup));
            }
            #endregion

            #region StructureKind
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.StructureKindViewerPermission)))
            {
                permissionDbSet.Add(Authorization.StructureKindViewerPermission.ToPermissionEntity(Authorization.StructureKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.StructureKindCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.StructureKindCreatorPermission.ToPermissionEntity(Authorization.StructureKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.StructureKindEditorPermission)))
            {
                permissionDbSet.Add(Authorization.StructureKindEditorPermission.ToPermissionEntity(Authorization.StructureKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.StructureKindRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.StructureKindRemoverPermission.ToPermissionEntity(Authorization.StructureKindManagementPermissionGroup));
            }
            #endregion

            #region Vehicle
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VehicleViewerPermission)))
            {
                permissionDbSet.Add(Authorization.VehicleViewerPermission.ToPermissionEntity(Authorization.VehicleManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VehicleCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.VehicleCreatorPermission.ToPermissionEntity(Authorization.VehicleManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VehicleEditorPermission)))
            {
                permissionDbSet.Add(Authorization.VehicleEditorPermission.ToPermissionEntity(Authorization.VehicleManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VehicleRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.VehicleRemoverPermission.ToPermissionEntity(Authorization.VehicleManagementPermissionGroup));
            }
            #endregion

            #region VehicleEngineKind
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VehicleEngineKindViewerPermission)))
            {
                permissionDbSet.Add(Authorization.VehicleEngineKindViewerPermission.ToPermissionEntity(Authorization.VehicleEngineKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VehicleEngineKindCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.VehicleEngineKindCreatorPermission.ToPermissionEntity(Authorization.VehicleEngineKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VehicleEngineKindEditorPermission)))
            {
                permissionDbSet.Add(Authorization.VehicleEngineKindEditorPermission.ToPermissionEntity(Authorization.VehicleEngineKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VehicleEngineKindRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.VehicleEngineKindRemoverPermission.ToPermissionEntity(Authorization.VehicleEngineKindManagementPermissionGroup));
            }
            #endregion

            #region VehicleKind
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VehicleKindViewerPermission)))
            {
                permissionDbSet.Add(Authorization.VehicleKindViewerPermission.ToPermissionEntity(Authorization.VehicleKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VehicleKindCreatorPermission)))
            {
                permissionDbSet.Add(Authorization.VehicleKindCreatorPermission.ToPermissionEntity(Authorization.VehicleKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VehicleKindEditorPermission)))
            {
                permissionDbSet.Add(Authorization.VehicleKindEditorPermission.ToPermissionEntity(Authorization.VehicleKindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(role => role.Code.Equals(Authorization.VehicleKindRemoverPermission)))
            {
                permissionDbSet.Add(Authorization.VehicleKindRemoverPermission.ToPermissionEntity(Authorization.VehicleKindManagementPermissionGroup));
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

