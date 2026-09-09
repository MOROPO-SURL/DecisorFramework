namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class SalaryStandardInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.SalaryStandard, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Priority { get; set; }

        public float Fee { get; set; }

        public override Persistence.Entities.SalaryStandard Export()
        {
            var entity = new Persistence.Entities.SalaryStandard { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.SalaryStandard entity)
        {
            entity.Name = Name;
            entity.Priority = Priority;
            entity.Fee = Fee;
        }
    }
}
