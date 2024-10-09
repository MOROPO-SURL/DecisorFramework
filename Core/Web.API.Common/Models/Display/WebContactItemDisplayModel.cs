namespace MOROPO.Framework.Decisor.Core.Web.API.Common.Models.Display
{
    public class WebContactItemDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Guama.Identity.Persistence.Entities.WebSiteContactItem, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Label { get; set; }

        public string Url { get; set; }

        public void Import(Guama.Identity.Persistence.Entities.WebSiteContactItem entity)
        {
            Id = entity.Id;
            Label = entity.Label;
            Url = entity.Url;
        }
    }
}
