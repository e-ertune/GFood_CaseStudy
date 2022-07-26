using GFood_CaseStudy.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace GFood_CaseStudy.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }
            return ServiceTool.Generate(services);
        }
    }
}
