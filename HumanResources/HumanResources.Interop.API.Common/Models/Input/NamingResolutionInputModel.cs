namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class NamingResolutionInputModel : Legal.Interop.API.Common.Models.Input.Contract.AbstractResolutionInputModel<Persistence.Entities.NamingResolution>
    {
        public System.Guid ContactId { get; set; }

        public override void Mergue(Persistence.Entities.NamingResolution entity)
        {
            base.Mergue(entity);

            if (entity.ContactId != ContactId)
            {
                entity.Contact = null;
                entity.ContactId = ContactId;
            }
        }
    }
}
