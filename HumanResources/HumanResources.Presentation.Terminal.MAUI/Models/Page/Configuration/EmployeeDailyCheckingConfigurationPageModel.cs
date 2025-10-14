namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class EmployeeDailyCheckingConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.EmployeeDailyCheckingDisplayModel>
    {
        private System.TimeSpan checkIn;
        private bool isPartialCheckOutSet;
        private System.TimeSpan? partialCheckOut;
        private bool isPartialCheckInSet;
        private System.TimeSpan? partialCheckIn;
        private bool isCheckOutSet;
        private System.TimeSpan? checkOut;
        private bool isExtraCheckInSet;
        private System.TimeSpan? extraCheckIn;
        private bool isExtraCheckOutSet;
        private System.TimeSpan? extraCheckOut;

        public EmployeeDailyCheckingConfigurationPageModel(System.Guid employeeId, Interop.API.Common.Models.Display.EmployeeDailyCheckingDisplayModel model) : base(model)
        {
            EmployeeId = employeeId;
            Id = model.Id;
            At = new System.DateTime(model.Year, model.Month, model.Day);
            checkIn = model.CheckIn;
            isPartialCheckOutSet = model.PartialCheckOut != null;
            partialCheckOut = model.PartialCheckOut;
            isPartialCheckInSet = model.PartialCheckIn != null;
            partialCheckIn = model.PartialCheckIn;
            isCheckOutSet = model.CheckOut != null;
            checkOut = model.CheckOut;
            isExtraCheckInSet = model.ExtraCheckIn != null;
            extraCheckIn = model.ExtraCheckIn;
            isExtraCheckOutSet = model.ExtraCheckOut != null;
            extraCheckOut = model.ExtraCheckOut;
        }

        public EmployeeDailyCheckingConfigurationPageModel(System.Guid employeeId, int day, int month, int year) : base(null)
        {
            EmployeeId = employeeId;
            At = new System.DateTime(year, month, day);
        }

        public long Id { get; set; }

        public System.Guid EmployeeId { get; set; }

        public System.DateTime At { get; set; }

        public System.TimeSpan CheckIn { get => checkIn; set => SetProperty(ref checkIn, value); }

        public bool IsPartialCheckOutSet { get => isPartialCheckOutSet; set => SetProperty(ref isPartialCheckOutSet, value); }

        public System.TimeSpan? PartialCheckOut { get => partialCheckOut; set => SetProperty(ref partialCheckOut, value); }

        public bool IsPartialCheckInSet { get => isPartialCheckInSet; set => SetProperty(ref isPartialCheckInSet, value); }

        public System.TimeSpan? PartialCheckIn { get => partialCheckIn; set => SetProperty(ref partialCheckIn, value); }

        public bool IsCheckOutSet { get => isCheckOutSet; set => SetProperty(ref isCheckOutSet, value); }

        public System.TimeSpan? CheckOut { get => checkOut; set => SetProperty(ref checkOut, value); }

        public bool IsExtraCheckInSet { get => isExtraCheckInSet; set => SetProperty(ref isExtraCheckInSet, value); }

        public System.TimeSpan? ExtraCheckIn { get => extraCheckIn; set => SetProperty(ref extraCheckIn, value); }

        public bool IsExtraCheckOutSet { get => isExtraCheckOutSet; set => SetProperty(ref isExtraCheckOutSet, value); }

        public System.TimeSpan? ExtraCheckOut { get => extraCheckOut; set => SetProperty(ref extraCheckOut, value); }
    }
}
