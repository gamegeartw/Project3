using Furion;
using System.Reflection;

namespace Project3.Web.Entry
{
    public class SingleFilePublish : ISingleFilePublish
    {
        public Assembly[] IncludeAssemblies()
        {
            return Array.Empty<Assembly>();
        }

        public string[] IncludeAssemblyNames()
        {
            return new[]
            {
            "Project3.Application",
            "Project3.Core",
            "Project3.EntityFramework.Core",
            "Project3.Web.Core"
        };
        }
    }
}