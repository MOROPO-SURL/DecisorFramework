using System.Collections.ObjectModel;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VacantPostulationConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.VacantPostulationDisplayModel>
    {
        private Interop.API.Common.Models.Display.VacantDisplayModel vacant;
        private Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel contact;
        private Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel officialPostalContactItem;
        private Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel alternativePostalContactItem;
        private Interop.API.Common.Models.Display.SchoolingDisplayModel schooling;
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
                Vacant = model.Vacant;
                Contact = model.Contact;
                PersonalIdentificationNumber = model.Contact.PersonalIdentificationNumber;
                At = model.At;
                OfficialPostalContactItem = model.OfficialPostalContactItem;
                AlternativePostalContactItem = model.AlternativePostalContactItem;
                Schooling = model.Schooling;
                SchoolingComplement = model.SchoolingComplement;
                MaleParentName = model.MaleParentName;
                FemaleParentName = model.FemaleParentName;
                Alignment = model.Alignment;
                ResponsabilityCommitment = model.ResponsabilityCommitment;
                Ocupations = new ObservableCollection<Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel>(model.Ocupations);
                Documents = new ObservableCollection<Core.Interop.API.Common.Models.Display.DocumentDisplayModel>(model.Documents);
            }
        }

        public System.Guid Id { get; set; }

        public Interop.API.Common.Models.Display.StaffDisplayModel Staff { get; set; }

        public Interop.API.Common.Models.Display.VacantDisplayModel Vacant { get => vacant; set => SetProperty(ref vacant, value); }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel OfficialPostalContactItem { get => officialPostalContactItem; set => officialPostalContactItem = value; }

        public Core.Interop.API.Common.Models.Display.PostalContactItemDisplayModel AlternativePostalContactItem { get => alternativePostalContactItem; set => alternativePostalContactItem = value; }

        public Interop.API.Common.Models.Display.SchoolingDisplayModel Schooling { get => schooling; set => schooling = value; }

        public string SchoolingComplement { get => schoolingComplement; set => schoolingComplement = value; }

        public string MaleParentName { get => maleParentName; set => maleParentName = value; }

        public string FemaleParentName { get => femaleParentName; set => femaleParentName = value; }

        public string Alignment { get => alignment; set => alignment = value; }

        public string ResponsabilityCommitment { get => responsabilityCommitment; set => responsabilityCommitment = value; }

        public System.DateTime At { get => at; set => SetProperty(ref at, value); }

        public string PersonalIdentificationNumber { get => personalIdentificationNumber; set => SetProperty(ref personalIdentificationNumber, value); }

        public ObservableCollection<Interop.API.Common.Models.Display.VacantPostulationOcupationDisplayModel> Ocupations { get; set; } = [];

        public ObservableCollection<Core.Interop.API.Common.Models.Display.DocumentDisplayModel> Documents { get; set; } = [];

        public Interop.API.Common.Models.Display.SchoolingDisplayModel[] AvailableSchoolings { get; set; }
    }
}