using Castle.DynamicProxy;
using GFood_CaseStudy.Core.CrossCuttingConcerns;
using GFood_CaseStudy.Core.Utilities.Interceptors;
using GFood_CaseStudy.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace GFood_CaseStudy.Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly int _duration;
        private readonly ICacheService _cacheService;

        public CacheAspect(int duration)
        {
            _duration = duration;
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = $"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}";
            var args = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", args.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheService.IsExists(key))
            {
                invocation.ReturnValue = _cacheService.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheService.Set(key, invocation.ReturnValue, _duration);
        }
    }
}
