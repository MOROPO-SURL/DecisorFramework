namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class DesignationResolutionDisplayModel : Contract.AbstractIncorporationResolutionDisplayModel<Persistence.Entities.DesignationResolution>
    {
        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get; set; }

        public VacantDisplayModel Vacant { get; set; }

        public StaffDisplayModel Staff { get; set; }

        public override void Import(Persistence.Entities.DesignationResolution entity)
        {
            base.Import(entity);

            ConcretedAt = entity.ConcretedAt;

            if (entity.Contact != null)
            {
                Contact = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                Contact.Import(entity.Contact);
            }

            if (entity.Vacant != null)
            {
                Vacant = new VacantDisplayModel();

                Vacant.Import(entity.Vacant);
            }

            if (entity.Staff != null)
            {
                Staff = new StaffDisplayModel();

                Staff.Import(entity.Staff);
            }
        }
    }
}
