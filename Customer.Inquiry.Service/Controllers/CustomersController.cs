using Customer.Inquiry.BusinessLogic.Interface;
using Customer.Inquiry.Domain.Implementation;
using Customer.Inquiry.Domain.Interface;
using Customer.Inquiry.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Customer.Inquiry.Service.Controllers
{
    // api/customers
    public class CustomersController : ApiControllerBase
    {
        private readonly ICustomerBusinessLogic _customerBusinessLogic;

        public CustomersController(ICustomerBusinessLogic customerBusinessLogic)
        {
            _customerBusinessLogic = customerBusinessLogic;
        }

        public async Task<HttpResponseMessage> Get()
        {
            IList<ICustomer> customers = await _customerBusinessLogic.GetList();
            return CreateResponse(customers.Select(x => new CustomerViewmodel(x)));
        }

        // POST api/customers
        public async Task<HttpResponseMessage> Post(InquiryCriteriaViewmodel inquiryCriteria)
        {
            if (inquiryCriteria.customerID <= 0 && string.IsNullOrEmpty(inquiryCriteria.email))
                return CreateResponse(HttpStatusCode.BadRequest, "No inquiry criteria");
            else
            {
                IInquiryCriteria criteria = inquiryCriteria.Convert();
                return CreateResponse("");
            }
        }

        // PUT api/customers/x
        public async Task<HttpResponseMessage> Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/customers/x
        public async void Delete(int id)
        {
        }
    }
}