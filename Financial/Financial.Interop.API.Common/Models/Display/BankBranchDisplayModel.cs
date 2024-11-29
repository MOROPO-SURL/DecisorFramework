namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display
{
    public class BankBranchDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.BankBranch, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public BankAgencyDisplayModel Agency { get; set; }

        public int Number { get; set; }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel PostalContact { get; set; }

        public void Import(Persistence.Entities.BankBranch entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;
            At = entity.At;
            Number = entity.Number;

            if (entity.Agency != null)
            {
                Agency = new BankAgencyDisplayModel();

                Agency.Import(entity.Agency);
            }

            if (entity.PostalContact != null)
            {
                PostalContact = new Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel();

                PostalContact.Import(entity.PostalContact);
            }
        }

        public override string ToString()
        {
            return $"{Agency.Name}, {Number}";
        }
    }
}
