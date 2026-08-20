namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class DesignationResolutionInputModel : Contract.AbstractIncorporationResolutionInputModel<Persistence.Entities.DesignationResolution>
    {
        public System.Guid ContactId { get; set; }

        public System.Guid VacantId { get; set; }

        public System.Guid StaffId { get; set; }

        public override void Mergue(Persistence.Entities.DesignationResolution entity)
        {
            base.Mergue(entity);

            if (entity.ContactId != ContactId)
            {
                entity.Contact = null;
                entity.ContactId = ContactId;
            }

            if (entity.VacantId != VacantId)
            {
                entity.Vacant = null;
                entity.VacantId = VacantId;
            }

            if (entity.StaffId != StaffId)
            {
                entity.Staff = null;
                entity.StaffId = StaffId;
            }
        }
    }
}
