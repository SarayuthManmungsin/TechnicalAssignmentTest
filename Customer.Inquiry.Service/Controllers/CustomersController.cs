using Customer.Inquiry.BusinessLogic.Interface;
using Customer.Inquiry.Domain.Interface;
using Customer.Inquiry.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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

        // GET api/customers
        public async Task<HttpResponseMessage> Get()
        {
            IList<IInquiryCustomer> customers = await _customerBusinessLogic.GetList();
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
                await _customerBusinessLogic.GetCustomer(criteria);
                return CreateResponse("");
            }
        }

        // PUT api/customers/x
        public async Task<HttpResponseMessage> Put(InquiryCriteriaViewmodel inquiryCriteria)
        {
            IInquiryCriteria criteria = inquiryCriteria.Convert();
            IInquiryCustomer customer = await _customerBusinessLogic.GetCustomer(criteria);
            return CreateResponse(HttpStatusCode.OK,"");
        }

        // DELETE api/customers/x
        public async Task<HttpResponseMessage> Delete(InquiryCriteriaViewmodel inquiryCriteria)
        {
            IInquiryCriteria criteria = inquiryCriteria.Convert();
            IInquiryCustomer customer = await _customerBusinessLogic.GetCustomer(criteria);
            _customerBusinessLogic.Delete(customer.Id);

            return CreateResponse(HttpStatusCode.NotFound, "");
        }
    }
}