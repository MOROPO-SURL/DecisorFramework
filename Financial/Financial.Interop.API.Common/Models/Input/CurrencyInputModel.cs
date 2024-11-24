namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input
{
    public class CurrencyInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.Currency, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Symbol { get; set; }

        public bool UseEndSymbolPresentation { get; set; }

        public int Priority { get; set; }

        public Persistence.Entities.Currency Export()
        {
            var entity = new Persistence.Entities.Currency { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.Currency entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.Currency entity)
        {
            entity.Name = Name;
            entity.Symbol = Symbol;
            entity.UseEndSymbolPresentation = UseEndSymbolPresentation;
            entity.Priority = Priority;
        }
    }
}
