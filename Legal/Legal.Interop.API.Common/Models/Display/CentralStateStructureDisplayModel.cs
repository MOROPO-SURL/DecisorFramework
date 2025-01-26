namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display
{
    public class CentralStateStructureDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.CentralStateStructure, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public Core.Interop.API.Common.Models.Display.OrganizationIdentityDisplayModel Identity { get; set; }

        public void Import(Persistence.Entities.CentralStateStructure entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;

            if (entity.Identity != null)
            {
                Identity = new Core.Interop.API.Common.Models.Display.OrganizationIdentityDisplayModel();

                Identity.Import(entity.Identity);
            }
        }
    }
}
