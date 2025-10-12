
using MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Display
{
    public class CubanStandardDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.CubanStandard, int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Enable {  get; set; }

        public int Priority { get; set; }

        public void Import(CubanStandard entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Enable = entity.Enabled;
            Priority = entity.Priority;
        }
    }
}
