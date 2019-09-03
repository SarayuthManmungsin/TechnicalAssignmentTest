using Customer.Inquiry.BusinessLogic.Implementation;
using Customer.Inquiry.BusinessLogic.Interface;
using Customer.Inquiry.Repository.Implementation;
using Customer.Inquiry.Repository.Interface;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System;
using System.Web.Http;
using System.Web.Mvc;

namespace Customer.Inquiry.IoC
{
    public class SimpleInjectorIoCContainer
    {
        private static Container _container;

        public static Func<Container> Prepare(HttpConfiguration config)
        {
            _container = new Container();

            _container.Register<ICustomerBusinessLogic, CustomerBusinessLogic>(Lifestyle.Transient);
            _container.Register<ICustomerRepository, CustomerRepository>(Lifestyle.Transient);

            _container.Register<ITransactionBusinessLogic, TransactionBusinessLogic>(Lifestyle.Transient);
            _container.Register<ITransactionRepository, TransactionRepository>(Lifestyle.Transient);

            _container.RegisterWebApiControllers(config);

            _container.Verify();

            // store the container for use by the application
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(_container);

            return InitContainer;
        }

        private static Container InitContainer()
        {
            return _container;
        }
    }
}
