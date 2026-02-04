using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Collections.ObjectModel;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration
{
    public class VehicleConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<VehicleDisplayModel>
    {
        public static string BrandValidableProperty => nameof(Brand);
        public static string ModelValidableProperty => nameof(Model);
        public static string YearValidableProperty => nameof(Year);
        public static string KindValidableProperty => nameof(Kind);
        public static string TrafficCirculationIdentifierValidableProperty => nameof(TrafficCirculationIdentifier);
        public static string PlateValidableProperty => nameof(Plate);
        public static string EngineKindCirculationIdentifierValidableProperty => nameof(EngineKind);
        public static string EngineIdentifierCirculationIdentifierValidableProperty => nameof(EngineIdentifier);
        public static string BodyIdentifierCirculationIdentifierValidableProperty => nameof(BodyIdentifier);
        public static string SeatCountCirculationIdentifierValidableProperty => nameof(SeatCount);
        public static string StructureValidableProperty => nameof(Structure);
        public static string ReferenceValidableProperty => nameof(Reference);
        public static string OperativeLicenceCodeValidableProperty => nameof(OperativeLicenceCode);
        public static string TechnicalAvailabilityIndexValidableProperty => nameof(TechnicalAvailabilityIndex);

        private int priority = 1;
        private Microsoft.Maui.Controls.ImageSource fatureImageSource;
        private BrandDisplayModel brand;
        private string model;
        private int year;
        private VehicleKindDisplayModel kind;
        private string trafficCirculationIdentifier;
        private string plate;
        private VehicleEngineKindDisplayModel engineKind;
        private string engineIdentifier;
        private string bodyIdentifier;
        private int seatCount;
        private double loadCapacity;
        private StructureParentalDisplayModel structure;
        private string reference;
        private string operativeLicenceCode;
        private double technicalAvailabilityIndex = 100;
        private string description;

        public VehicleConfigurationPageModel(VehicleDisplayModel model) : base(model)
        {
            if (model != null)
            {
                Id = model.Id;
                priority = model.Priority;
                brand = model.Brand;
                this.model = model.Model;
                year = model.Year;
                kind = model.Kind;
                trafficCirculationIdentifier = model.TrafficCirculationIdentifier;
                plate = model.Plate;
                engineKind = model.EngineKind;
                engineIdentifier = model.EngineIdentifier;
                bodyIdentifier = model.BodyIdentifier;
                seatCount = model.SeatCount;
                loadCapacity = model.LoadCapacity;
                structure = model.Structure;
                reference = model.Reference;
                operativeLicenceCode = model.OperativeLicenceCode;
                technicalAvailabilityIndex = model.TechnicalAvailabilityIndex;
                description = model.Description;

                if (model.FeatureImage != null)
                {
                    FeatureImageId = model.FeatureImage.Id;
                    FeatureImageSource = model.FeatureImage.ToImageSource();
                }

                ItemImageSources = new ObservableCollection<Microsoft.Maui.Controls.ImageSource>(model.Images.Select(_model => _model.ToImageSource()));
                ItemImageModels = model.Images.ToList();
            }
        }

        public System.Guid Id { get; set; }

        public System.Guid? FeatureImageId { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }

        public BrandDisplayModel Brand { get => brand; set => SetProperty(ref brand, value); }

        public string Model { get => model; set => SetProperty(ref model, value); }

        public int Year { get => year; set => SetProperty(ref year, value); }

        public string TrafficCirculationIdentifier { get => trafficCirculationIdentifier; set => SetProperty(ref trafficCirculationIdentifier, value); }

        public string Plate { get => plate; set => SetProperty(ref plate, value); }

        public VehicleEngineKindDisplayModel EngineKind { get => engineKind; set => SetProperty(ref engineKind, value); }

        public string EngineIdentifier { get => engineIdentifier; set => SetProperty(ref engineIdentifier, value); }

        public string BodyIdentifier { get => bodyIdentifier; set => SetProperty(ref bodyIdentifier, value); }

        public int SeatCount { get => seatCount; set => SetProperty(ref seatCount, value); }

        public double LoadCapacity { get => loadCapacity; set => SetProperty(ref loadCapacity, value); }

        public Microsoft.Maui.Controls.ImageSource FeatureImageSource { get => fatureImageSource; set => SetProperty(ref fatureImageSource, value); }

        public VehicleKindDisplayModel Kind { get => kind; set => SetProperty(ref kind, value); }

        public StructureParentalDisplayModel Structure { get => structure; set => SetProperty(ref structure, value); }

        public string Reference { get => reference; set => SetProperty(ref reference, value); }

        public string OperativeLicenceCode { get => operativeLicenceCode; set => SetProperty(ref operativeLicenceCode, value); }

        public double TechnicalAvailabilityIndex { get => technicalAvailabilityIndex; set => SetProperty(ref technicalAvailabilityIndex, value); }

        public string Description { get => description; set => SetProperty(ref description, value); }

        public ObservableCollection<Microsoft.Maui.Controls.ImageSource> ItemImageSources { get; set; } = [];

        public System.Collections.Generic.List<Core.Interop.API.Common.Models.Display.ImageDisplayModel> ItemImageModels { get; set; }

        public BrandDisplayModel[] AvailableBrands { get; set; }

        public VehicleKindDisplayModel[] AvailableKinds { get; set; }

        public VehicleEngineKindDisplayModel[] AvailableEngineKinds { get; set; }

        public StructureParentalDisplayModel[] AvailableStructures { get; set; }
    }
}
