namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display
{
    public class TagDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Tag, string>
    {
        public string Id { get; set; }

        public void Import(Persistence.Entities.Tag entity)
        {
            Id = entity.Id;
        }
    }
}
