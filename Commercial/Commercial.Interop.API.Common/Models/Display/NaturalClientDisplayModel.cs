using System.Linq;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display
{
    public class NaturalClientDisplayModel : Contract.AbstractNaturalRelationshipDisplayModel<Persistence.Entities.NaturalClient>
    {
        public override void Import(Persistence.Entities.NaturalClient entity)
        {
            base.Import(entity);

            BankAccounts = entity.BankAccountBridges.Select(bridge =>
            {
                var model = new Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
        }
    }
}

