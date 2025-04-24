using System.Linq;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class ObjectiveDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Objective, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Index { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public PersonDisplayModel Responsible { get; set; }

        public ProyectionDisplayModel[] Proyections { get; set; }

        public void Import(Persistence.Entities.Objective entity)
        {
            Id = entity.Id;
            Index = entity.Index;
            Name = entity.Name;
            Description = entity.Description;
            
            if (entity.Responsible != null)
            {
                Responsible = new PersonDisplayModel();

                Responsible.Import(entity.Responsible);
            }

            Proyections = entity.Proyections.OrderBy(_entity => _entity.Index).Select(_entity =>
            {
                var model = new ProyectionDisplayModel();

                model.Import(_entity);

                return model;
            }).ToArray();
        }
    }
}
