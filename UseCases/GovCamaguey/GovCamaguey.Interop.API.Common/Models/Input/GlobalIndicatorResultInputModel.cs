namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class GlobalIndicatorResultInputModel : Contract.AbstractIndicatorResultInputModel<Persistence.Entities.GlobalIndicatorResult>
    {
        public override Persistence.Entities.GlobalIndicatorResult Export()
        {
            var entity = new Persistence.Entities.GlobalIndicatorResult { Id = Id };

            Mergue(entity);

            return entity;
        }
    }
}
