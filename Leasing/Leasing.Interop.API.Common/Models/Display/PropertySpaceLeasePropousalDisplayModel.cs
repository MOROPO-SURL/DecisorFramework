namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class PropertySpaceLeasePropousalDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PropertySpaceLeasePropousal, System.Guid>
    {
        public System.Guid Id { get; set; }

        public Domain.Interop.API.Common.Models.Display.PropertySpaceDisplayModel Space { get; set; }

        public string Argument { get; set; }

        public void Import(Persistence.Entities.PropertySpaceLeasePropousal entity)
        {
            Id = entity.Id;
            Argument = entity.Argument;

            if (entity.PropertySpace != null)
            {
                Space = new Domain.Interop.API.Common.Models.Display.PropertySpaceDisplayModel();

                Space.Import(entity.PropertySpace);
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PropertySpaceLeasePropousalDisplayModel)) return false;

            return Id.Equals((obj as PropertySpaceLeasePropousalDisplayModel).Id);
        }
    }
}
