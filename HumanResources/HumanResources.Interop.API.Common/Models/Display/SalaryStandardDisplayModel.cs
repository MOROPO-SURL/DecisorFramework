namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class SalaryStandardDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.SalaryStandard, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public float Fee { get; set; }

        public void Import(Persistence.Entities.SalaryStandard entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            Fee = entity.Fee;
        }
    }
}
