using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Filter;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Input;
using MOROPO.ISCamaguey.Decisor.IDi.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/idi/[controller]")]
    [ApiController]
    public class ParticipatingOrganizationsController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEnableableEntityAPIManagementFilteredController<ParticipatingOrganization, System.Guid, ParticipatingOrganizationInputModel, ParticipatingOrganizationDisplayModel, ParticipatingOrganizationFilterModel>
    {
        private readonly IEntityRepository<Municipality, System.Guid> municipalityRepository;

        public ParticipatingOrganizationsController(IEntityRepository<Municipality, System.Guid> municipalityRepository, IEntityRepository<ParticipatingOrganization, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<ParticipatingOrganizationsController> localizer, Microsoft.Extensions.Logging.ILogger<ParticipatingOrganizationsController> logger) : base(repository, localizer, logger)
        {
            this.municipalityRepository = municipalityRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<ParticipatingOrganization, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived;
        }

        protected override System.Func<ParticipatingOrganization, object> GetOrderSelector()
        {
            return entity => entity.Priority ;
        }

        protected override ParticipatingOrganizationDisplayModel EntityToDisplayModel(ParticipatingOrganization entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Contact.Identity.Image != null)
            {
                model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contact.Identity.Image.ContentType);
            }

            if (entity.Contact.Representative.Identity.Image != null)
            {
                model.Contact.Representative.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contact.Representative.Identity.Image.ContentType);
            }

            foreach (var _model in model.Contact.Identity.PostalContacts)
            {
                var municipality = municipalityRepository.Get(_model.Municipality.Id);

                _model.Municipality = new Framework.Decisor.Core.Interop.API.Common.Models.Display.MunicipalityDisplayModel();

                _model.Municipality.Import(municipality);
            }

            return model;
        }
    }
}
