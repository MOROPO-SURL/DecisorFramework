namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page
{
	public class MainPageModel : Caney.MVVM.Core.Models.Page.BasePageModel
	{
		private Interop.API.Common.Models.Display.UserDisplayModel user;

        public Interop.API.Common.Models.Display.UserDisplayModel User { get => user; set => SetProperty(ref user, value); }
	}
}

