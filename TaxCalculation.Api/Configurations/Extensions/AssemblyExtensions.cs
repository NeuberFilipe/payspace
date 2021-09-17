using System.Linq;
using System.Reflection;

namespace TaxCalculation.Api.Configurations.Extensions
{
    public static class AssemblyExtensions
    {
        public static string GetInformationalVersion(this Assembly assembly)
        {
            var assemblyFileVersionAttribute = (AssemblyInformationalVersionAttribute)assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), true).FirstOrDefault();

            return assemblyFileVersionAttribute?.InformationalVersion;
        }
    }
}
