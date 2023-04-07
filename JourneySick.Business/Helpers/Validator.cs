using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JourneySick.Business.Helpers
{
    public static class Validator
    {
        private static readonly Regex regexMail = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        private static readonly Regex regexPhone1 = new(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
        private static readonly Regex regexPhone2 = new(@"(1[8|9]00)+([0-9]{4})");
        private static readonly Regex regexPhone3 = new(@"(02)+([0-9]{9})");
        private static readonly Regex regexDate = new(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");
        private static readonly Regex regexDateHours = new(@"^([1-9]|([012][0-9])|(3[01]))/([0]{0,1}[1-9]|1[012])/\d\d\d\d (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$"); //[dd/MM/yyyy HH:mm:ss]
        private static readonly Regex regexUUID = new(@"(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$");

        public static async Task<bool> EmailValidate(string email)
        {
            bool result;
            try
            {
                Match match = regexMail.Match(email);
                result = email.Length != 0 && match.Success;
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static async Task<bool> DateValidator(string date)
        {
            bool result;
            try
            {
                Match match = regexDate.Match(date);
                result = (date.Length == 0) ? false : match.Success;
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public static async Task<bool> PhoneNumberValidator(string phoneNum)
        {
            try
            {
                Match match1 = regexPhone1.Match(phoneNum);
                Match match2 = regexPhone2.Match(phoneNum);
                Match match3 = regexPhone3.Match(phoneNum);
                bool isMatched = false;
                if (match1.Success)
                    isMatched = match1.Success;
                else if (match2.Success)
                    isMatched = match2.Success;
                else if (match3.Success)
                    isMatched = match3.Success;

                return (phoneNum.Length == 0) ? false : isMatched;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

/*        public static async dynamic ValidateObject(dynamic obj)
        {
            try
            {
                if(obj.)
            }catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }*/

    }
}
