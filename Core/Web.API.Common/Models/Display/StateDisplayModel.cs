namespace MOROPO.Framework.Decisor.Core.Web.API.Common.Models.Display
{
    public class StateDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Guama.Location.Persistence.Entities.State, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public void Import(Guama.Location.Persistence.Entities.State entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}
