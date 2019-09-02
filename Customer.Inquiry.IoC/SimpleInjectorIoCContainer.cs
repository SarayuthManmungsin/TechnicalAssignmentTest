using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;

namespace Customer.Inquiry.IoC
{
    public class SimpleInjectorIoCContainer
    {
        private static Container _container;

        public static void Prepare()
        {
            _container = new Container();

            //_container.Register<IUserService, UserService>(Lifestyle.Transient);
            //_container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Singleton);

            _container.Verify();

            // store the container for use by the application
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(_container));
        }


    }
}
