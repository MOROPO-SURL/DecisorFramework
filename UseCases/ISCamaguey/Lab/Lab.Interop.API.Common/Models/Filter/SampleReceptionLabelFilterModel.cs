namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Filter
{
    public class SampleReceptionLabelFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Persistence.Entities.SampleReceptionLabel, System.Guid>
    {
        public string Reference { get; set; }

        public bool? HasSample { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.SampleReceptionLabel, bool>> GetSelector()
        {
            if (HasSample != null)
            {
                if (!string.IsNullOrEmpty(Reference))
                {
                    return entity => entity.Sample != null == HasSample && entity.Reference.ToLower().Contains(Reference.ToLower());
                }

                return entity => entity.Sample != null == HasSample;
            }

            return entity => entity.Reference.ToLower().Contains(Reference.ToLower());
        }
    }
}
