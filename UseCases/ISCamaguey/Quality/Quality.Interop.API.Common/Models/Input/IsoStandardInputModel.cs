namespace MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Input
{
    public class IsoStandardInputModel : Framework.Decisor.Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.IsoStandard, System.Guid>
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public int Index { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        public override Persistence.Entities.IsoStandard Export()
        {
            var entity = new Persistence.Entities.IsoStandard { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.IsoStandard entity)
        {
            entity.Name = Name;
            entity.Index = Index;
            entity.Description = Description;
            entity.Priority = Priority;
        }
    }
}
