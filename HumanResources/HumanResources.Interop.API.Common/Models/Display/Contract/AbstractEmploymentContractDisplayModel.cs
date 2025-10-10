namespace MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display.Contract
{
    public abstract class AbstractEmploymentContractDisplayModel<TEntity> : Legal.Interop.API.Common.Models.Display.Contract.AbstractContractDisplayModel<TEntity>
        where TEntity : Persistence.Entities.Contract.AbstractEmploymentContract
    {
        public StaffDisplayModel Staff { get; set; }

        public WorkforceOrganizationalUnityDisplayModel WorkforceOrganizationalUnity { get; set; }

        public VacantDisplayModel Vacant { get; set; }

        public override void Import(TEntity entity)
        {
            base.Import(entity);

            if (entity.Staff != null)
            {
                Staff = new StaffDisplayModel();

                Staff.Import(entity.Staff);
            }

            if (entity.Vacant != null)
            {
                Vacant = new VacantDisplayModel();

                Vacant.Import(entity.Vacant);

                if (entity.Vacant.WorkforceOrganizationalUnity != null)
                {
                    WorkforceOrganizationalUnity = new WorkforceOrganizationalUnityDisplayModel();

                    WorkforceOrganizationalUnity.Import(entity.Vacant.WorkforceOrganizationalUnity);
                }
            }
        }
    }
}
