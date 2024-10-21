namespace MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display
{
	public class PermissionDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Guama.Core.Security.Common.Persistence.Entities.Permission, int>
	{
		public int Id { get; set; }

        public string Code { get; set; }

        public string Family { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public void Import(Guama.Core.Security.Common.Persistence.Entities.Permission entity)
        {
            Id = entity.Id;
            Code = entity.Code;
            Family = entity.Family;
            Name = entity.Name;
            Description = entity.Description;
        }
    }
}

