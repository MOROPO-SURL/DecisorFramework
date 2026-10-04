namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Input
{
    public class CubanStandardInputModel : Framework.Decisor.Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.CubanStandard, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Index { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public override Persistence.Entities.CubanStandard Export()
        {
            var entity = new Persistence.Entities.CubanStandard { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.CubanStandard entity)
        {
            entity.Name = Name;
            entity.Index = Index;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
