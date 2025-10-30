namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display
{
    public class LegalProviderBudgetDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.LegalProviderBudget, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Number { get; set; }

        public int Year { get; set; }

        public bool Enabled { get; set; }

        public System.DateTime At { get; set; }

        public System.DateTime? SharedAt { get; set; }

        public System.DateTime? ConfirmedAt { get; set; }

        public string Description { get; set; }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Commercial { get; set; }

        public Commercial.Interop.API.Common.Models.Display.LegalProviderDisplayModel Provider { get; set; }

        public System.Collections.Generic.List<Bridge.CommonBugetProductBridgeModel> ProductBridges { get; set; } = new System.Collections.Generic.List<Bridge.CommonBugetProductBridgeModel>();

        public void Import(Persistence.Entities.LegalProviderBudget entity)
        {
            Id = entity.Id;
            Number = entity.Number;
            Year = entity.Year;
            Enabled = entity.Enabled;
            At = entity.At;
            SharedAt = entity.SharedAt;
            ConfirmedAt = entity.ConfirmedAt;
            Description = entity.Description;

            if (entity.Commercial != null)
            {
                Commercial = new Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                Commercial.Import(entity.Commercial);
            }

            if (entity.Provider != null)
            {
                Provider = new Commercial.Interop.API.Common.Models.Display.LegalProviderDisplayModel();

                Provider.Import(entity.Provider);
            }
        }
    }
}
