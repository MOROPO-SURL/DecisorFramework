namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Contract;

public abstract class AbstractObjectiveViewModel
{
    protected AbstractObjectiveViewModel(Prototype.Persistence.Entities.Objective entity)
    {
        Id = entity.Id;
        Index = entity.Index;
        Name = entity.Name;
        Indicators = [.. entity.Indicators];
    }

    public System.Guid Id { get; set; }

    public int Index { get; set; }

    public string Name { get; set; }

    public Prototype.Persistence.Entities.ObjectiveIndicator[] Indicators { get; set; }
}
