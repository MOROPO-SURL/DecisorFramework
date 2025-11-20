using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.View;
using System.Linq;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Detail
{
    public class EmployeeDetailPageModel : Caney.MVVM.Core.Models.Page.BasePageModel
    {
        private int dailyCheckingMonth;

        private int dailyCheckingYear;

        public EmployeeDetailPageModel()
        {
            AvailableYears = new int[41];

            int index = 0;

            for (int i = 2020; i <= 2060; i++)
            {
                AvailableYears[index++] = i;
            }

            var now = System.DateTime.Now;

            dailyCheckingMonth = now.Month;
            dailyCheckingYear = now.Year;
        }

        public Domain.Interop.API.Common.Models.Display.EmployeeDisplayModel Domain { get; set; }

        public Core.Persistence.Entities.Contract.IYearIndexable[] EmploymentContracts { get; set; }

        public int DailyCheckingMonth { get => dailyCheckingMonth; set => SetProperty(ref dailyCheckingMonth, value); }

        public int DailyCheckingYear { get => dailyCheckingYear; set => SetProperty(ref dailyCheckingYear, value); }

        public System.Collections.ObjectModel.ObservableCollection<EmployeeDailyCheckingViewModel> DailyCheckings { get; set; } = [];

        public int[] AvailableMonths { get; private set; } = [1,2,3,4,5,6,7,8,9,10,11,12];

        public int[] AvailableYears { get; private set; }

        public async System.Threading.Tasks.Task FillDailyCheckingsAsync()
        {
            var apiConnectClient = new Interop.API.Connect.Clients.EmployeeDailyCheckingsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

            var models = await apiConnectClient.FilterAsync(new Interop.API.Common.Models.Filter.EmployeeDailyCheckingFilterModel { EmployeeId = Domain.Id, Year = DailyCheckingYear, Month = DailyCheckingMonth });

            var thisStartMonthDateTime = new System.DateTime(DailyCheckingYear, DailyCheckingMonth, 1);
            var nextStartMonthDateTime = thisStartMonthDateTime.AddMonths(1);
            var thisEndMonthDateTime = nextStartMonthDateTime.AddDays(-1);

            DailyCheckings.Clear();

            for (int i = 1; i <= thisEndMonthDateTime.Day; i++)
            {
                DailyCheckings.Add(new EmployeeDailyCheckingViewModel { Day = i, Model = models.FirstOrDefault(_model => _model.Day == i) });
            }
        }
    }
}
