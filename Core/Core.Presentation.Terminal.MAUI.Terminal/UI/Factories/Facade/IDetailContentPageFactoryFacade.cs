namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade
{
    public interface IDetailContentPageFactoryFacade<TModel, TDetailContentPage>
        where TModel : class
        where TDetailContentPage : Pages.Base.DetailBaseContentPage<TModel>
    {
        TDetailContentPage Build(TModel model, System.Action<TModel,int> delegationAction = null);
    }
}