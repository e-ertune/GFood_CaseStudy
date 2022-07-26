using Castle.DynamicProxy;
using GFood_CaseStudy.Core.CrossCuttingConcerns;
using GFood_CaseStudy.Core.Utilities.Interceptors;
using GFood_CaseStudy.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace GFood_CaseStudy.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private readonly string _pattern;
        private readonly ICacheService _cacheService;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheService.RemoveByPattern(_pattern);
        }
    }
}
