using System.Web.Http;
using WebActivatorEx;
using Customer.Inquiry.Service;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Customer.Inquiry.Service
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                               .EnableSwagger(c => c.SingleApiVersion("v1", "Customer.Inquiry.Service"))
                               .EnableSwaggerUi();            
        }
    }
}
