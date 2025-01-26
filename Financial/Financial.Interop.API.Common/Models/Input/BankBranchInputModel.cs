namespace MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Input
{
    public class BankBranchInputModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Persistence.Entities.BankBranch, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Priority { get; set; }

        public System.Guid AgencyId { get; set; }

        public int Number { get; set; }

        public System.Guid? LocationMunicipalityId { get; set; }

        public string LocationAddress { get; set; }

        public int? LocationZipCode { get; set; }

        public decimal? LocationLongitude { get; set; }

        public decimal? LocationLatitude { get; set; }

        public Persistence.Entities.BankBranch Export()
        {
            var entity = new Persistence.Entities.BankBranch { Id = Id, Enabled = true };

            Mergue(entity);

            return entity;
        }

        public void Import(Persistence.Entities.BankBranch entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(Persistence.Entities.BankBranch entity)
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
