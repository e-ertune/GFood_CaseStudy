using Microsoft.Extensions.DependencyInjection;

namespace GFood_CaseStudy.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
