namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class AgreementConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.AgreementDisplayModel>
    {
        public static string TitleValidableProperty => nameof(Title);

        private int index;
        private string title;
        private string description;
        private bool hasEndDate;
        private System.DateTime endAt = System.DateTime.Now;
        private Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel responsible;

        public AgreementConfigurationPageModel(Interop.API.Common.Models.Display.AgreementDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                Index = model.Index;
                Title = model.Title;
                Description = model.Description;
                Responsible = model.Responsible;
                HasEndDate = model.EndAt != null;

                if (HasEndDate)
                {
                    EndAt = model.EndAt.Value;
                }
            }
        }

        public System.Guid Id { get; set; }

        public int Index { get => index; set => SetProperty(ref index, value); }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel Responsible { get => responsible; set => SetProperty(ref responsible, value); }
        
        public bool HasEndDate { get => hasEndDate; set => SetProperty(ref hasEndDate, value); }
        
        public System.DateTime EndAt { get => endAt; set => SetProperty(ref endAt, value); }
    }
}
