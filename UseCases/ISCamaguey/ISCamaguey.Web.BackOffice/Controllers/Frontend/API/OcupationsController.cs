using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Governance.Persistence.Entities;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Interop.API.Common.Models.Input;

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Controllers.Frontend.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class OcupationsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIManagementFilteredController<Ocupation, System.Guid, OcupationInputModel, OcupationDisplayModel, OcupationFilterModel>
    {
        private readonly IEntityRepository<DesignationResolution, System.Guid> designationResolutionRepository;
        private readonly IEntityRepository<Employee, System.Guid> employeeRepository;
        private readonly IEntityRepository<DecisionMakingGroup, System.Guid> decisionMakingGroupRepository;
        private readonly IEntityRepository<Meeting, System.Guid> meetingRepository;
        private readonly IEntityRepository<Agreement, System.Guid> agreementRepository;
        private readonly IEntityRepository<Staff, System.Guid> staffRepository;

        public OcupationsController(IEntityRepository<Staff, System.Guid> staffRepository, IEntityRepository<Agreement, System.Guid> agreementRepository, IEntityRepository<Meeting, System.Guid> meetingRepository, IEntityRepository<DecisionMakingGroup, System.Guid> decisionMakingGroupRepository, IEntityRepository<Employee, System.Guid> employeeRepository, IEntityRepository<DesignationResolution, System.Guid> designationResolutionRepository, IEntityRepository<Ocupation, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<OcupationsController> localizer, Microsoft.Extensions.Logging.ILogger<OcupationsController> logger) : base(repository, localizer, logger)
        {
            this.designationResolutionRepository = designationResolutionRepository;
            this.employeeRepository = employeeRepository;
            this.decisionMakingGroupRepository = decisionMakingGroupRepository;
            this.meetingRepository = meetingRepository;
            this.agreementRepository = agreementRepository;
            this.staffRepository = staffRepository;
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

            var now = System.DateTime.Now;

            Agreement agreement = null;

            try
            {
                agreement = agreementRepository.Get(System.Guid.Empty);
            }
            catch
            {
                Meeting meeting = null;

                try
                {
                    meeting = meetingRepository.Get(System.Guid.Empty);
                }
                catch
                {
                    DecisionMakingGroup decisionMakingGroup = null;

                    try
                    {
                        decisionMakingGroup = decisionMakingGroupRepository.Get(System.Guid.Empty);
                    }
                    catch
                    {
                        var staff = staffRepository.Get(model.StaffId);

                        decisionMakingGroup = decisionMakingGroupRepository.Add(new DecisionMakingGroup
                        {
                            Id = System.Guid.Empty,
                            Enabled = false,
                            Archived = true,
                            Name = "Comité Automático de Ocupación Simplificada de Plazas",
                            Priority = 100,
                            AdministrativeEntityId = staff.AdministrativeEntityId,
                            LeaderId = model.ContactId                            
                        }, User.Identity.Name, false);
                    }

                    meeting = meetingRepository.Add(new Meeting
                    {
                        Id = System.Guid.Empty,
                        Index = 1,
                        Archived = true,
                        At = now,
                        DecisionMakingGroupId = decisionMakingGroup.Id,
                        AuthorId = model.ContactId,
                    }, User.Identity.Name, false);
                }

                agreement = agreementRepository.Add(new Agreement
                {
                    Id = System.Guid.Empty,
                    Index = 1,
                    Title = "Acuerdo automático para la ocupación simplificada de plazas",
                    MeetingId = meeting.Id,
                    
                }, User.Identity.Name, false);
            }

            var resolutionIndex = designationResolutionRepository.Count() + 1;

            var resolution = designationResolutionRepository.Add(new DesignationResolution
            {
                Id = System.Guid.NewGuid(),
                AgreementId = agreement.Id,
                ContactId = model.ContactId,
                Index = resolutionIndex,
                At = now,
                Year = now.Year,
                ConcretedAt = now,
                StaffId = model.StaffId,
                VacantId = model.VacantId,
                Summary = "Resolución de designación para la ocupación simplificada de plaza"
            }, User.Identity.Name, false);

            var employee = employeeRepository.FindOneBy(_entity => _entity.ContactId == resolution.ContactId);

            entity.StaffId = model.StaffId;
            entity.Contract = new DesignationEmploymentContract
            {
                Index = resolutionIndex,
                Year = now.Year,
                StarAt = now,
                Objective = $"Contratación generada a partir de la resolución de nombramiento \"{resolution.Id}/{resolution.Year}\"",
                StaffId = model.StaffId,
                VacantId = model.VacantId,
                DesignationResolutionId = resolution.Id
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
                    Priority = 1,
                    ContactId = model.ContactId
                };
            }
        }
    }
}
