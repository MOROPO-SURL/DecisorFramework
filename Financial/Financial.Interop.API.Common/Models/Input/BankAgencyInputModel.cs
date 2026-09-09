namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input
{
    public class BankAgencyInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.BankAgency, System.Guid>
    {
        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Alias { get; set; }

        public Core.Interop.API.Common.Models.Input.ImageInputModel Image { get; set; }

        public string About { get; set; }

        public override Persistence.Entities.BankAgency Export()
        {
            var entity = new Persistence.Entities.BankAgency { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.BankAgency entity)
        {
            entity.Name = Name;
            entity.Alias = Alias;
            entity.Priority = Priority;
            entity.About = About;
        }
    }
}
