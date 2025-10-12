
using MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities;

namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Input
{
    public class CubanStandardInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.CubanStandard, int>
    {
        public int Id { get; set ; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public Persistence.Entities.CubanStandard Export()
        {
            var entity = new Persistence.Entities.CubanStandard { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.CubanStandard entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.CubanStandard entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
