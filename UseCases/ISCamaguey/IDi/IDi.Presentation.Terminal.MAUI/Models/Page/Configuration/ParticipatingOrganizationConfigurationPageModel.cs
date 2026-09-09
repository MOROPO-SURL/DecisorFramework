namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ParticipatingOrganizationConfigurationPageModel : Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel>
    {
        public static string ContactValidableProperty => nameof(Contact);

        private Framework.Decisor.Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel contact;
        private int priority = 1;

        public ParticipatingOrganizationConfigurationPageModel(Interop.API.Common.Models.Display.ParticipatingOrganizationDisplayModel model) : base(model)
        {
            if (model == null) return;

            Id = model.Id;
            contact = model.Contact;
            priority = model.Priority;
            KnowledgeAreas = [.. model.KnowledgeAreas];
        }

        public System.Guid Id { get; set; }

        public Framework.Decisor.Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel Contact { get => contact; set => SetProperty(ref contact, value); }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public System.Collections.ObjectModel.ObservableCollection<Framework.Decisor.Domain.Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel> KnowledgeAreas { get; set; } = [];
    }
}
