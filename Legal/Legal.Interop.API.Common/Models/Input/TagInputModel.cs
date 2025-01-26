namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Input
{
    public class TagInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Tag, string>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Id { get; set; }

        public Persistence.Entities.Tag Export()
        {
            var entity = new Persistence.Entities.Tag { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Tag entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Tag entity)
        {
        }
    }
}
