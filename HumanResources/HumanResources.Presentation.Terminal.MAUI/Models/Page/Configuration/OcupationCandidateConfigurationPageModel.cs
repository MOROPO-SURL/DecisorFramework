using MOROPO.Framework.Decisor.Core.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class OcupationCandidateConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.OcupationCandidateDisplayModel>
    {
        private System.DateTime interviewAt;
        private VacantPostulationDisplayModel postulation;
        private EmployeeDisplayModel responsible;
        private string description;
        private System.DateTime? medicalCheckAt;
        private DocumentDisplayModel rawMedicalCheckDocument;
        private System.DateTime? physicologicalCheckAt;
        private DocumentDisplayModel rawPhysicologicalCheckDocument;
        private System.DateTime? defenseStatusCheckAt;
        private DocumentDisplayModel rawDefenseStatusCheckDocument;
        private System.DateTime researchRequestAt;
        private System.DateTime researchResultAt;
        private DocumentDisplayModel rawResearchResultDocument;
        private DocumentDisplayModel rawModelDocument;

        public OcupationCandidateConfigurationPageModel(Interop.API.Common.Models.Display.OcupationCandidateDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                interviewAt = model.InterviewAt;
                postulation = model.Postulation;
                responsible = model.Responsible;
                description = model.Description;
                medicalCheckAt = model.MedicalCheckAt;
                rawMedicalCheckDocument = model.RawMedicalCheckDocument;
                physicologicalCheckAt = model.PhysicologicalCheckAt;
                rawPhysicologicalCheckDocument = model.RawPhysicologicalCheckDocument;
                defenseStatusCheckAt = model.DefenseStatusCheckAt;
                rawDefenseStatusCheckDocument = model.RawDefenseStatusCheckDocument;
                researchRequestAt = model.ResearchRequestAt;
                researchResultAt = model.ResearchResultAt;
                rawResearchResultDocument = model.RawResearchResultDocument;
                rawModelDocument = model.RawModelDocument;
            }
            else
            {
                var now = System.DateTime.Now;

                interviewAt = now;
                medicalCheckAt = now;
                physicologicalCheckAt= now;
                defenseStatusCheckAt= now;
                researchRequestAt= now;
                researchResultAt= now;
            }
        }

        public System.Guid Id { get; set; }

        public System.DateTime InterviewAt { get => interviewAt; set => SetProperty(ref interviewAt, value); }

        public VacantPostulationDisplayModel Postulation { get => postulation; set => SetProperty(ref postulation, value); }

        public EmployeeDisplayModel Responsible { get => responsible; set => SetProperty(ref responsible, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public System.DateTime? MedicalCheckAt { get => medicalCheckAt; set => SetProperty(ref medicalCheckAt, value); }

        public DocumentDisplayModel RawMedicalCheckDocument { get => rawMedicalCheckDocument; set => SetProperty(ref rawMedicalCheckDocument, value); }

        public System.DateTime? PhysicologicalCheckAt { get => physicologicalCheckAt; set => SetProperty(ref physicologicalCheckAt, value); }

        public DocumentDisplayModel RawPhysicologicalCheckDocument { get => rawPhysicologicalCheckDocument; set => SetProperty(ref rawPhysicologicalCheckDocument, value); }

        public System.DateTime? DefenseStatusCheckAt { get => defenseStatusCheckAt; set => SetProperty(ref defenseStatusCheckAt, value); }

        public DocumentDisplayModel RawDefenseStatusCheckDocument { get => rawDefenseStatusCheckDocument; set => SetProperty(ref rawDefenseStatusCheckDocument, value); }

        public System.DateTime ResearchRequestAt { get => researchRequestAt; set => SetProperty(ref researchRequestAt, value); }

        public System.DateTime ResearchResultAt { get => researchResultAt; set => SetProperty(ref researchResultAt, value); }

        public DocumentDisplayModel RawResearchResultDocument { get => rawResearchResultDocument; set => SetProperty(ref rawResearchResultDocument, value); }

        public DocumentDisplayModel RawModelDocument { get => rawModelDocument; set => SetProperty(ref rawModelDocument, value); }
    }
}
