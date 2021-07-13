using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using CAFEMENU.Business.Abstract;
using CAFEMENU.Business.Automapper;
using CAFEMENU.Business.Concrete;
using CAFEMENU.Business.Concrete.Abstract;
using CAFEMENU.Core.Mapping.Automapper;
using CAFEMENU.Core.Utilities.Interceptors;
using CAFEMENU.DataAccess.Abstract;
using CAFEMENU.DataAccess.Concrate;
using CAFEMENU.MessageBroker.RabbitMq.Abstract;
using CAFEMENU.MessageBroker.RabbitMq.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<RabbitMqMessageBroker>().As<IMessageBroker>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductProfile>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }

    }
}
