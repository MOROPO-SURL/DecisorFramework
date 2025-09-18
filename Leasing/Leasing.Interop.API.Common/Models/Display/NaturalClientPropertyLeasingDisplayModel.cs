namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class NaturalClientPropertyLeasingDisplayModel : Contract.AbstractLeasingDisplayModel<Persistence.Entities.NaturalClientPropertyLeasing>
    {
        public NaturalClientPropertyLeaseContractDisplayModel Contract { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel[] Workers { get; set; }

        public override void Import(Persistence.Entities.NaturalClientPropertyLeasing entity)
        {
            base.Import(entity);
        }
    }
}
