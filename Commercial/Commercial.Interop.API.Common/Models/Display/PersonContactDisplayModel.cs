namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display
{
    public class PersonContactDisplayModel : Contract.AbstractContactDisplayModel<Persistence.Entities.PersonContact>
    {
        public Core.Interop.API.Common.Models.Display.PersonIdentityDisplayModel Identity { get; set; }

        public NaturalBusinessKindDisplayModel BusinessKind { get; set; }

        public override void Import(Persistence.Entities.PersonContact entity)
        {
            base.Import(entity);

            if (entity.Identity != null)
            {
                Identity = new Core.Interop.API.Common.Models.Display.PersonIdentityDisplayModel();

                Identity.Import(entity.Identity);
            }

            if (entity.BusinessKind != null)
            {
                BusinessKind = new NaturalBusinessKindDisplayModel();

                BusinessKind.Import(entity.BusinessKind);
            }
        }

        public override string ToString()
        {
            return Identity?.ToString();
        }
    }
}
