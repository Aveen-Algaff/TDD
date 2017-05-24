using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidationEngine
{
    public class Validator
    {
        //public string Mail = @"^([0-9a-zA-Z])*@([0-9a-zA-Z]).([0-9a-zA-Z])";
        public string Mail = @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";

        public bool ValidateEmailAddress(string valid)
        {
            if (string.IsNullOrEmpty(valid))
                throw new InvalidContentsException("You must specify an email address");
            var valide = Regex.IsMatch(valid, Mail);
            return valide;
        }
    }
}
