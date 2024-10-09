namespace MOROPO.Framework.Decisor.Core.Web.API.Common.Models.Input
{
    public class ImageInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Guama.Media.Persistence.Entities.Image, System.Guid>
    {
        public System.Guid Id { get; set; }

        public byte[] ContentData { get; set; }

        public string ContentType { get; set; }

        public string About { get; set; }

        public Guama.Media.Persistence.Entities.Image Export()
        {
            throw new System.NotImplementedException();
        }

        public void Import(Guama.Media.Persistence.Entities.Image entity)
        {
            About = entity.About;
        }

        public void Mergue(Guama.Media.Persistence.Entities.Image entity)
        {
            entity.About = About;
        }
    }
}
