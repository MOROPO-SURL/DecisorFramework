namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input
{
    public class CurrencyInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.Currency, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Symbol { get; set; }

        public bool UseEndSymbolPresentation { get; set; }

        public int Priority { get; set; }

        public override Persistence.Entities.Currency Export()
        {
            var entity = new Persistence.Entities.Currency { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.Currency entity)
        {
            entity.Name = Name;
            entity.Symbol = Symbol;
            entity.UseEndSymbolPresentation = UseEndSymbolPresentation;
            entity.Priority = Priority;
        }
    }
}
