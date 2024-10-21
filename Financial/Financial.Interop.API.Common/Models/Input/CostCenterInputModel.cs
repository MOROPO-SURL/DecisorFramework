namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input
{
    public class CostCenterInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.CostCenter, System.Guid>
    {
        public System.Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public Persistence.Entities.CostCenter Export()
        {
            var entity = new Persistence.Entities.CostCenter { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.CostCenter entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.CostCenter entity)
        {
            entity.Name = Name;
            entity.About = Description;
            entity.Priority = Priority;
        }
    }
}

