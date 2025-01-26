using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class LegalBusinessKindDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<LegalBusinessKind, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public System.DateTime At { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public virtual void Import(LegalBusinessKind entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Priority = entity.Priority;
            At = entity.At;
            Description = entity.Description;
        }
    }
}
