namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class SampleAnalysisServiceDisplayModel : Contract.AbstractServiceDisplayModel<Persistence.Entities.SampleAnalysisService>
    {
        public Domain.Interop.API.Common.Models.Display.SampleKindDisplayModel SampleKind { get; set; }

        public SampleAnalysisServiceStepDisplayModel[] Steps { get; set; }

        public override void Import(Persistence.Entities.SampleAnalysisService entity)
        {
            base.Import(entity);

            if (entity.SampleKind != null)
            {
                SampleKind = new Domain.Interop.API.Common.Models.Display.SampleKindDisplayModel();

                SampleKind.Import(entity.SampleKind);
            }
        }
    }
}
