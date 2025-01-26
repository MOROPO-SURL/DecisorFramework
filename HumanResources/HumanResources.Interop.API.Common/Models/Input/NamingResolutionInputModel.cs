namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Input
{
    public class NamingResolutionInputModel : Legal.Interop.API.Common.Models.Input.Contract.AbstractResolutionInputModel<Persistence.Entities.NamingResolution>
    {
        public System.Guid NamedEmployeeId { get; set; }

        public override void Mergue(Persistence.Entities.NamingResolution entity)
        {
            base.Mergue(entity);

            if (entity.NamedEmployeeId != NamedEmployeeId)
            {
                entity.NamedEmployee = null;
                entity.NamedEmployeeId = NamedEmployeeId;
            }
        }
    }
}
