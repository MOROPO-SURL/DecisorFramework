namespace MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display
{
    public class OrganizationalStructuringUnitDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.OrganizationalStructuringUnit, System.Guid>
    {
        public System.Guid Id { get; set; }

        public OrganizationalUnitDisplayModel OrganizationalUnit { get; set; }

        public string Reference { get; set; }

        public OrganizationalStructuringUnitDisplayModel[] Children { get; set; }

        public void Import(Persistence.Entities.OrganizationalStructuringUnit entity)
        {
            Id = entity.Id;
            Reference = entity.Reference;

            if (entity.OrganizationalUnit != null)
            {
                OrganizationalUnit = new OrganizationalUnitDisplayModel();

                OrganizationalUnit.Import(entity.OrganizationalUnit);
            }
        }
    }
}
