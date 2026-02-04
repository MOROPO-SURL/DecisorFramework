using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class LegalClientPropertyLeasingInputModel : Contract.AbstractLeasingInputModel<Persistence.Entities.LegalClientPropertyLeasing>
    {
        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel[] Contacts { get; set; }

        public override Persistence.Entities.LegalClientPropertyLeasing Export()
        {
            var entity = new Persistence.Entities.LegalClientPropertyLeasing { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.LegalClientPropertyLeasing entity)
        {
            base.Mergue(entity);

            entity.ContactBridges.Clear();

            entity.ContactBridges = Contacts.Select(model => new Persistence.Entities.LegalClientPropertyLeasingPersonContactBridge
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();
        }
    }
}
