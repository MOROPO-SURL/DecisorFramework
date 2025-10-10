namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display
{
    public class VacantPostulationDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.VacantPostulation, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public StaffDisplayModel Staff { get; set; }

        public VacantDisplayModel Vacant { get; set; }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get; set; }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel OfficialPostalContactItem { get; set; }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel AlternativePostalContactItem { get; set; }

        public SchoolingDisplayModel Schooling { get; set; }

        public string SchoolingComplement { get; set; }

        public string MaleParentName { get; set; }

        public string FemaleParentName { get; set; }

        public string Alignment { get; set; }

        public string ResponsabilityCommitment { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel RawModelDocument { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel[] Documents { get; set; }

        public VacantPostulationOcupationDisplayModel[] Ocupations { get; set; }

        public void Import(Persistence.Entities.VacantPostulation entity)
        {
            Id = entity.Id;
            At = entity.At;
            SchoolingComplement = entity.SchoolingComplement;
            MaleParentName = entity.MaleParentName;
            FemaleParentName = entity.FemaleParentName;
            Alignment = entity.Alignment;
            ResponsabilityCommitment = entity.ResponsabilityCommitment;

            if (entity.Staff != null)
            {
                Staff = new StaffDisplayModel();

                Staff.Import(entity.Staff);
            }

            if (entity.Vacant != null)
            {
                Vacant = new VacantDisplayModel();

                Vacant.Import(entity.Vacant);
            }

            if (entity.Contact != null)
            {
                Contact = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                Contact.Import(entity.Contact);
            }

            if (entity.OfficialPostalContactItem != null)
            {
                OfficialPostalContactItem = new Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel();

                OfficialPostalContactItem.Import(entity.OfficialPostalContactItem);
            }

            if (entity.AlternativePostalContactItem != null)
            {
                AlternativePostalContactItem = new Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel();

                AlternativePostalContactItem.Import(entity.AlternativePostalContactItem);
            }

            if (entity.Schooling != null)
            {
                Schooling = new SchoolingDisplayModel();

                Schooling.Import(entity.Schooling);
            }

            if (entity.RawModelDocument != null)
            {
                RawModelDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                RawModelDocument.Import(entity.RawModelDocument);
            }
        }
    }
}
