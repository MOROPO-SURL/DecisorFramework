namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page
{
	public class MainPageModel : Caney.MVVM.Core.Models.Page.BasePageModel
	{
		private Interop.API.Common.Models.Display.UserDisplayModel user;
        private long? notificationCount;

        public Interop.API.Common.Models.Display.UserDisplayModel User { get => user; set => SetProperty(ref user, value); }

        public View.OwnerInformationViewModel OwnerInformation { get; set; }

        public long? NotificationCount { get => notificationCount; set => SetProperty(ref notificationCount, value); }
    }
}

