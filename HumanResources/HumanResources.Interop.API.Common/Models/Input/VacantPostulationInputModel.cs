using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Input;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class VacantPostulationInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.VacantPostulation, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public System.Guid StaffId { get; set; }

        public System.Guid VacantId { get; set; }

        public System.Guid ContactId { get; set; }

        public System.Guid OfficialPostalContactItemId { get; set; }

        public System.Guid? AlternativePostalContactItemId { get; set; }

        public System.Guid SchoolingId { get; set; }

        public string SchoolingComplement { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string MaleParentName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string FemaleParentName { get; set; }

        public string Alignment { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string ResponsabilityCommitment { get; set; }

        public string PersonalIdentificationNumber { get; set; }

        public Core.Interop.API.Common.Models.Input.DocumentInputModel RawModelDocument { get; set; }

        public List<DocumentInputModel> EditionDocuments { get; set; } = new List<DocumentInputModel>();
        public List<DocumentInputModel> IncomingDocuments { get; set; } = new List<DocumentInputModel>();
        public List<DocumentDisplayModel> OutgoingDocuments { get; set; } = new List<DocumentDisplayModel>();

        public List<VacantPostulationOcupationInputModel> EditionOcupations { get; set; } = new List<VacantPostulationOcupationInputModel>();
        public List<VacantPostulationOcupationInputModel> IncomingOcupations { get; set; } = new List<VacantPostulationOcupationInputModel>();
        public List<Display.VacantPostulationOcupationDisplayModel> OutgoingOcupations { get; set; } = new List<Display.VacantPostulationOcupationDisplayModel>();

        public Persistence.Entities.VacantPostulation Export()
        {
            var entity = new Persistence.Entities.VacantPostulation { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.VacantPostulation entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.VacantPostulation entity)
        {
            entity.At = At;
            entity.SchoolingComplement = SchoolingComplement;
            entity.MaleParentName = MaleParentName;
            entity.FemaleParentName = FemaleParentName;
            entity.Alignment = Alignment;
            entity.ResponsabilityCommitment = ResponsabilityCommitment;

            if (entity.StaffId != StaffId)
            {
                entity.Staff = null;
                entity.StaffId = StaffId;
            }

            if (entity.VacantId != VacantId)
            {
                entity.Vacant = null;
                entity.VacantId = VacantId;
            }

            if (entity.ContactId != ContactId)
            {
                entity.Contact = null;
                entity.ContactId = ContactId;
            }

            if (entity.OfficialPostalContactItemId != OfficialPostalContactItemId)
            {
                entity.OfficialPostalContactItem = null;
                entity.OfficialPostalContactItemId = OfficialPostalContactItemId;
            }

            if (entity.AlternativePostalContactItemId != AlternativePostalContactItemId)
            {
                entity.AlternativePostalContactItem = null;
                entity.AlternativePostalContactItemId= AlternativePostalContactItemId;
            }

            if (entity.SchoolingId != SchoolingId)
            {
                entity.Schooling = null;
                entity.SchoolingId = SchoolingId;
            }
        }
    }
}
