﻿using System.Text.RegularExpressions;

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

        /// <summary>
        /// https://blog.uwinfo.com.tw/auth/article/reiko/378
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static object GetPropertyValue(object obj, string property)
        {
            System.Reflection.PropertyInfo propertyInfo = obj.GetType().GetProperty(property);
            return propertyInfo.GetValue(obj, null);
        }
    }
}
