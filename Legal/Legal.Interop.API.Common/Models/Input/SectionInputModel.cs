namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Input
{
    public class SectionInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Section, int>
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public Persistence.Entities.Section Export()
        {
            var entity = new Persistence.Entities.Section();

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Section entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Section entity)
        {
            entity.Name = Name;
            entity.Title = Title;
            entity.Content = Content;
            entity.Priority = Priority;
            entity.Description = Description;

            if (entity.ParentId != ParentId)
            {
                entity.Parent = null;
                entity.ParentId = ParentId;
            }
        }
    }
}
