using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class OcupationsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementFilteredController<Ocupation, System.Guid, OcupationInputModel, OcupationDisplayModel, OcupationFilterModel>
    {
        private readonly IEntityRepository<NamingResolution, System.Guid> namingResolutionRepository;
        private readonly IEntityRepository<AdmitionPropousal, System.Guid> admisionPropousalRepository;
        private readonly IEntityRepository<Employee, System.Guid> employeeRepository;
        private readonly IEntityRepository<OcupationCandidate, System.Guid> ocupationCandidateRepository;

        public OcupationsController(IEntityRepository<OcupationCandidate, System.Guid> ocupationCandidateRepository, IEntityRepository<Employee, System.Guid> employeeRepository, IEntityRepository<AdmitionPropousal, System.Guid> admisionPropousalRepository, IEntityRepository<NamingResolution, System.Guid> namingResolutionRepository, IEntityRepository<Ocupation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<OcupationsController> localizer, Microsoft.Extensions.Logging.ILogger<OcupationsController> logger) : base(repository, localizer, logger)
        {
            this.namingResolutionRepository = namingResolutionRepository;
            this.admisionPropousalRepository = admisionPropousalRepository;
            this.employeeRepository = employeeRepository;
            this.ocupationCandidateRepository = ocupationCandidateRepository;
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

            if (model.NamingResolutionId != null)
            {
                var namingResolution = namingResolutionRepository.Get(model.NamingResolutionId.Value);

                var candidate = namingResolution.CandidateId == null ? null : ocupationCandidateRepository.Get(namingResolution.CandidateId.Value);

                var employee = candidate == null ? employeeRepository.FindOneBy(_entity => _entity.ContactId == namingResolution.ContactId.Value) : employeeRepository.FindOneBy(_entity => _entity.ContactId == candidate.Postulation.ContactId);

                entity.StaffId = namingResolution.StaffId ?? candidate.Postulation.StaffId;
                entity.VacantId = namingResolution.VacantId ?? candidate.Postulation.VacantId;
                entity.Contract = new NamingEmploymentContract
                {
                    Year = model.StarAt.Year,
                    StarAt = model.StarAt,
                    Objective = $"Contratación generada a partir de la resolución de nombramiento \"{namingResolution.Id}/{namingResolution.At.Year}\"",
                    DurationUnitCount = model.DurationUnitCount,
                    DurationUnitMeasureKind = model.DurationUnitMeasureKind,
                    Priority = namingResolution.Contact?.Priority ?? candidate.Postulation.Contact.Priority,
                    StaffId = namingResolution.StaffId ?? candidate.Postulation.StaffId,
                    VacantId = namingResolution.VacantId ?? candidate.Postulation.VacantId,
                    ResolutionId = namingResolution.Id
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
                        Priority = namingResolution.Contact?.Priority ?? candidate.Postulation.Contact.Priority,
                        ContactId = namingResolution.ContactId ?? namingResolution.Candidate.Postulation.ContactId
                    };
                }

                namingResolution.ConcretedAt = System.DateTime.Now;

                namingResolutionRepository.Update(namingResolution, User.Identity.Name, false);

                return;
            }
            else if (model.AdmisionPropousalId != null)
            {
                var admisionPropousal = admisionPropousalRepository.Get(model.AdmisionPropousalId.Value);

                var employee = employeeRepository.FindOneBy(_entity => _entity.ContactId == admisionPropousal.OcupationCandidate.Postulation.ContactId);

                entity.StaffId = admisionPropousal.OcupationCandidate.Postulation.StaffId;
                entity.VacantId = admisionPropousal.OcupationCandidate.Postulation.VacantId;
                entity.Contract = new AdmitionEmploymentContract
                {
                    Year = model.StarAt.Year,
                    StarAt = model.StarAt,
                    Objective = $"Contratación generada a partir de la propuesta de admisión tomada en la reunión No.{admisionPropousal.Agreement.Meeting.Index} con fecha {admisionPropousal.Agreement.Meeting.At:D}",
                    DurationUnitCount = model.DurationUnitCount,
                    DurationUnitMeasureKind = model.DurationUnitMeasureKind,
                    Priority = admisionPropousal.OcupationCandidate.Postulation.Contact.Priority,
                    StaffId = admisionPropousal.OcupationCandidate.Postulation.StaffId,
                    VacantId = admisionPropousal.OcupationCandidate.Postulation.VacantId,
                    AdmitionPropousalId = admisionPropousal.Id
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
                        Priority = admisionPropousal.OcupationCandidate.Postulation.Contact.Priority,
                        ContactId = admisionPropousal.OcupationCandidate.Postulation.ContactId
                    };
                }

                admisionPropousal.Archived = true;

                admisionPropousalRepository.Update(admisionPropousal, User.Identity.Name, false);

                return;
            }

            throw new System.InvalidOperationException();
        }
    }
}
