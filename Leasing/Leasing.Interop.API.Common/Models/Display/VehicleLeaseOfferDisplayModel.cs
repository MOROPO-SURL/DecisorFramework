using System.Linq;

namespace MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display
{
    public class VehicleLeaseOfferDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.VehicleLeaseOffer, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public System.DateTime? OpenAt { get; set; }

        public System.DateTime? ClosedAt { get; set; }

        public string Description { get; set; }

        public HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel Author { get; set; }

        public HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel Decisor { get; set; }

        public string ApprovationReference { get; set; }

        public Domain.Interop.API.Common.Models.Display.VehicleDisplayModel Vehicle { get; set; }

        public CommonLeaseOrganizationPostulationDisplayModel[] OrganizationPostulations { get; set; }

        public CommonLeasePersonPostulationDisplayModel[] PersonPostulations { get; set; }

        public void Import(Persistence.Entities.VehicleLeaseOffer entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            At = entity.At;
            OpenAt = entity.OpenAt;
            ClosedAt = entity.ClosedAt;
            Description = entity.Description;
            OrganizationPostulations = entity.OrganizationPostulations.Select(bridge =>
            {
                var result = new CommonLeaseOrganizationPostulationDisplayModel
                {
                    TaxIdentificationNumber = bridge.TaxIdentificationNumber,
                    StateIdentificationCode = bridge.StateIdentificationCode,
                    Argument = bridge.Argument
                };

                if (bridge.Contact != null)
                {
                    result.Contact = new Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel();

                    result.Contact.Import(bridge.Contact);
                }

                return result;
            }).ToArray();
            PersonPostulations = entity.PersonPostulations.Select(bridge =>
            {
                var result = new CommonLeasePersonPostulationDisplayModel
                {
                    TaxIdentificationNumber = bridge.TaxIdentificationNumber,
                    Argument = bridge.Argument
                };

                if (bridge.Contact != null)
                {
                    result.Contact = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                    result.Contact.Import(bridge.Contact);
                }

                if (bridge.BusinessKind != null)
                {
                    result.BusinessKind = new Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel();

                    result.BusinessKind.Import(bridge.BusinessKind);
                }

                return result;
            }).ToArray();
            ApprovationReference = entity.ApprovationReference;

            if (entity.Author != null)
            {
                Author = new HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                Author.Import(entity.Author);
            }

            if (entity.Decisor != null)
            {
                Decisor = new HumanResources.Interop.API.Common.Models.Display.EmployeeDisplayModel();

                Decisor.Import(entity.Decisor);
            }

            if (entity.Vehicle != null)
            {
                Vehicle = new Domain.Interop.API.Common.Models.Display.VehicleDisplayModel();

                Vehicle.Import(entity.Vehicle);
            }
        }
    }
}
