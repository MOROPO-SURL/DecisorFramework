namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display
{
    public class CurrencyDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Currency, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public bool UseEndSymbolPresentation { get; set; }

        public void Import(Persistence.Entities.Currency entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Symbol = entity.Symbol;
            UseEndSymbolPresentation = entity.UseEndSymbolPresentation;
            Priority = entity.Priority;
        }
    }
}
