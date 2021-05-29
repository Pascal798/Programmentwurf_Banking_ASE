using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3_Domain.Domain.Domain_Services
{
    public class CredentialsService
    {
        private static readonly string NAME_REGEX = "(?:[A-Z]|[a-z]|[0-9]|_){4,16}";

        private static readonly string EMAIL_REGEX =
            "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)])";

        private static readonly string PW_REGEX = "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,}$";

        public bool isNameValid(string name)
        {
            Match match = Regex.Match(name, NAME_REGEX);

            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool isEmailValid(string email)
        {
            Match match = Regex.Match(email, EMAIL_REGEX);

            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool isPasswordValid(string password)
        {
            Match match = Regex.Match(password, PW_REGEX);

            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool credentialsAreValid(string name, string email, string password)
        {
            return isNameValid(name) && isEmailValid(email) && isPasswordValid(password);
        }

        public bool credentialsAreValidOrNull(string name, string email, string password)
        {
            return (name == null || isNameValid(name)) && (email == null || isEmailValid(email)) && (password == null || isPasswordValid(password));
        }
    }
}
