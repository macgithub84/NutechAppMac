using Nutech.Workout.Mac.Data.Repositories;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Unity;
using Unity.Injection;
using Unity.RegistrationByConvention;
using Unity.WebApi;

namespace Nutech.Workout.Mac.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            
            container.RegisterTypes(
                      AllClasses.FromLoadedAssemblies(),
                      WithMappings.FromMatchingInterface,
                      WithName.Default);
            // container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType(
                    typeof(IRepository<>),
                    typeof(Repository<>),
                    new InjectionConstructor());
            container.RegisterInstance<IHttpControllerActivator>(new UnityHttpControllerActivator(container));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}