namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input
{
    public class BankBranchInputModel : Core.Interop.API.Common.Models.Input.Contract.AbstractNotificableEntityInputModel<Persistence.Entities.BankBranch, System.Guid>
    {
        public int Priority { get; set; }

        public System.Guid AgencyId { get; set; }

        public int Number { get; set; }

        public System.Guid? LocationMunicipalityId { get; set; }

        public string LocationAddress { get; set; }

        public int? LocationZipCode { get; set; }

        public decimal? LocationLongitude { get; set; }

        public decimal? LocationLatitude { get; set; }

        public override Persistence.Entities.BankBranch Export()
        {
            var entity = new Persistence.Entities.BankBranch { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public override void Mergue(Persistence.Entities.BankBranch entity)
        {
            entity.Priority = Priority;
            entity.Number = Number;

            if (entity.AgencyId != AgencyId)
            {
                entity.Agency = null;
                entity.AgencyId = AgencyId;
            }

            // TODO Handle location definition at controller
        }
    }
}
