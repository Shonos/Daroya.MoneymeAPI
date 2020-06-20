using System;
using System.Text.RegularExpressions;

namespace Daroya.MoneymeAPI.Models.Models.Requests.Validators
{
    public static class ValidatorUtils
    {
        public static bool IsValidMobileNumber(string Phone)
        {
            try
            {
                if (string.IsNullOrEmpty(Phone))
                    return false;
                var r = new Regex(@"^[0-9]+$");
                return r.IsMatch(Phone);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
