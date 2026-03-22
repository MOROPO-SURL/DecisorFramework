namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Input;

public class ProjectCategoryInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.ProjectCategory, System.Guid>
{
    public System.Guid Id { get; set; } = System.Guid.NewGuid();

    public int Priority { get; set; }

    public bool Enabled { get; set; }

    [System.ComponentModel.DataAnnotations.Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public Persistence.Entities.ProjectCategory Export()
    {
        var entity = new Persistence.Entities.ProjectCategory();

        Mergue(entity);

        return entity;
    }

    public void Import(Persistence.Entities.ProjectCategory entity)
    {
        Id = entity.Id;
        Enabled = entity.Enabled;
        Priority = entity.Priority;
        Name = entity.Name;
        Description = entity.Description;
    }

    public void Mergue(Persistence.Entities.ProjectCategory entity)
    {
        entity.Name = Name;
        entity.Enabled = Enabled;
        entity.Description = Description;
        entity.Priority = Priority;
    }
}
