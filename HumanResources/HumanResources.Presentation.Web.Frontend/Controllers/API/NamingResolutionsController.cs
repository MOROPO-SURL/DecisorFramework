using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Filter;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.HumanResources.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/fwrk/hhrr/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class NamingResolutionsController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementFilteredController<NamingResolution, System.Guid, NamingResolutionInputModel, NamingResolutionDisplayModel, NamingResolutionFilterModel>
    {
        private readonly IEntityRepository<OcupationCandidate, System.Guid> ocupationCandidateRepository;

        public NamingResolutionsController(IEntityRepository<OcupationCandidate, System.Guid> ocupationCandidateRepository, IEntityRepository<NamingResolution, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NamingResolutionsController> localizer, Microsoft.Extensions.Logging.ILogger<NamingResolutionsController> logger) : base(repository, localizer, logger)
        {
            this.ocupationCandidateRepository = ocupationCandidateRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<NamingResolution, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<NamingResolution, object> GetOrderSelector()
        {
            return entity => 1000 * entity.Index + entity.Year;
        }

        protected override bool IsOrderDescending()
        {
            return true;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override NamingResolutionDisplayModel EntityToDisplayModel(NamingResolution entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (model.Contact != null && model.Contact.Identity.Image != null)
            {
                model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contact.Identity.Image.ContentType);
            }

            if (model.Candidate != null && model.Candidate.Postulation.Contact.Identity.Image != null)
            {
                model.Candidate.Postulation.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Candidate.Postulation.Contact.Identity.Image.ContentType);
            }

            return model;
        }

        protected override void PreCreate(NamingResolution entity, NamingResolutionInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.CandidateId == null) return;

            var candidate = ocupationCandidateRepository.Get(model.CandidateId.Value);

            candidate.Archived = true;

            ocupationCandidateRepository.Update(candidate, User.Identity.Name, false);
        }

        protected override void PreEdit(NamingResolution entity, NamingResolutionInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.CandidateId == null) return;

            if (entity.CandidateId != model.CandidateId)
            {
                var oldCandidate = ocupationCandidateRepository.Get(model.CandidateId.Value);

                oldCandidate.Archived = false;

                ocupationCandidateRepository.Update(oldCandidate, User.Identity.Name, false);

                entity.Candidate = null;
                entity.CandidateId = model.CandidateId;

                var newCandidate = ocupationCandidateRepository.Get(model.CandidateId.Value);

                newCandidate.Archived = true;

                ocupationCandidateRepository.Update(newCandidate, User.Identity.Name, false);
            }
        }
    }
}
