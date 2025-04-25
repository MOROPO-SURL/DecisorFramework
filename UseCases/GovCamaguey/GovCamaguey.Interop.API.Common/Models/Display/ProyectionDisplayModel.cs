using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class ProyectionDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Proyection, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Index { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ActionDisplayModel[] Actions { get; set; }

        public void Import(Persistence.Entities.Proyection entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Index = entity.Index;
            Name = entity.Name;
            Description = entity.Description;

            Actions = entity.Actions.OrderBy(_entity => _entity.Index).Select(_entity =>
            {
                var model = new ActionDisplayModel();

                model.Import(_entity);

                return model;
            }).ToArray();
        }
    }
}
