using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Models.View;
using System.Collections.Generic;

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Extensions
{
    public static class ManagementDashboardSectionProviderEnumerableExtensions
    {
        public static Dictionary<string, ICollection<ManagementDashboardSectionViewModel>> ToManagementDashboardSectionGroups(this IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> self)
        {
            var securitySection = new List<ManagementDashboardSectionViewModel>();
            var locationSection = new List<ManagementDashboardSectionViewModel>();
            var domainSection = new List<ManagementDashboardSectionViewModel>();
            var humanResourcesSection = new List<ManagementDashboardSectionViewModel>();
            var commercialSection = new List<ManagementDashboardSectionViewModel>();
            var researchSection = new List<ManagementDashboardSectionViewModel>();
            var techServicingSection = new List<ManagementDashboardSectionViewModel>();
            var productionSection = new List<ManagementDashboardSectionViewModel>();
            var laboratorySection = new List<ManagementDashboardSectionViewModel>();
            var recomendationSection = new List<ManagementDashboardSectionViewModel>();
            var qualitySection = new List<ManagementDashboardSectionViewModel>();

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
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Unidades de Medida",
                Controller = "unitmeasurements",
                Action = "Index",
                Area = "inventory",
                Role = Framework.Decisor.Domain.Interop.API.Common.Constants.Security.Authorization.UnitMeasurementViewerPermission
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
            //commercialSection.Add(new ManagementDashboardSectionViewModel
            //{
            //    Title = "Proveedores Jurídicos",
            //    Controller = "legalproviders",
            //    Action = "Index",
            //    Area = "commercial",
            //    Role = Framework.Decisor.Commercial.Interop.API.Common.Constants.Security.Authorization.LegalProviderViewerPermission
            //});
            //commercialSection.Add(new ManagementDashboardSectionViewModel
            //{
            //    Title = "Proveedores Naturales",
            //    Controller = "naturalproviders",
            //    Action = "Index",
            //    Area = "commercial",
            //    Role = Framework.Decisor.Commercial.Interop.API.Common.Constants.Security.Authorization.NaturalProviderViewerPermission
            //}); 
            commercialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Términos de Pago",
                Controller = "paymentterms",
                Action = "Index",
                Area = "commercial",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            #endregion

            #region Research

            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Propuestas",
                Controller = "propousals",
                Action = "Index",
                Area = "resarch",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Proyectos",
                Controller = "projects",
                Action = "Index",
                Area = "resarch",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Logros Científicos",
                Controller = "achivements",
                Action = "Index",
                Area = "resarch",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Resultados CTI",
                Controller = "ctihits",
                Action = "Index",
                Area = "resarch",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Introducción de Resultados",
                Controller = "ctihitintroductions",
                Action = "Index",
                Area = "resarch",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Publicaciones",
                Controller = "publishes",
                Action = "Index",
                Area = "resarch",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Programas",
                Controller = "programs",
                Action = "Index",
                Area = "resarch",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Investigadores",
                Controller = "researchers",
                Action = "Index",
                Area = "resarch",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Entidades Participantes",
                Controller = "researpartners",
                Action = "Index",
                Area = "resarch",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Financistas",
                Controller = "sponsors",
                Action = "Index",
                Area = "resarch",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Resultado CTI",
                Controller = "ctihitkinds",
                Action = "Index",
                Area = "resarch",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Programa",
                Controller = "programkinds",
                Action = "Index",
                Area = "IDi",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Categorías de Proyecto",
                Controller = "projectcategories",
                Action = "Index",
                Area = "IDi",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Categorías Científicas",
                Controller = "researchercategories",
                Action = "Index",
                Area = "IDi",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            researchSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Categorías Docentes",
                Controller = "teachingcategories",
                Action = "Index",
                Area = "IDi",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });

            #endregion

            #region Tech Services

            techServicingSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Capacitación",
                Controller = "trainingservices",
                Action = "Index",
                Area = "servicing",
                // TODO Set spected permission
                Role = Servicing.Interop.API.Common.Constants.Security.Authorization.TrainingServiceViewerPermission
            });
            techServicingSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Procesamiento de Muestras",
                Controller = "sampleanalysisservices",
                Action = "Index",
                Area = "servicing",
                // TODO Set spected permission
                Role = Servicing.Interop.API.Common.Constants.Security.Authorization.SampleAnalysisServiceViewerPermission
            });
            techServicingSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Estudios Int. de Suelo",
                Controller = "groundintegralstudyservices",
                Action = "Index",
                Area = "servicing",
                // TODO Set spected permission
                Role = Servicing.Interop.API.Common.Constants.Security.Authorization.GroundIntegralStudyServiceViewerPermission
            });
            techServicingSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Órdenes de Servicio",
                Controller = "naturalclienttrainingserviceorders",
                Action = "Index",
                Area = "servicing",
                // TODO Set spected permission
                Role = Servicing.Interop.API.Common.Constants.Security.Authorization.NaturalClientTrainingServiceOrderViewerPermission
            });

            #endregion

            #region Production

            productionSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Productos",
                Controller = "products",
                Action = "Index",
                Area = "production",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            productionSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Categorías",
                Controller = "categories",
                Action = "Index",
                Area = "production",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            productionSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Planes de Producción",
                Controller = "plans",
                Action = "Index",
                Area = "production",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            productionSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Elaboraciones",
                Controller = "elavorations",
                Action = "Index",
                Area = "production",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            productionSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Revisiones de Calidad",
                Controller = "qualitychecks",
                Action = "Index",
                Area = "production",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });

            #endregion

            #region Laboratory

            laboratorySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Recepciones de Muestra",
                Controller = "serviceordersamples",
                Action = "Index",
                Area = "lab",
                // TODO Set spected permission
                Role = Lab.Interop.API.Common.Constants.Security.Authorization.ServiceOrderSampleViewerPermission
            });
            laboratorySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Planes de Trabajo",
                Controller = "workplans",
                Action = "Index",
                Area = "lab",
                // TODO Set spected permission
                Role = Lab.Interop.API.Common.Constants.Security.Authorization.WorkPlanViewerPermission
            });
            laboratorySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Grupos de Trabajo",
                Controller = "workinggroups",
                Action = "Index",
                Area = "lab",
                // TODO Set spected permission
                Role = Lab.Interop.API.Common.Constants.Security.Authorization.WorkingGroupViewerPermission
            });
            laboratorySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Procesamientos de Muestra",
                Controller = "assessments",
                Action = "Index",
                Area = "lab",
                // TODO Set spected permission
                Role = Lab.Interop.API.Common.Constants.Security.Authorization.AssessmentViewerPermission
            });
            laboratorySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Técnicas de Laboratorio",
                Controller = "techniques",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission
                Role = Domain.Interop.API.Common.Constants.Security.Authorization.TechniqueViewerPermission
            });
            laboratorySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Muestra",
                Controller = "samplekinds",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission
                Role = Domain.Interop.API.Common.Constants.Security.Authorization.SampleKindViewerPermission
            });
            laboratorySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Revisiones de Calidad",
                Controller = "analysisqualitychecks",
                Action = "Index",
                Area = "lab",
                // TODO Set spected permission
                Role = Lab.Interop.API.Common.Constants.Security.Authorization.AnalysisQualityCheckViewerPermission
            });

            #endregion

            #region Recomendations

            recomendationSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Informes",
                Controller = "releases",
                Action = "Index",
                Area = "recomendation",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });

            #endregion

            #region Quality

            qualitySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Normas Cubanas",
                Controller = "cubanstandards",
                Action = "Index",
                Area = "quality",
                // TODO Set spected permission
                Role = Quality.Interop.API.Common.Constants.Security.Authorization.CubanStandardViewerPermission
            });
            qualitySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Normas ISO",
                Controller = "isostandards",
                Action = "Index",
                Area = "quality",
                // TODO Set spected permission
                Role = Quality.Interop.API.Common.Constants.Security.Authorization.IsoStandardViewerPermission
            });
            qualitySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Certificaciones",
                Controller = "certifications",
                Action = "Index",
                Area = "quality",
                // TODO Set spected permission
                Role = Quality.Interop.API.Common.Constants.Security.Authorization.CertificationViewerPermission
            });

            #endregion

            return new Dictionary<string, ICollection<ManagementDashboardSectionViewModel>>
            {
                { "Seguridad", securitySection },
                { "Locación", locationSection },
                { "Dominio", domainSection },
                { "Recursos Humanos", humanResourcesSection },
                { "Comercial", commercialSection },
                { "Investigación", researchSection },
                { "Servicios Técnicos", techServicingSection },
                { "Producción", productionSection },
                { "Laboratorio", laboratorySection },
                { "Recomendaciones", recomendationSection },
                { "Calidad", qualitySection }
            };
        }
    }
}
