using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display.Contract;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class PersonContactDisplayModel : AbstractContactDisplayModel<PersonContact>
    {
        public Core.Interop.API.Common.Models.Display.PersonIdentityDisplayModel Identity { get; set; }

        public NaturalBusinessKindDisplayModel BusinessKind { get; set; }

        public string PersonalIdentificationNumber { get; set; }

        public override void Import(PersonContact entity)
        {
            base.Import(entity);

            PersonalIdentificationNumber = entity.PersonalIdentificationNumber;

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
