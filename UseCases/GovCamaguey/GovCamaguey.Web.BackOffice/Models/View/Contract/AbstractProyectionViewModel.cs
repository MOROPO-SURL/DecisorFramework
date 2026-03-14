namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Models.View.Contract;

public abstract class AbstractProyectionViewModel
{
    public AbstractProyectionViewModel(Prototype.Persistence.Entities.Proyection model, int objectiveIndex)
    {
        Id = model.Id;
        Enabled = model.Enabled;
        Index = model.Index;
        Name = model.Name;
        Description = model.Description;
        Indicators = [.. model.Indicators];

        ObjectiveIndex = objectiveIndex;
    }

    public System.Guid Id { get; set; }

    public bool Enabled { get; set; }

    public int Index { get; set; }

    public int ObjectiveIndex { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Prototype.Persistence.Entities.ProyectionIndicator[] Indicators { get; set; }
}