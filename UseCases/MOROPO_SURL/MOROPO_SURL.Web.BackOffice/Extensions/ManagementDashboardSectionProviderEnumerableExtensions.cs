using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Models.View;
using System.Collections.Generic;

namespace MOROPO.Tool.Decisor.Web.BackOffice.Extensions
{
    public static class ManagementDashboardSectionProviderEnumerableExtensions
    {
        public static Dictionary<string, ICollection<ManagementDashboardSectionViewModel>> ToManagementDashboardSectionGroups(this IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> self)
        {
            var securitySection = new List<ManagementDashboardSectionViewModel>();
            var locationSection = new List<ManagementDashboardSectionViewModel>();
            var legalSection = new List<ManagementDashboardSectionViewModel>();
            var domainSection = new List<ManagementDashboardSectionViewModel>();
            var financialSection = new List<ManagementDashboardSectionViewModel>();
            var purchaseSection = new List<ManagementDashboardSectionViewModel>();
            var humanResourcesSection = new List<ManagementDashboardSectionViewModel>();
            var inventorySection = new List<ManagementDashboardSectionViewModel>();
            var saleSection = new List<ManagementDashboardSectionViewModel>();
            var commercialSection = new List<ManagementDashboardSectionViewModel>();

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

            #region Domain
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Ent. Admin.",
                Controller = "administrativeentitykinds",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission
                //Role = Framework.Decisor.Domain.Interop.API.Common.Constants.Security.Authorization.EmployeeViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Inmueble",
                Controller = "propertykinds",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission
                //Role = Framework.Decisor.Domain.Interop.API.Common.Constants.Security.Authorization.EmployeeViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Vehículo",
                Controller = "vehiclekinds",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission
                //Role = Framework.Decisor.Domain.Interop.API.Common.Constants.Security.Authorization.EmployeeViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Motorización",
                Controller = "vehicleenginekinds",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission
                //Role = Framework.Decisor.Domain.Interop.API.Common.Constants.Security.Authorization.EmployeeViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Pers. Jurídica",
                Controller = "legalbusinesskinds",
                Action = "Index",
                Area = "domain",
                Role = Framework.Decisor.Domain.Interop.API.Common.Constants.Security.Authorization.LegalBusinessKindViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Pers. Natural",
                Controller = "naturalbusinesskinds",
                Action = "Index",
                Area = "domain",
                Role = Framework.Decisor.Domain.Interop.API.Common.Constants.Security.Authorization.NaturalBusinessKindViewerPermission
            });
            #endregion

