namespace MOROPO.Framework.Decisor.Commercial.Presentation.Web.Backend.Models.View.Display
{
    public class PaymentTermViewDisplayModel : Interop.API.Common.Models.Display.PaymentTermDisplayModel
    {
        public bool Archived { get; set; }

        public override void Import(Persistence.Entities.PaymentTerm entity)
        {
            base.Import(entity);

            Archived = entity.Archived;
        }
    }
}
