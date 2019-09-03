namespace Customer.Inquiry.Utils
{
    public class Validator
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && IsInRange(addr.Address, 25);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidCustomerId(int? customerId)
        {
            if (!customerId.HasValue)
                return true;

            return IsInRange(customerId.Value, 10);
        }

        public static bool IsInRange(int input, int range)
        {
            return IsInRange(input.ToString(), range);
        }

        public static bool IsInRange(string input, int range)
        {
            return input.Length > range;
        }
    }
}
