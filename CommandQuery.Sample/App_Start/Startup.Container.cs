using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using AutoMapper.Mappers;
using Owin;
using CommandQuery.Core;
using CommandQuery.Sample.CQRS.MappingProfile.Blog;
using CommandQuery.Sample.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CommandQuery.Sample
{
    public partial class Startup
    {
        private static void ConfigureContainer(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            RegisterMvc(builder);
            RegisterEntityFramework(builder);
            RegisterCqrs(builder);
            RegisterAutomapper(builder);

            // Register dependencies, then...
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Register the Autofac middleware FIRST.
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }

        private static void RegisterMvc(ContainerBuilder builder)
        {
            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

        }

        private static void RegisterEntityFramework(ContainerBuilder builder)
        {
            builder.RegisterType<DataContext>()
                .As<IDataContext>()
                .InstancePerRequest();
        }

        private static void RegisterCqrs(ContainerBuilder builder)
        {
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>().AsImplementedInterfaces();
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>().AsImplementedInterfaces();

            var coreAssembly = typeof(Models.Blog).Assembly;
            builder.RegisterAssemblyTypes(coreAssembly).AsClosedTypesOf(typeof(IQueryHandlerAsync<,>)).InstancePerLifetimeScope().AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(coreAssembly).AsClosedTypesOf(typeof(IQueryHandler<,>)).InstancePerLifetimeScope().AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(coreAssembly).AsClosedTypesOf(typeof(ICommandHandlerAsync<>)).InstancePerLifetimeScope().AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(coreAssembly).AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerLifetimeScope().AsImplementedInterfaces();
        }

        private static void RegisterAutomapper(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BlogMappingProfile).Assembly)
                .Where(t => t.IsSubclassOf(typeof(Profile)))
                .As<Profile>();

            builder.Register(ctx => new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers))
               .AsImplementedInterfaces()
               .SingleInstance()
               .OnActivating(x =>
               {
                   foreach (var profile in x.Context.Resolve<IEnumerable<Profile>>())
                   {
                       x.Instance.AddProfile(profile);
                   }
               });

            builder.RegisterType<MappingEngine>()
                   .As<IMappingEngine>().SingleInstance();

        }
    }
}