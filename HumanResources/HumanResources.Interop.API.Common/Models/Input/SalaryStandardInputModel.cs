namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class SalaryStandardInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.SalaryStandard, System.Guid>
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Priority { get; set; }

        public double Fee { get; set; }

        public Persistence.Entities.SalaryStandard Export()
        {
            var entity = new Persistence.Entities.SalaryStandard { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.SalaryStandard entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.SalaryStandard entity)
        {
            entity.Name = Name;
            entity.Priority = Priority;
            entity.Fee = Fee;
        }
    }
}
