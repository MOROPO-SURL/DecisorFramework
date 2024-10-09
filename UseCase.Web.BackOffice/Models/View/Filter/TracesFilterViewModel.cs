namespace MOROPO.Framework.Decisor.UseCase.Web.BackOffice.Models.View.Filter
{
    public class TracesFilterViewModel : Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Guama.Core.Persistence.ORM.EF.Entities.Trace, long>
    {
        public string Author { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Guama.Core.Persistence.ORM.EF.Entities.Trace, bool>> GetSelector()
        {
            if (string.IsNullOrEmpty(Author)) return entity => true;

            return entity => entity.Author.ToLower().Contains(Author.ToLower());
        }
    }
}
