using System.Linq;

namespace MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display
{
    public class ProformaDisplayModel : Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Proforma, System.Guid>
    {
        public System.Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public System.DateTime CreatedAt { get; set; }

        public System.DateTime EditedAt { get; set; }

        public Bridge.ProformaSectionClauseBridgeModel[] Sections { get; set; }

        public Core.Interop.API.Common.Models.Display.DocumentDisplayModel RawDocument { get; set; }

        public void Import(Persistence.Entities.Proforma entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            CreatedAt = entity.CreatedAt;
            EditedAt = entity.EditedAt;

            if (entity.RawDocument != null)
            {
                RawDocument = new Core.Interop.API.Common.Models.Display.DocumentDisplayModel();

                RawDocument.Import(entity.RawDocument);
            }

            var groups = entity.ClauseBridges.OrderBy(bridge => bridge.Section.Priority).GroupBy(bridge => bridge.Section).ToList();

            var sectionList = new System.Collections.Generic.List<Bridge.ProformaSectionClauseBridgeModel>();

            foreach (var group in groups)
            {
                var section = new SectionDisplayModel();

                section.Import(group.Key);

                var item = new Bridge.ProformaSectionClauseBridgeModel
                {
                    Section = section,
                    Clauses = group.Select(bridge =>
                    {
                        var clause = new ClauseDisplayModel();

                        clause.Import(bridge.Stern);

                        return clause;
                    }).ToArray()
                };

                sectionList.Add(item);
            }

            Sections = sectionList.ToArray();
        }
    }
}
