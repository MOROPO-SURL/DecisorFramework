using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class OcupationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementFilteredController<Ocupation, System.Guid, OcupationInputModel, OcupationDisplayModel, OcupationFilterModel>
    {
        private readonly IEntityRepository<NamingResolution, System.Guid> namingResolutionRepository;
        private readonly IEntityRepository<DesignationResolution, System.Guid> designationResolutionRepository;
        private readonly IEntityRepository<AdmitionPropousal, System.Guid> admisionPropousalRepository;
        private readonly IEntityRepository<Employee, System.Guid> employeeRepository;
        private readonly IEntityRepository<OcupationCandidate, System.Guid> ocupationCandidateRepository;
        private readonly IEntityRepository<Persistence.Entities.Contract.AbstractEmploymentContract, System.Guid> employmentContractRepository;

        public OcupationsController(IEntityRepository<Persistence.Entities.Contract.AbstractEmploymentContract, System.Guid> employmentContractRepository, IEntityRepository<OcupationCandidate, System.Guid> ocupationCandidateRepository, IEntityRepository<Employee, System.Guid> employeeRepository, IEntityRepository<AdmitionPropousal, System.Guid> admisionPropousalRepository, IEntityRepository<DesignationResolution, System.Guid> designationResolutionRepository, IEntityRepository<NamingResolution, System.Guid> namingResolutionRepository, IEntityRepository<Ocupation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<OcupationsController> localizer, Microsoft.Extensions.Logging.ILogger<OcupationsController> logger) : base(repository, localizer, logger)
        {
            this.namingResolutionRepository = namingResolutionRepository;
            this.designationResolutionRepository = designationResolutionRepository;
            this.admisionPropousalRepository = admisionPropousalRepository;
            this.employeeRepository = employeeRepository;
            this.ocupationCandidateRepository = ocupationCandidateRepository;
            this.employmentContractRepository = employmentContractRepository;
        }

        protected override OcupationDisplayModel EntityToDisplayModel(Ocupation entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Employee.Contact.Identity.Image != null)
            {
                model.Employee.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contract.Employee.Contact.Identity.Image.ContentType);
            }

            return model;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Edit([Microsoft.AspNetCore.Mvc.FromBody] OcupationInputModel model)
        {
            return NotFound();
        }

        protected override void PreCreate(Ocupation entity, OcupationInputModel model)
        {
            base.PreCreate(entity, model);

            var nextIndex = employmentContractRepository.Count() + 1;

            switch (entity.Vacant.OcupationMode)
            {                
                case Persistence.Enumerations.VacantOcupationMode.Designation:
                    var designationResolution = designationResolutionRepository.Get(model.ResolutionId.Value);

                    var employee = employeeRepository.FindOneBy(_entity => _entity.ContactId == designationResolution.ContactId);

                    entity.StaffId = designationResolution.StaffId;
                    entity.VacantId = designationResolution.VacantId;
                    entity.Contract = new NamingEmploymentContract
                    {
                        Index = nextIndex,
                        Year = model.StarAt.Year,
                        StarAt = model.StarAt,
                        Objective = $"Contratación generada a partir de la resolución de designación \"{designationResolution.Index}/{designationResolution.Year}\"",
                        DurationUnitCount = model.DurationUnitCount,
                        DurationUnitMeasureKind = model.DurationUnitMeasureKind,
                        StaffId = entity.StaffId,
                        VacantId = entity.VacantId,
                        ResolutionId = designationResolution.Id
                    };

                    if (employee != null)
                    {
                        if (employee.Archived)
                        {
                            employee.Archived = false;

                            employeeRepository.Update(employee, User.Identity.Name, false);
                        }

                        entity.Contract.EmployeeId = employee.Id;
                    }
                    else
                    {
                        entity.Contract.Employee = new Employee
                        {
                            Enabled = true,
                            Priority = designationResolution.Contact.Priority,
                            ContactId = designationResolution.ContactId
                        };
                    }

                    designationResolution.ConcretedAt = System.DateTime.Now;

                    designationResolutionRepository.Update(designationResolution, User.Identity.Name, false);

                    break;

                case Persistence.Enumerations.VacantOcupationMode.Naming:
                    var namingResolution = namingResolutionRepository.Get(model.ResolutionId.Value);

                    var candidate = ocupationCandidateRepository.Get(namingResolution.CandidateId);

                    var _employee = employeeRepository.FindOneBy(_entity => _entity.ContactId == candidate.Postulation.ContactId);

                    entity.StaffId =  candidate.Postulation.StaffId;
                    entity.VacantId = candidate.Postulation.VacantId;
                    entity.Contract = new NamingEmploymentContract
                    {
                        Index = nextIndex,
                        Year = model.StarAt.Year,
                        StarAt = model.StarAt,
                        Objective = $"Contratación generada a partir de la resolución de nombramiento \"{namingResolution.Index}/{namingResolution.Year}\"",
                        DurationUnitCount = model.DurationUnitCount,
                        DurationUnitMeasureKind = model.DurationUnitMeasureKind,
                        StaffId = entity.StaffId,
                        VacantId = entity.VacantId,
                        ResolutionId = namingResolution.Id
                    };

                    if (_employee != null)
                    {
                        if (_employee.Archived)
                        {
                            _employee.Archived = false;

                            employeeRepository.Update(_employee, User.Identity.Name, false);
                        }

                        entity.Contract.EmployeeId = _employee.Id;
                    }
                    else
                    {
                        entity.Contract.Employee = new Employee
                        {
                            Enabled = true,
                            Priority = candidate.Postulation.Contact.Priority,
                            ContactId = namingResolution.Candidate.Postulation.ContactId
                        };
                    }

                    namingResolution.ConcretedAt = System.DateTime.Now;

                    namingResolutionRepository.Update(namingResolution, User.Identity.Name, false);

                    break;

                case Persistence.Enumerations.VacantOcupationMode.Admision:
                default:
                    var admisionPropousal = admisionPropousalRepository.Get(model.AdmisionPropousalId.Value);

                    var __employee = employeeRepository.FindOneBy(_entity => _entity.ContactId == admisionPropousal.OcupationCandidate.Postulation.ContactId);

                    entity.StaffId = admisionPropousal.OcupationCandidate.Postulation.StaffId;
                    entity.VacantId = admisionPropousal.OcupationCandidate.Postulation.VacantId;
                    entity.Contract = new AdmitionEmploymentContract
                    {
                        Index = nextIndex,
                        Year = model.StarAt.Year,
                        StarAt = model.StarAt,
                        Objective = $"Contratación generada a partir de la propuesta de admisión tomada en la reunión No.{admisionPropousal.Agreement.Meeting.Index} con fecha {admisionPropousal.Agreement.Meeting.At:D}",
                        DurationUnitCount = model.DurationUnitCount,
                        DurationUnitMeasureKind = model.DurationUnitMeasureKind,
                        StaffId = admisionPropousal.OcupationCandidate.Postulation.StaffId,
                        VacantId = admisionPropousal.OcupationCandidate.Postulation.VacantId,
                        AdmitionPropousalId = admisionPropousal.Id
                    };

                    if (__employee != null)
                    {
                        if (__employee.Archived)
                        {
                            __employee.Archived = false;

                            employeeRepository.Update(__employee, User.Identity.Name, false);
                        }

                        entity.Contract.EmployeeId = __employee.Id;
                    }
                    else
                    {
                        entity.Contract.Employee = new Employee
                        {
                            Enabled = true,
                            Priority = admisionPropousal.OcupationCandidate.Postulation.Contact.Priority,
                            ContactId = admisionPropousal.OcupationCandidate.Postulation.ContactId
                        };
                    }

                    admisionPropousal.Archived = true;

                    admisionPropousalRepository.Update(admisionPropousal, User.Identity.Name, false);

                    break;
            }

            throw new System.InvalidOperationException();
        }
    }
}
