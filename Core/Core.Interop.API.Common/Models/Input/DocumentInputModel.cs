namespace MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input
{
    public class DocumentInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public System.Guid Id { get; set; }

        public byte[] ContentData { get; set; }

        public string ContentType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guama.Media.Persistence.Entities.Document Export()
        {
            throw new System.NotImplementedException();
        }

        public void Import(Guama.Media.Persistence.Entities.Document entity)
        {
            Name = entity.Name;
            Description = entity.Description;
        }

        public void Mergue(Guama.Media.Persistence.Entities.Document entity)
        {
            entity.Name = Name;
            entity.Description = Description;
        }
    }
}
