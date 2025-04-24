namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class OrganizationDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Organization, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Display.OrganizationIdentityDisplayModel Identity { get; set; }

        public virtual void Import(Persistence.Entities.Organization entity)
        {
            Id = entity.Id;
            Priority = entity.Priority;

            if (entity.Identity != null)
            {
                Identity = new Framework.Decisor.Core.Interop.API.Common.Models.Display.OrganizationIdentityDisplayModel();

                Identity.Import(entity.Identity);
            }
        }
    }
}
