namespace MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display
{
    public class PhoneContactItemDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Guama.Identity.Persistence.Entities.PhoneContactItem, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Label { get; set; }

        public string PhoneNumber { get; set; }

        public void Import(Guama.Identity.Persistence.Entities.PhoneContactItem entity)
        {
            Id = entity.Id;
            Label = entity.Label;
            PhoneNumber = entity.PhoneNumber;
        }
    }
}
