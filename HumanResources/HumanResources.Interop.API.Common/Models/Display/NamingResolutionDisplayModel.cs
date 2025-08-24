namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class NamingResolutionDisplayModel : Legal.Interop.API.Common.Models.Display.Contract.AbstractResolutionDisplayModel<Persistence.Entities.NamingResolution>
    {
        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get; set; }

        public override void Import(Persistence.Entities.NamingResolution entity)
        {
            base.Import(entity);

            if (entity.Contact != null)
            {
                Contact = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                Contact.Import(entity.Contact);
            }
        }
    }
}
