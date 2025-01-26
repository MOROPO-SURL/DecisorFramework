using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Constants.Security;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Constants.Security;
using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Models.View;
using System.Collections.Generic;

namespace MOROPO.EPTCamaguey.Decisor.Web.BackOffice.Extensions
{
    public static class ManagementDashboardSectionProviderEnumerableExtensions
    {
        public static Dictionary<string, ICollection<ManagementDashboardSectionViewModel>> ToManagementDashboardSectionGroups(this IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> self)
        {
            var securitySection = new List<ManagementDashboardSectionViewModel>();
            var locationSection = new List<ManagementDashboardSectionViewModel>();
            var financialSection = new List<ManagementDashboardSectionViewModel>();
            var legalSection = new List<ManagementDashboardSectionViewModel>();
            var humanResourcesSection = new List<ManagementDashboardSectionViewModel>();
            var domainSection = new List<ManagementDashboardSectionViewModel>();
            var servicingSection = new List<ManagementDashboardSectionViewModel>();
            var globalsSection = new List<ManagementDashboardSectionViewModel>();

            #region Security
            foreach (var provider in self)
            {
                if (provider is Framework.Guama.Security.Personal.Presentation.Web.Backend.Providers.ManagementDashboardSectionProvider)
                {
                    securitySection.AddRange(provider.GetManagementDashboardSections());
                }
            }

            securitySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Registros",
                Controller = "traces",
                Action = "index",
                Area = "security",
                Role = Framework.Decisor.Core.Presentation.Web.Backend.Constants.Security.Authorization.TraceViewerPermission
            });
            #endregion

            #region Location
            locationSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Países",
                Controller = "countries",
                Action = "index",
                Area = "location",
                Role = Framework.Guama.Location.Presentation.Constants.Permissions.CountryViewer
            });
            locationSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Regiones",
                Controller = "regions",
                Action = "index",
                Area = "location",
                Role = Framework.Guama.Location.Presentation.Constants.Permissions.RegionViewer
            });
            locationSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Provincias",
                Controller = "states",
                Action = "index",
                Area = "location",
                Role = Framework.Guama.Location.Presentation.Constants.Permissions.StateViewer
            });
            locationSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Municipios",
                Controller = "municipalities",
                Action = "index",
                Area = "location",
                Role = Framework.Guama.Location.Presentation.Constants.Permissions.MunicipalityViewer
            });
            #endregion

            #region HH.RR.
            humanResourcesSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Empleados",
                Controller = "employees",
                Action = "Index",
                Area = "HHRR",
                Role = Authorization.EmployeeViewerPermission
            });
            #endregion

            #region Globals
            globalsSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Pers. Jurídica",
                Controller = "legalbusinesskinds",
                Action = "Index",
                Area = "globals",
                Role = Framework.Decisor.Core.Presentation.Web.Backend.Constants.Security.Authorization.LegalBusinessKindViewerPermission
            });
            globalsSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Pers. Natural",
                Controller = "naturalbusinesskinds",
                Action = "Index",
                Area = "globals",
                Role = Framework.Decisor.Core.Presentation.Web.Backend.Constants.Security.Authorization.NaturalBusinessKindViewerPermission
            });
            #endregion

            #region Financial
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Centros de Costo",
                Controller = "costcenters",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission to Frontend too!!
                Role = Framework.Decisor.Financial.Interop.API.Common.Constants.Security.Authorization.CostCenterViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Agencias Bancarias",
                Controller = "bankagencies",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Sucursales Bancarias",
                Controller = "bankbranches",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Cuentas Bancarias",
                Controller = "bankaccounts",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tarjetas Bancarias de Débito",
                Controller = "bankdebitcards",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Monedas",
                Controller = "currencies",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Cobros",
                Controller = "incomes",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            #endregion

            #region Domain
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Estructuras",
                Controller = "structures",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Inmuebles",
                Controller = "properties",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Vehículos",
                Controller = "vehicles",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Estructura",
                Controller = "structurekinds",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Inmueble",
                Controller = "propertykinds",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Categorías de Vehículo",
                Controller = "vehiclecategories",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Motorización",
                Controller = "vehicleenginekinds",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Acuerdos de C/D",
                Controller = "deals",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            #endregion

            #region Legal
            legalSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Resoluciones",
                Controller = "namingresolutions",
                Action = "Index",
                Area = "legal",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            legalSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Proformas",
                Controller = "proformas",
                Action = "Index",
                Area = "legal",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            legalSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Secciones",
                Controller = "sections",
                Action = "Index",
                Area = "legal",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            legalSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Cláusulas",
                Controller = "clauses",
                Action = "Index",
                Area = "legal",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            legalSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Etiquetas",
                Controller = "tags",
                Action = "Index",
                Area = "legal",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            #endregion

            #region Servicing
            servicingSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Contratos de Arrendamiento",
                Controller = "contracts",
                Action = "Index",
                Area = "servicing",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            servicingSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Licencias Operativas",
                Controller = "operativelicensing",
                Action = "Index",
                Area = "servicing",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            servicingSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Clientes Jurídicos",
                Controller = "legalclients",
                Action = "Index",
                Area = "servicing",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            servicingSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Clientes Naturales",
                Controller = "naturalclients",
                Action = "Index",
                Area = "servicing",
                // TODO Set spected permission !!
                //Role = Framework.Decisor.Financial.Presentation.Web.Backend.Constants.Security.Authorization.CostCenterViewerPermission
            });
            #endregion

            return new Dictionary<string, ICollection<ManagementDashboardSectionViewModel>>
            {
                { "Seguridad", securitySection },
                { "Locación", locationSection },
                { "Dominio", domainSection },
                { "Recursos Humanos", humanResourcesSection },
                { "Finanzas", financialSection },
                { "Jurídico", legalSection },
                { "Servicios", servicingSection },
                { "Generales", globalsSection }
            };
        }
    }
}
