using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input;
using MOROPO.Framework.Decisor.Financial.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Web.Frontend.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/financial/[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    public class BankBranchesController : Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractArchivableEntityAPIManagementController<BankBranch, System.Guid, BankBranchInputModel, BankBranchDisplayModel>
    {
        private readonly IEntityRepository<MunicipalityLocation, System.Guid> municipalityLocationRepository;
        private readonly IEntityRepository<PostalContactItem, System.Guid> postalContactRepository;

        public BankBranchesController(IEntityRepository<PostalContactItem, System.Guid> postalContactRepository, IEntityRepository<MunicipalityLocation, System.Guid> municipalityLocationRepository, IEntityRepository<BankBranch, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<BankBranchesController> localizer, Microsoft.Extensions.Logging.ILogger<BankBranchesController> logger) : base(repository, localizer, logger)
        {
            this.municipalityLocationRepository = municipalityLocationRepository;
            this.postalContactRepository = postalContactRepository;
        }

        protected override System.Linq.Expressions.Expression<System.Func<BankBranch, bool>> GetGlobalSelector()
        {
            return entity => !entity.Archived && entity.Enabled;
        }

        public override Microsoft.AspNetCore.Mvc.ActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        protected override void PreCreate(BankBranch entity, BankBranchInputModel model)
        {
            base.PreCreate(entity, model);

            if (model.LocationMunicipalityId != null && !string.IsNullOrEmpty(model.LocationAddress))
            {
                var municipalityLocation = municipalityLocationRepository.FindOneBy(__entity => __entity.MunicipalityId == model.LocationMunicipalityId);

                if (municipalityLocation == null)
                {
                    municipalityLocation = municipalityLocationRepository.Add(new MunicipalityLocation
                    {
                        MunicipalityId = model.LocationMunicipalityId
                    }, User.Identity.Name, false);
                }

                entity.PostalContact = postalContactRepository.Add(new PostalContactItem
                {
                    Address = model.LocationAddress,
                    ZipCode = model.LocationZipCode ?? 0,
                    Latitude = model.LocationLatitude ?? 0,
                    Longitude = model.LocationLongitude ?? 0,
                    LocationId = municipalityLocation.Id
                }, User.Identity.Name, false);
            }
        }

        protected override void PreEdit(BankBranch entity, BankBranchInputModel model)
        {
            base.PreEdit(entity, model);

            if (model.LocationMunicipalityId != null && !string.IsNullOrEmpty(model.LocationAddress))
            {
                var municipalityLocation = municipalityLocationRepository.FindOneBy(__entity => __entity.MunicipalityId == model.LocationMunicipalityId);

                if (municipalityLocation == null)
                {
                    municipalityLocation = municipalityLocationRepository.Add(new MunicipalityLocation
                    {
                        MunicipalityId = model.LocationMunicipalityId
                    }, User.Identity.Name, false);
                }

                if (entity.PostalContact != null)
                {
                    entity.PostalContact.Address = model.LocationAddress;
                    entity.PostalContact.ZipCode = model.LocationZipCode ?? 0;
                    entity.PostalContact.Latitude = model.LocationLatitude ?? 0;
                    entity.PostalContact.Longitude = model.LocationLongitude ?? 0;

                    if (entity.PostalContact.LocationId != municipalityLocation.Id)
                    {
                        entity.PostalContact.Location = null;
                        entity.PostalContact.LocationId = municipalityLocation.Id;
                    }
                }
                else
                {
                    entity.PostalContact = postalContactRepository.Add(new PostalContactItem
                    {
                        Address = model.LocationAddress,
                        ZipCode = model.LocationZipCode ?? 0,
                        Latitude = model.LocationLatitude ?? 0,
                        Longitude = model.LocationLongitude ?? 0,
                        LocationId = municipalityLocation.Id
                    }, User.Identity.Name, false);
                }
            }
            else
            {
                postalContactRepository.Delete(entity.PostalContact, User.Identity.Name, false);

                entity.PostalContact = null;
                entity.PostalContactId = null;
            }
        }
    }
}
