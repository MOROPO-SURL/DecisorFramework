namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display
{
    public class CostCenterDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.CostCenter, System.Guid>
	{
		public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public BankAccountDisplayModel DefaultBankAccount { get; set; }

        public Domain.Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel Structure { get; set; }

        public void Import(Persistence.Entities.CostCenter entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.About;
            Priority = entity.Priority;
            At = entity.At;

            if (entity.DefaultBankAccount != null)
            {
                DefaultBankAccount = new BankAccountDisplayModel();

                DefaultBankAccount.Import(entity.DefaultBankAccount);
            }

            if (entity.Structure != null)
            {
                Structure = new Domain.Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel();

                Structure.Import(entity.Structure);
            }
        }
    }
}

