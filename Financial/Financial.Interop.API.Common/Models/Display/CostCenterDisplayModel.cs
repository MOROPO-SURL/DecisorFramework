namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display
{
	public class CostCenterDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.CostCenter, System.Guid>
	{
		public System.Guid Id { get; set; }

        public void Import(Persistence.Entities.CostCenter entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

