using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Input
{
    public class NaturalClientPropertyLeasingInputModel : Contract.AbstractLeasingInputModel<Persistence.Entities.NaturalClientPropertyLeasing>
    {
        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel[] Contacts { get; set; }

        public override Persistence.Entities.NaturalClientPropertyLeasing Export()
        {
            var entity = new Persistence.Entities.NaturalClientPropertyLeasing { Id = Id };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.NaturalClientPropertyLeasing entity)
        {
            base.Mergue(entity);

            entity.ContactBridges.Clear();

            entity.ContactBridges = Contacts.Select(model => new Persistence.Entities.NaturalClientPropertyLeasingPersonContactBridge
            {
                ProwId = entity.Id,
                SternId = model.Id
            }).ToList();
        }
    }
}
