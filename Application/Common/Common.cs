using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application
{
    public class Common
    {
        /// <summary>
        /// 檢查email格式
        /// </summary>
        /// <param name="txtemail"></param>
        /// <returns></returns>
        public static bool checkEmail(string emailInput)
        {
            string email = emailInput;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }
    }
}
