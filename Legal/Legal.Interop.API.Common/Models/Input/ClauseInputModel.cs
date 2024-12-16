using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Input
{
    public class ClauseInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Clause, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Body { get; set; }

        public System.Collections.Generic.List<TagDisplayModel> Tags { get; set; } = new System.Collections.Generic.List<TagDisplayModel>();

        public Persistence.Entities.Clause Export()
        {
            var entity = new Persistence.Entities.Clause { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Clause entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Clause entity)
        {
            entity.Name = Name;
            entity.Priority = Priority;
            entity.Body = Body;

            entity.TagBridges.Clear();

            entity.TagBridges.AddRange(Tags.Select(model => new Persistence.Entities.ClauseTagBridge { ProwId = entity.Id, SternId = model.Id }));
        }
    }
}
