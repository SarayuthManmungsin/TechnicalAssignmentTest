using Customer.Inquiry.BusinessLogic.Interface;
using Customer.Inquiry.Domain.Enum;
using Customer.Inquiry.Domain.Implementation;
using Customer.Inquiry.Domain.Interface;
using Customer.Inquiry.IoC;
using Customer.Inquiry.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Customer.Inquiry.Tests.Integration
{
    // to be tricky, this should not be in 'order' state
    [TestClass, TestCategory("integration")]
    public class SetupDatabaseTest
    {
        private ICustomerBusinessLogic _customerBusinessLogic;
        private ITransactionBusinessLogic _transactionBusinessLogic;

        public SetupDatabaseTest()
        {
            ObjectFactory.Initialize(SimpleInjectorIoCContainer.Prepare(false));

            _customerBusinessLogic = ObjectFactory.GetInstance<ICustomerBusinessLogic>();
            _transactionBusinessLogic = ObjectFactory.GetInstance<ITransactionBusinessLogic>();
        }

        [TestMethod]
        public void _01_can_save_new_customer()
        {
            IInquiryCustomer customer = _customerBusinessLogic.GetCustomer(new InquiryCriteria { CustomerId = 1, Email = "user@domain.com" }).Result;
            if (customer == null)
            {
                customer = new InquiryCustomer
                {
                    Id = 1,
                    Name = "Firstname Lastname",
                    Email = "user@domain.com",
                    MobileNumber = "0123456789"
                };

                customer.Transactions.Add(CreateTransaction(1, 1234.56, "USD", TransactionStatus.Success));
                customer.Transactions.Add(CreateTransaction(1, 6543.21, "GBP", TransactionStatus.Canceled));
                customer.Transactions.Add(CreateTransaction(1, 1111.22, "USD", TransactionStatus.Failed));
                customer.Transactions.Add(CreateTransaction(1, 2222.23, "EUR", TransactionStatus.Success));
                customer.Transactions.Add(CreateTransaction(1, 3333.34, "THB", TransactionStatus.Canceled));
                customer.Transactions.Add(CreateTransaction(1, 7890.12, "USD", TransactionStatus.Failed));

                _customerBusinessLogic.Save(customer).Wait();
            }

            Assert.IsNotNull(customer);
            Assert.IsNotNull(customer.Transactions);
        }

        [TestMethod]
        public void _02_can_get_customer()
        {
            IInquiryCustomer customer = _customerBusinessLogic.GetCustomer(new InquiryCriteria { CustomerId = 1, Email = "user@domain.com" }).Result;
            Assert.IsNotNull(customer.Transactions);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void _03_cannot_save_invalid_customer_id()
        {
            // id mus not be exceeded than 10 digit
            _customerBusinessLogic.Save(new InquiryCustomer
            {
                Id = 12345678901,
                Name = "Firstname Lastname",
                Email = "user@domain.com",
                MobileNumber = "0123456789"
            }).Wait();
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void _04_cannot_save_invalid_customer_name()
        {
            // name must not be exceeded than 30 chars
            _customerBusinessLogic.Save(new InquiryCustomer
            {
                Id = 1,
                Name = "Firstname Lastname and i am curiously very long long long long long long long long",
                Email = "user@domain.com",
                MobileNumber = "0123456789"
            }).Wait();
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void _05_cannot_save_invalid_customer_email()
        {
            // email must be in a valid format
            _customerBusinessLogic.Save(new InquiryCustomer
            {
                Id = 1,
                Name = "Firstname Lastname",
                Email = "asdfghasdfghjasdfghjasdfghjasdfghj",
                MobileNumber = "0123456789"
            }).Wait();
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void _06_cannot_save_invalid_customer_mobile()
        {
            // mobile number must not be exceeded than 10 digit
            _customerBusinessLogic.Save(new InquiryCustomer
            {
                Id = 1,
                Name = "Firstname Lastname",
                Email = "user@domain.com",
                MobileNumber = "1234567890123456789"
            }).Wait();
        }

        private Transaction CreateTransaction(int transactionId, double amount, string currencyCode, TransactionStatus status)
        {
            return new Transaction
            {
                TransactionId = transactionId,
                Amount = amount,
                CurrencyCode = currencyCode,
                Status = status
            };
        }
    }
}
