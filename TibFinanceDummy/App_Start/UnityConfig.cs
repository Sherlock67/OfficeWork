using System.Data.Entity;
using System.Web.Mvc;
using TibFinanceBusinessLayer.IService.ILoginService;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace TibFinanceDummy
{
    public static class UnityConfig
    {
        public static UnityContainer RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<DbContext>(new HierarchicalLifetimeManager());
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            //container.RegisterType<ICustomer, CustomerRepository>();
            //container.RegisterType<ILogin, LoginRepository>();
            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<CustomerController>(new InjectionConstructor());
            //RegisterTypes(container);
           // container.RegisterType<ILoginService,LoginServices>();
            //container.RegisterType<ILogin, LoginRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
    }
}