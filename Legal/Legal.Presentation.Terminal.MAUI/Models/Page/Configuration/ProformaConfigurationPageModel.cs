namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class ProformaConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.ProformaDisplayModel>
    {
        private string name;
        private string description;
        private Core.Interop.API.Common.Models.Display.DocumentDisplayModel rawDocument;

        public ProformaConfigurationPageModel() : this(null) { }

        public ProformaConfigurationPageModel(Interop.API.Common.Models.Display.ProformaDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Description = model.Description;
                RawDocument = model.RawDocument;

                if (model.RawDocument != null)
                {
                    RawDocumentId = model.RawDocument.Id;
                }
            }
        }

        public System.Guid Id { get; set; }

        public System.Guid? RawDocumentId { get; set; }

        public string Name { get => name; set => SetProperty(ref name, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel RawDocument { get => rawDocument; set => SetProperty(ref rawDocument, value); }
    }
}
