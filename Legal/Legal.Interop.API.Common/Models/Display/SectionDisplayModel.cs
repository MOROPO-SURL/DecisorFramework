namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display
{
    public class SectionDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Section, int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public SectionDisplayModel Parent { get; set; }

        public void Import(Persistence.Entities.Section entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Title = entity.Title;
            Content = entity.Content;
            Priority = entity.Priority;
            Description = entity.Description;

            if (entity.Parent != null)
            {
                Parent = new SectionDisplayModel();

                Parent.Import(entity.Parent);
            }
        }
    }
}
