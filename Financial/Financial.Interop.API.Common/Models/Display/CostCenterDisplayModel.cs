namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display
{
	public class CostCenterDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.CostCenter, System.Guid>
	{
		public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; }

        public void Import(Persistence.Entities.CostCenter entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.About;
            Priority = entity.Priority;
            At = entity.At;
        }
    }
}

