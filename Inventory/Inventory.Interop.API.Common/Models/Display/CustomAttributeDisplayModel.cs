namespace MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display
{
	public class CustomAttributeDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.CustomAttribute, System.Guid>
	{
		public System.Guid Id { get; set; }

        public void Import(Persistence.Entities.CustomAttribute entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

