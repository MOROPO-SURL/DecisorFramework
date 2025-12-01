namespace MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display
{
    public class CommonSampleAnalysisServiceOrderDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Servicing.Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder, long>
    {
        public long Id { get; set; }

        public System.DateTime At { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public Servicing.Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel Service { get; set; }

        public Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel RequestedTechnique { get; set; }

        public virtual void Import(Servicing.Persistence.Entities.Contract.AbstractSampleAnalysisServiceOrder entity)
        {
            Id = entity.Id;
            At = entity.At;
            Description = entity.Description;
            Enabled = entity.Enabled;
            Priority = entity.Priority;

            if (entity.Service != null)
            {
                Service = new Servicing.Interop.API.Common.Models.Display.SampleAnalysisServiceDisplayModel();

                Service.Import(entity.Service);
            }

            if (entity.RequestedTechnique != null)
            {
                RequestedTechnique = new Domain.Interop.API.Common.Models.Display.TechniqueDisplayModel();

                RequestedTechnique.Import(entity.RequestedTechnique);
            }
        }
    }
}
