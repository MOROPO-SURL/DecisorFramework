using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.View
{
    public class ObjectiveViewModel
    {
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Interop.API.Common.Models.Display.PersonDisplayModel Responsible { get; set; }

        public Interop.API.Common.Models.Display.ObjectiveIndicatorDisplayModel[] Indicators { get; set; }

        public ProyectionViewModel[] Proyections { get; set; }

        public ObjectiveViewModel(Interop.API.Common.Models.Display.ObjectiveDisplayModel model)
        {
            Id = model.Id;
            Index = model.Index;
            Name = model.Name;
            Description = model.Description;
            Responsible = model.Responsible;
            Indicators = model.Indicators;

            Proyections = model.Proyections.Select(_model => new ProyectionViewModel(_model, model.Index)).ToArray();
        }
    }
}
