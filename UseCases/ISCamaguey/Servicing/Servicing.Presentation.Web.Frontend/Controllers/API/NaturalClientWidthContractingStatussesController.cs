using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Web.Frontend.Controllers.API;

[Route("api/servicing/[controller]")]
[ApiController]
public class NaturalClientWidthContractingStatussesController : Framework.Guama.Core.Presentation.Web.API.Controllers.Contract.AbstractEntityAPIConsultFilteredController<Framework.Decisor.Commercial.Persistence.Entities.NaturalClient, System.Guid, Interop.API.Common.Models.Display.NaturalClientWidthContractStatusDisplayModel, Framework.Decisor.Commercial.Interop.API.Common.Models.Filter.NaturalClientFilterModel>
{
    private readonly IEntityRepository<Persistence.Entities.NaturalClientServicingContract, System.Guid> contractRepository;

    public NaturalClientWidthContractingStatussesController(IEntityRepository<Persistence.Entities.NaturalClientServicingContract, System.Guid> contractRepository, IEntityRepository<Framework.Decisor.Commercial.Persistence.Entities.NaturalClient, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<NaturalClientWidthContractingStatussesController> localizer, Microsoft.Extensions.Logging.ILogger<NaturalClientWidthContractingStatussesController> logger) : base(repository, localizer, logger)
    {
        this.contractRepository = contractRepository;
    }

    protected override NaturalClientWidthContractStatusDisplayModel EntityToDisplayModel(Framework.Decisor.Commercial.Persistence.Entities.NaturalClient entity)
    {
        var model = base.EntityToDisplayModel(entity);

        if (entity.Contact.Identity.Image != null)
        {
            model.Contact.Identity.Image.Extension = MimeTypes.MimeTypeMap.GetExtension(entity.Contact.Identity.Image.ContentType);
        }

        var contracts = contractRepository.FindBy(_entity => _entity.ServicingNaturalClientId == entity.Id).ToArray();

        var now = System.DateTime.Now;

        foreach (var contract in contracts)
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
