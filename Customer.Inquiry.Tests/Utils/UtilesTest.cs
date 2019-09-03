using Customer.Inquiry.Domain.Enum;
using Customer.Inquiry.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Customer.Inquiry.Tests.Utils
{
    [TestClass, TestCategory("unittest")]
    public class UtilesTest
    {

        [TestInitialize]
        public void Initialize()
        {
            // skeleton
        }

        [TestMethod]
        public void can_convert_to_timestamp()
        {
            DateTime testingDateTime = new DateTime(1970, 10, 1, 0, 0, 0);
            long timestamp = testingDateTime.ToUnixTimestamp();

            Assert.AreEqual(23587200, timestamp);
        }

        [TestMethod]
        public void can_convert_string_to_timestamp()
        {
            long timestamp = "03/09/2019 14:09".ToUnixTimestamp();

            Assert.AreEqual(1567519200, timestamp);
        }

        [TestMethod]
        public void can_convert_from_timestamp()
        {
            DateTime testingDateTime = new DateTime(1970, 1, 1, 0, 0, 0);
            long timestamp = testingDateTime.ToUnixTimestamp();

            Assert.AreEqual(0, timestamp);
        }

        [TestMethod]
        public void can_convert_from_enum()
        {
            Assert.AreEqual(TransactionStatus.Success, "Success".AsEnum<TransactionStatus>());
            Assert.AreEqual(TransactionStatus.Failed, "Failed".AsEnum<TransactionStatus>());
            Assert.AreEqual(TransactionStatus.Canceled, "Canceled".AsEnum<TransactionStatus>());
        }

        [TestMethod]
        public void can_validate_email()
        {
            Assert.IsTrue(Validator.IsValidEmail(string.Empty));
            Assert.IsTrue(Validator.IsValidEmail("user@domain.com"));
            Assert.IsFalse(Validator.IsValidEmail("user@domain.com 123456789123456789123"));
            Assert.IsFalse(Validator.IsValidEmail("abcdefghijklmn123456789123456789123"));
        }

        [TestMethod]
        public void can_validate_customerid()
        {
            Assert.IsTrue(Validator.IsValidCustomerId(123456789));
            Assert.IsTrue(Validator.IsValidCustomerId(null));
            Assert.IsFalse(Validator.IsValidCustomerId(12345678901));
        }
    }
}
