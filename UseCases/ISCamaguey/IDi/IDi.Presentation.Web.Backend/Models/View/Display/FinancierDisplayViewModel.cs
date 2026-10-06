namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Web.Backend.Models.View.Display
{
    public class FinancierDisplayViewModel : Interop.API.Common.Models.Display.FinancierDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.Financier entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
