using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display.Contract;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class PersonContactDisplayModel : AbstractContactDisplayModel<PersonContact>
    {
        public Core.Interop.API.Common.Models.Display.PersonIdentityDisplayModel Identity { get; set; }

        public Core.Interop.API.Common.Models.Display.UserDisplayModel User { get; set; }

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

            if (entity.User != null)
            {
                User = new Core.Interop.API.Common.Models.Display.UserDisplayModel();

                User.Import(entity.User);
            }
        }

        public override string ToString()
        {
            return Identity?.ToString();
        }
    }
}
