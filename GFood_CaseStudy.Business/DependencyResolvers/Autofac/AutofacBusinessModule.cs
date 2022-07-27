using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using GFood_CaseStudy.Business.Abstract;
using GFood_CaseStudy.Business.Concrete;
using GFood_CaseStudy.Core.Utilities.Interceptors;
using GFood_CaseStudy.DataAccess.Abstract;
using GFood_CaseStudy.DataAccess.Concrete.EntityFramework;
using Assembly = System.Reflection.Assembly;
using Module = Autofac.Module;

namespace GFood_CaseStudy.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(global::Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<ProductManager>().As<IProductService>();

            builder.RegisterType<EfBasketDal>().As<IBasketDal>();
            builder.RegisterType<BasketManager>().As<IBasketService>();

            builder.RegisterType<EfBasketProductDal>().As<IBasketProductDal>();
            builder.RegisterType<BasketProductManager>().As<IBasketProductService>();

            builder.RegisterType<EfCampaignDal>().As<ICampaignDal>();
            builder.RegisterType<CampaignManager>().As<ICampaignService>();

            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();

            builder.RegisterType<EfProductCategoryDal>().As<IProductCategoryDal>();
            builder.RegisterType<ProductCategoryManager>().As<IProductCategoryService>();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            });
        }
    }
}
