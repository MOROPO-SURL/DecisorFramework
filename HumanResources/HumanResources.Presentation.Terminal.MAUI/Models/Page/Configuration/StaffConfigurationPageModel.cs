using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class StaffConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.StaffDisplayModel>
    {
        public static string AdministrativeEntityValidableProperty => nameof(AdministrativeEntity);
        public static string MainWorkforceValidableProperty => nameof(MainWorkforce);
        public static string WorkingWeekHourCountValidableProperty => nameof(WorkingWeekHourCount);

        private Domain.Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel administrativeEntity;
        private Interop.API.Common.Models.Display.WorkforceDisplayModel mainWorkforce;
        private int workingWeekHourCount = 44;
        private float doctorateExtraFeed;
        private float masteryExtraFeed;

        public StaffConfigurationPageModel(Interop.API.Common.Models.Display.StaffDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                administrativeEntity = model.AdministrativeEntity;
                mainWorkforce = model.MainWorkforce;
                workingWeekHourCount = model.WorkingWeekHourCount;
                masteryExtraFeed = model.MasteryExtraFeed;
                doctorateExtraFeed = model.DoctorateExtraFeed;
                AlternativeWorkforceBridges = new System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Bridge.AlternativeWorkforceBridgeModel>(model.AlternativeWorkforces);
            }
        }

        public System.Guid Id { get; set; }

        public Domain.Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel AdministrativeEntity { get => administrativeEntity; set => SetProperty(ref administrativeEntity, value); }

        public Interop.API.Common.Models.Display.WorkforceDisplayModel MainWorkforce { get => mainWorkforce; set => SetProperty(ref mainWorkforce, value); }

        public int WorkingWeekHourCount { get => workingWeekHourCount; set => SetProperty(ref workingWeekHourCount, value); }

        public float DoctorateExtraFeed { get => doctorateExtraFeed; set => SetProperty(ref doctorateExtraFeed, value); }

        public float MasteryExtraFeed { get => masteryExtraFeed; set => SetProperty(ref masteryExtraFeed, value); }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Bridge.AlternativeWorkforceBridgeModel> AlternativeWorkforceBridges { get; set; } = [];

        public Domain.Interop.API.Common.Models.Display.AdministrativeEntityParentalDisplayModel[] AvailableAdministrativeEntities { get; set; }

        public System.Collections.ObjectModel.ObservableCollection<Interop.API.Common.Models.Display.WorkforceDisplayModel> AvailableWorkforces { get; set; } = [];
    }
}