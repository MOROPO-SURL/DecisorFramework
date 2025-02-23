using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractNaturalRelationshipDisplayModel<TEntity> : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TEntity, System.Guid>
        where TEntity : Persistence.Entities.Contract.AbstractNaturalRelationship
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public PersonContactDisplayModel Contact { get; set; }

        public NaturalBusinessKindDisplayModel BusinessKind { get; set; }

        public virtual void Import(TEntity entity)
        {
            Id = entity.Id;
            Priority = entity.Contact.Priority;
            At = entity.Contact.At;

            if (entity.Contact != null)
            {
                Contact = new PersonContactDisplayModel();

                Contact.Import(entity.Contact);
            }

            if (entity.BusinessKind != null)
            {
                BusinessKind = new NaturalBusinessKindDisplayModel();

                BusinessKind.Import(entity.BusinessKind);
            }
        }

        public override string ToString()
        {
            return Contact?.ToString();
        }
    }
}

