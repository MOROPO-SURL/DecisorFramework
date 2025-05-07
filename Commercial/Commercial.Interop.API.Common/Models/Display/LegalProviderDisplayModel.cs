using System.Linq;

namespace MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display
{
    public class LegalProviderDisplayModel : Contract.AbstractLegalRelationshipDisplayModel<Persistence.Entities.LegalProvider>
    {
        public override void Import(Persistence.Entities.LegalProvider entity)
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
