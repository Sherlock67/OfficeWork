using System.Web.Mvc;
using TibFinanceDataAccess.Interface.Customers;
using TibFinanceDataAccess.Repository;
using Unity;
using Unity.Mvc5;

namespace TibFinanceDummy
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ICustomer, CustomerRepository>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}