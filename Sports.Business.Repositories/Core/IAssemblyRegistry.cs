using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Business.Repositories.Core
{
   public interface IAssemblyRegistry
    {
        IEnumerable<Assembly> Assemblies { get; }
        IEnumerable<ManifestResourceInfo> EmbeddedResources { get; }
        IEnumerable<Type> ExportedTypes { get; }
        IEnumerable<Type> ConcreteTypes { get; }
        IEnumerable<Type> GetConcreteTypesDerivingFrom(Type baseType);
    }
}
