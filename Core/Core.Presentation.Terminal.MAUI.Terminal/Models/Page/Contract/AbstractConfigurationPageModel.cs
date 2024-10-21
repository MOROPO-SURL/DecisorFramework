namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.Contract
{
    public abstract class AbstractConfigurationPageModel<TModel> : Caney.MVVM.Core.Models.Page.BasePageModel
    {
        protected AbstractConfigurationPageModel(TModel model)
        {
            OnEditionMode = model != null;
        }

        public bool OnEditionMode { get; private set; }
    }
}
