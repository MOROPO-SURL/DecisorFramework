using MOROPO.Framework.Guama.Core.Persistence.Entities.Contract;

namespace MOROPO.Framework.Decisor.Core.Persistence.Entities.Contract
{
	public interface IFullFeatureEntity<T> : IArchivableEntity<T>, IEnableableEntity<T>, IPriorizableEntity<T>
    {
	}
}

