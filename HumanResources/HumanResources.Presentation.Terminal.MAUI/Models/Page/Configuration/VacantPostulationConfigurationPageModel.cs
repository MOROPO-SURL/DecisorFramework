using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VacantPostulationConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.VacantPostulationDisplayModel>
    {
        private Interop.API.Common.Models.Display.VacantDisplayModel vacant;
        private Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel officialPostalContactItem;
        private Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel alternativePostalContactItem;
        private Domain.Persistence.Enumerations.EducationLevel educationLevel;
        private string schoolingComplement;
        private string maleParentName;
        private string femaleParentName;
        private string alignment;
        private string responsabilityCommitment;
        private System.DateTime at = System.DateTime.Now;
        private string personalIdentificationNumber;

        public VacantPostulationConfigurationPageModel(Interop.API.Common.Models.Display.VacantPostulationDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Staff = model.Staff;
                vacant = model.Vacant;
                contact = model.Contact;
                personalIdentificationNumber = model.Contact.PersonalIdentificationNumber;
                at = model.At;
                officialPostalContactItem = model.OfficialPostalContactItem;
                alternativePostalContactItem = model.AlternativePostalContactItem;
                EducationLevel = model.EducationLevel;
                schoolingComplement = model.SchoolingComplement;
                maleParentName = model.MaleParentName;
                femaleParentName = model.FemaleParentName;
                alignment = model.Alignment;
                responsabilityCommitment = model.ResponsabilityCommitment;
                Ocupations = new ObservableCollection<Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel>(model.Ocupations);
                Documents = new ObservableCollection<Core.Interop.API.Common.Models.Display.DocumentDisplayModel>(model.Documents);
            }
        }

        public System.Guid Id { get; set; }

        public Interop.API.Common.Models.Display.StaffDisplayModel Staff { get; set; }

        public Interop.API.Common.Models.Display.VacantDisplayModel Vacant { get => vacant; set => SetProperty(ref vacant, value); }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel OfficialPostalContactItem { get => officialPostalContactItem; set => SetProperty(ref officialPostalContactItem, value); }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel AlternativePostalContactItem { get => alternativePostalContactItem; set => SetProperty(ref alternativePostalContactItem, value); }

        public Domain.Persistence.Enumerations.EducationLevel EducationLevel { get => educationLevel; set => SetProperty(ref educationLevel, value); }

        public string SchoolingComplement { get => schoolingComplement; set => SetProperty(ref schoolingComplement, value); }

        public string MaleParentName { get => maleParentName; set => SetProperty(ref maleParentName, value); }

        public string FemaleParentName { get => femaleParentName; set => SetProperty(ref femaleParentName, value); }

        public string Alignment { get => alignment; set => SetProperty(ref alignment, value); }

        public string ResponsabilityCommitment { get => responsabilityCommitment; set => SetProperty(ref responsabilityCommitment, value); }

        public System.DateTime At { get => at; set => SetProperty(ref at, value); }

        public string PersonalIdentificationNumber { get => personalIdentificationNumber; set => SetProperty(ref personalIdentificationNumber, value); }

        public ObservableCollection<Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel> Ocupations { get; set; } = [];

        public ObservableCollection<Core.Interop.API.Common.Models.Display.DocumentDisplayModel> Documents { get; set; } = [];
    }
}