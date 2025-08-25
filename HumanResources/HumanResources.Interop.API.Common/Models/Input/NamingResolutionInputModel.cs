namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class NamingResolutionInputModel : Legal.Interop.API.Common.Models.Input.Contract.AbstractResolutionInputModel<Persistence.Entities.NamingResolution>
    {
        public System.Guid ContactId { get; set; }

        public System.Guid AgreementId { get; set; }

        public System.Guid VacantId { get; set; }

        public System.Guid StaffId { get; set; }

        public override void Mergue(Persistence.Entities.NamingResolution entity)
        {
            base.Mergue(entity);

            if (entity.ContactId != ContactId)
            {
                entity.Contact = null;
                entity.ContactId = ContactId;
            }

            if (entity.AgreementId != AgreementId)
            {
                entity.Agreement = null;
                entity.AgreementId = AgreementId;
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
