using System.Linq;

namespace MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display
{
    public class PropertyLeaseOfferDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.PropertyLeaseOffer, System.Guid>
    {
        public System.Guid Id { get; set; }

        public bool Enabled { get; set; }

        public int Priority { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        public System.DateTime OpenAt { get; set; }

        public System.DateTime? ClosedAt { get; set; }

        public string Description { get; set; }

        public Domain.Interop.API.Common.Models.Display.PropertyDisplayModel Property { get; set; }

        public Bridge.CommonLeaseOfferOrganizationContactBridgeDisplayModel[] OrganizationContactBridges { get; set; }

        public Bridge.CommonLeaseOfferPersonContactBridgeDisplayModel[] PersonContactBridges { get; set; }

        public void Import(Persistence.Entities.PropertyLeaseOffer entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Priority = entity.Priority;
            At = entity.At;
            OpenAt = entity.OpenAt;
            ClosedAt = entity.ClosedAt;
            Description = entity.Description;
            OrganizationContactBridges = entity.OrganizationContactBridges.Select(bridge =>
            {
                var result = new Bridge.CommonLeaseOfferOrganizationContactBridgeDisplayModel
                {
                    TaxIdentificationNumber = bridge.TaxIdentificationNumber,
                    StateIdentificationCode = bridge.StateIdentificationCode,
                    Argument = bridge.Argument
                };

                if (bridge.CredentialDocument != null)
                {
                    result.CredentialDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                    result.CredentialDocument.Import(bridge.CredentialDocument);
                }

                if (bridge.Stern != null)
                {
                    result.Contact = new Domain.Interop.API.Common.Models.Display.OrganizationContactDisplayModel();

                    result.Contact.Import(bridge.Stern);
                }

                return result;
            }).ToArray();
            PersonContactBridges = entity.PersonContactBridges.Select(bridge =>
            {
                var result = new Bridge.CommonLeaseOfferPersonContactBridgeDisplayModel
                {
                    TaxIdentificationNumber = bridge.TaxIdentificationNumber,
                    Argument = bridge.Argument
                };

                if (bridge.CredentialDocument != null)
                {
                    result.CredentialDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                    result.CredentialDocument.Import(bridge.CredentialDocument);
                }

                if (bridge.Stern != null)
                {
                    result.Contact = new Domain.Interop.API.Common.Models.Display.PersonContactDisplayModel();

                    result.Contact.Import(bridge.Stern);
                }

                if (bridge.BusinessKind != null)
                {
                    result.BusinessKind = new Domain.Interop.API.Common.Models.Display.NaturalBusinessKindDisplayModel();

                    result.BusinessKind.Import(bridge.BusinessKind);
                }

                return result;
            }).ToArray();

            if (entity.Property != null)
            {
                Property = new Domain.Interop.API.Common.Models.Display.PropertyDisplayModel();

                Property.Import(entity.Property);
            }
        }
    }
}
