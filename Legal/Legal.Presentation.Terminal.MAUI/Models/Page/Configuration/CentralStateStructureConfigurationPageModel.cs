using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Extensions;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.Models.Page.Configuration;

public class CentralStateStructureConfigurationPageModel : Core.Presentation.Terminal.MAUI.Models.Page.Contract.AbstractConfigurationPageModel<Interop.API.Common.Models.Display.CentralStateStructureDisplayModel>
{
    private string name;
    private string about;
    private int priority = 1;
    private bool isSettedBornDate;
    private System.DateTime? bornDate;
    private Microsoft.Maui.Controls.ImageSource imageSource;

    public CentralStateStructureConfigurationPageModel(Interop.API.Common.Models.Display.CentralStateStructureDisplayModel model) : base(model)
    {
        if (model != null)
        {
            Id = model.Id;
            Name = model.Identity.Name;
            About = model.Identity.About;
            Priority = model.Priority;
            isSettedBornDate = model.Identity.BornDate != null;
            BornDate = model.Identity.BornDate;

            if (model.Identity.Image != null)
            {
                ImageId = model.Identity.Image.Id;
                ImageSource = model.Identity.Image.ToImageSource();
            }
        }
    }

    public System.Guid Id { get; set; }

    public System.Guid? ImageId { get; set; }

    public string Name { get => name; set => SetProperty(ref name, value); }

    public string About { get => about; set => SetProperty(ref about, value); }

    public int Priority { get => priority; set => SetProperty(ref priority, value); }

    public bool IsSettedBornDate { get => isSettedBornDate; set => SetProperty(ref isSettedBornDate, value); }

    public System.DateTime? BornDate { get => bornDate; set => SetProperty(ref bornDate, value); }

    public Microsoft.Maui.Controls.ImageSource ImageSource { get => imageSource; set => SetProperty(ref imageSource, value); }
}
