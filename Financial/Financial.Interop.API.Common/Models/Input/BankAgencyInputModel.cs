namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input
{
    public class BankAgencyInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.BankAgency, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public Core.Interop.API.Common.Models.Input.ImageInputModel Image { get; set; }

        public string About { get; set; }

        public Persistence.Entities.BankAgency Export()
        {
            var entity = new Persistence.Entities.BankAgency { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.BankAgency entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.BankAgency entity)
        {
            entity.Name = Name;
            entity.Priority = Priority;
            entity.About = About;
        }
    }
}
