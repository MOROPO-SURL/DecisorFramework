using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Frontend.Controllers.API
{
    [Route("api/servicing/[controller]")]
    [ApiController]
    public class LegalClientWidthContractingStatussesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultFilteredController<Framework.Decisor.Commercial.Persistence.Entities.LegalClient, System.Guid, Interop.API.Common.Models.Display.LegalClientWidthContractStatusDisplayModel, Framework.Decisor.Commercial.Interop.API.Common.Models.Filter.LegalClientFilterModel>
    {
        private readonly IEntityRepository<Persistence.Entities.LegalClientServicingContract, System.Guid> contractRepository;

        public LegalClientWidthContractingStatussesController(IEntityRepository<Persistence.Entities.LegalClientServicingContract, System.Guid> contractRepository, IEntityRepository<Framework.Decisor.Commercial.Persistence.Entities.LegalClient, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<LegalClientWidthContractingStatussesController> localizer, Microsoft.Extensions.Logging.ILogger<LegalClientWidthContractingStatussesController> logger) : base(repository, localizer, logger)
        {
            this.contractRepository = contractRepository;
        }

        protected override LegalClientWidthContractStatusDisplayModel EntityToDisplayModel(Framework.Decisor.Commercial.Persistence.Entities.LegalClient entity)
        {
            var model = base.EntityToDisplayModel(entity);

            if (entity.Contact.Identity.Image != null)
            {
                model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contact.Identity.Image.ContentType);
            }

            var contracts = contractRepository.FindBy(_entity => _entity.ServicingLegalClientId == entity.Id).ToArray();

            var now = System.DateTime.Now;

            foreach ( var contract in contracts ) 
            {
                if (contract.DurationUnitCount != null && contract.DurationUnitCount.Value > 0)
                {
                    var limitDateTime = contract.StarAt;

                    switch (contract.DurationUnitMeasureKind.Value)
                    {
                        case Framework.Decisor.Legal.Persistence.Enumerations.DurationUnitMeasureKind.Years:
                            limitDateTime = limitDateTime.AddYears(contract.DurationUnitCount.Value);

                            break;

                        case Framework.Decisor.Legal.Persistence.Enumerations.DurationUnitMeasureKind.Months:
                            limitDateTime = limitDateTime.AddMonths(contract.DurationUnitCount.Value);

                            break;

                        case Framework.Decisor.Legal.Persistence.Enumerations.DurationUnitMeasureKind.Days:
                            limitDateTime = limitDateTime.AddDays(contract.DurationUnitCount.Value);

                            break;

                        case Framework.Decisor.Legal.Persistence.Enumerations.DurationUnitMeasureKind.Hours:
                        default:
                            limitDateTime = limitDateTime.AddHours(contract.DurationUnitCount.Value);

                            break;
                    }

                    if (limitDateTime < now)
                    {
                        model.EndedContractCount++;
                    }
                    else
                    {
                        model.ActiveContractCount++;
                    }
                }
            }

            return model;
        }
    }
}
