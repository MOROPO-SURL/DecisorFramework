using System.Linq;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display
{
    public class LegalClientServicingContractDisplayModel : Framework.Decisor.Legal.Interop.API.Common.Models.Display.Contract.AbstractContractDisplayModel<Persistence.Entities.LegalClientServicingContract>
    {
        public Framework.Decisor.Commercial.Interop.API.Common.Models.Display.PaymentTermDisplayModel PaymentTerm { get; set; }

        public Framework.Decisor.Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel BankAccount { get; set; }

        public TrainingServiceDisplayModel[] TrainingServices { get; set; }

        public GroundIntegralStudyServiceDisplayModel[] GroundIntegralStudyServices { get; set; }

        public SampleAnalysisServiceDisplayModel[] SampleAnalysisServices { get; set; }

        public Framework.Decisor.Commercial.Interop.API.Common.Models.Display.LegalClientDisplayModel Client { get; set; }

        public Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel Document { get; set; }

        public override void Import(Persistence.Entities.LegalClientServicingContract entity)
        {
            base.Import(entity);

            if (entity.PaymentTerm != null)
            {
                PaymentTerm = new Framework.Decisor.Commercial.Interop.API.Common.Models.Display.PaymentTermDisplayModel();

                PaymentTerm.Import(entity.PaymentTerm);
            }

            if (entity.BankAccount != null)
            {
                BankAccount = new Framework.Decisor.Financial.Interop.API.Common.Models.Display.BankAccountDisplayModel();

                BankAccount.Import(entity.BankAccount);
            }

            if (entity.Client != null)
            {
                Client = new Framework.Decisor.Commercial.Interop.API.Common.Models.Display.LegalClientDisplayModel();

                Client.Import(entity.Client);
            }

            if (entity.Document != null)
            {
                Document = new Framework.Decisor.Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                Document.Import(entity.Document);
            }

            TrainingServices = entity.TrainingServiceBridges.Select(bridge =>
            {
                var model = new TrainingServiceDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();

            GroundIntegralStudyServices = entity.GroundIntegralStudyServiceBridges.Select(bridge =>
            {
                var model = new GroundIntegralStudyServiceDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();

            SampleAnalysisServices = entity.SampleAnalysisServiceBridges.Select(bridge =>
            {
                var model = new SampleAnalysisServiceDisplayModel();

                model.Import(bridge.Stern);

                return model;
            }).ToArray();
        }
    }
}