            #region HH.RR.
            humanResourcesSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Plaza",
                Controller = "workpositionkinds",
                Action = "Index",
                Area = "HHRR",
                Role = Framework.Decisor.HumanResources.Interop.API.Common.Constants.Security.Authorization.WorkPositionKindViewerPermission
           });
            humanResourcesSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Empleados",
                Controller = "employees",
                Action = "Index",
                Area = "HHRR",
                Role = Framework.Decisor.HumanResources.Interop.API.Common.Constants.Security.Authorization.EmployeeViewerPermission
            });
            #endregion

            #region Purchasing
            purchaseSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Compras",
                Controller = "purchases",
                Action = "Index",
                Area = "purchasing",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            purchaseSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Planes",
                Controller = "purchaseplans",
                Action = "Index",
                Area = "purchasing",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            purchaseSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Zonas",
                Controller = "purchasezones",
                Action = "Index",
                Area = "purchasing",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            purchaseSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Gasto",
                Controller = "purchasespents",
                Action = "Index",
                Area = "purchasing",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            #endregion

            #region Sales

            #endregion

            #region Globals
            #endregion

            #region Inventory
            inventorySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Almacenes",
                Controller = "warehouses",
                Action = "Index",
                Area = "inventory",
                Role = Framework.Decisor.Inventory.Interop.API.Common.Constants.Security.Authorization.WarehouseViewerPermission
            });
            inventorySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Recepciones",
                Controller = "receptions",
                Action = "Index",
                Area = "inventory",
                Role = Framework.Decisor.Inventory.Interop.API.Common.Constants.Security.Authorization.ReceptionViewerPermission
            });
            inventorySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Salidas",
                Controller = "departures",
                Action = "Index",
                Area = "inventory",
                Role = Framework.Decisor.Inventory.Interop.API.Common.Constants.Security.Authorization.DepartureViewerPermission
            });
            inventorySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Productos",
                Controller = "products",
                Action = "Index",
                Area = "inventory",
                Role = Framework.Decisor.Inventory.Interop.API.Common.Constants.Security.Authorization.ProductViewerPermission
            });
            inventorySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Categorías",
                Controller = "categories",
                Action = "Index",
                Area = "inventory",
                Role = Framework.Decisor.Inventory.Interop.API.Common.Constants.Security.Authorization.FamilyViewerPermission
            });
            inventorySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Attributos Personalizados",
                Controller = "customattributes",
                Action = "Index",
                Area = "inventory",
                Role = Framework.Decisor.Inventory.Interop.API.Common.Constants.Security.Authorization.CustomAttributeViewerPermission
            });
            inventorySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Unidades de Medida",
                Controller = "unitmeasurements",
                Action = "Index",
                Area = "domain",
                Role = Framework.Decisor.Domain.Interop.API.Common.Constants.Security.Authorization.UnitMeasurementViewerPermission
            });
            #endregion

            #region Financial
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Centros de Costo",
                Controller = "costcenters",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
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
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Pagos",
                Controller = "payments",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Recaudaciones",
                Controller = "cachings",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Caja Extra",
                Controller = "recashes",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Anticipos",
                Controller = "advances",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Reintegros",
                Controller = "backs",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Reembolsos",
                Controller = "refunds",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Depositos Bancarios",
                Controller = "bankinputs",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Extraciones Bancarias",
                Controller = "bankoutputs",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Nóminas",
                Controller = "nomns",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Remuneraciones",
                Controller = "remunerations",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            #endregion

            #region Commercial

            commercialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Clientes Jurídicos",
                Controller = "legalclients",
                Action = "Index",
                Area = "commercial",
                Role = Framework.Decisor.Commercial.Interop.API.Common.Constants.Security.Authorization.LegalClientViewerPermission
            });
            commercialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Clientes Naturales",
                Controller = "naturalclients",
                Action = "Index",
                Area = "commercial",
                Role = Framework.Decisor.Commercial.Interop.API.Common.Constants.Security.Authorization.NaturalClientViewerPermission
            });
            commercialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Proveedores Jurídicos",
                Controller = "legalproviders",
                Action = "Index",
                Area = "commercial",
                Role = Framework.Decisor.Commercial.Interop.API.Common.Constants.Security.Authorization.LegalProviderViewerPermission
            });
            commercialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Proveedores Naturales",
                Controller = "naturalproviders",
                Action = "Index",
                Area = "commercial",
                Role = Framework.Decisor.Commercial.Interop.API.Common.Constants.Security.Authorization.NaturalProviderViewerPermission
            }); commercialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Términos de Pago",
                Controller = "paymentterms",
                Action = "Index",
                Area = "commercial",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            #endregion

            return new Dictionary<string, ICollection<ManagementDashboardSectionViewModel>>
            {
                { "Seguridad", securitySection },
                { "Locación", locationSection },
                { "Jurídico", legalSection },
                { "Dominio", domainSection },
                { "Finanzas", financialSection },
                { "Recursos Humanos", humanResourcesSection },
                { "Inventario", inventorySection },
                { "Comercial", commercialSection },
                { "jump-0", null },
                { "Compras", purchaseSection },
                { "jump-1", null },
                { "Ventas", saleSection }
            };
        }
    }
}
