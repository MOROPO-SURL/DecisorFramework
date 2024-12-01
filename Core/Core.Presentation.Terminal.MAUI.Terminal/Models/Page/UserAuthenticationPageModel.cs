namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page
{
    public class UserAuthenticationPageModel : Caney.MVVM.Core.Models.Page.BasePageModel
    {
        private string userName;

        private string password;

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public View.OwnerInformationViewModel OwnerInformation { get; set; }
    }
}
