using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using System.Linq;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Common.Extensions;

public static class OrganizationalStructuringUnitExtensions
{
    public static OrganizationalStructuringUnitDisplayModel GetInteropChildren(this Persistence.Entities.OrganizationalStructuringUnit entity, Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.OrganizationalStructuringUnit, System.Guid> organizationalStructuringUnityRepository)
    {
        var result = new OrganizationalStructuringUnitDisplayModel();

        result.Import(entity);

        var children = organizationalStructuringUnityRepository.FindBy(_entity => _entity.ParentId == entity.Id).OrderBy(_entity => _entity.OrganizationalUnit.Priority).ToArray();

        var resultChildren = new System.Collections.Generic.List<OrganizationalStructuringUnitDisplayModel>();

        foreach (var child in children)
        {
            resultChildren.Add(child.GetInteropChildren(organizationalStructuringUnityRepository));
        }

        result.Children = [.. resultChildren];

        return result;
    }
}
