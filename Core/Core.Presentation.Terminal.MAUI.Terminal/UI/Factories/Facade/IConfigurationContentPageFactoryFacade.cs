namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade
{
    public interface IConfigurationContentPageFactoryFacade<TModel, TConfigurationPageModel, TConfigurationContentPage>
        where TModel : class
        where TConfigurationPageModel : Models.Page.Contract.AbstractConfigurationPageModel<TModel>
        where TConfigurationContentPage : Pages.Base.ConfigurationBaseContentPage<TModel, TModel, TConfigurationPageModel>
    {
        TConfigurationContentPage Build(System.Action<TModel> configurationSuccessAction, TConfigurationPageModel model);
    }
}
