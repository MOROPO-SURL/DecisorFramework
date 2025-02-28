using System.Linq;

namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display
{
    public class ClauseDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Clause, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public int Priority { get; set; }

        public string Content { get; set; }

        public TagDisplayModel[] Tags { get; set; }

        public void Import(Persistence.Entities.Clause entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Content = entity.Content;
            Priority = entity.Priority;
            Tags = entity.TagBridges.Select(bridge =>
            {
                var model = new TagDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
        }
    }
}
