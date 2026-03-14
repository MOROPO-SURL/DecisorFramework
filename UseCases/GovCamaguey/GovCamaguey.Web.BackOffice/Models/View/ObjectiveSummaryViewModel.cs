using MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Contract;
using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View;

public class ObjectiveSummaryViewModel : AbstractObjectiveViewModel
{
    public ObjectiveSummaryViewModel(Prototype.Persistence.Entities.Objective entity) : base(entity)
    {
        Description = entity.Description;
        Responsible = entity.Responsible;

        Proyections = entity.Proyections.OrderBy(entity => entity.Index).Select(_model => new ProyectionSummaryViewModel(_model, entity.Index)).ToArray();
    }

    public string Description { get; set; }

    public Prototype.Persistence.Entities.Person Responsible { get; set; }

    public ProyectionSummaryViewModel[] Proyections { get; set; }
}
