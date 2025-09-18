namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class LegalClientPropertyLeasingDisplayModel : Contract.AbstractLeasingDisplayModel<Persistence.Entities.LegalClientPropertyLeasing>
    {
        public LegalClientPropertyLeaseContractDisplayModel Contract { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel[] Workers { get; set; }

        public override void Import(Persistence.Entities.LegalClientPropertyLeasing entity)
        {
            base.Import(entity);
        }
    }
}
