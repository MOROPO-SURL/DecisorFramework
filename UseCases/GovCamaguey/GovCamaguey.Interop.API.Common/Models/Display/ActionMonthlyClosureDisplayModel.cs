namespace MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display
{
    public class ActionMonthlyClosureDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.ActionMonthlyClosure, System.Guid>
    {
        public System.Guid Id { get; set; }

        public System.DateTime At { get; set; }

        public void Import(Persistence.Entities.ActionMonthlyClosure entity)
        {
            Id = entity.Id;
            At = entity.At;
        }
    }
}
