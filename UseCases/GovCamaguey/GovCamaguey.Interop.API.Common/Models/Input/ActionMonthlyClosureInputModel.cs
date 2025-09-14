namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Input
{
    public class ActionMonthlyClosureInputModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.ActionMonthlyClosure, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public Persistence.Entities.ActionMonthlyClosure Export()
        {
            var entity = new Persistence.Entities.ActionMonthlyClosure { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.ActionMonthlyClosure entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.ActionMonthlyClosure entity)
        {
            entity.At = At;
        }
    }
}
