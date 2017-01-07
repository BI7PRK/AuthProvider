using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCF.AuthProvider.Service
{


    /// <summary>
    /// 提供WCF用户认证信息
    /// </summary>
    public class AuthHelper
    {
     
        
        private static Dictionary<string, IAuthUser> dict = new Dictionary<string, IAuthUser>();

        internal static string _NS { get; set; }
        /// <summary>
        /// 上线
        /// </summary>
        /// <param name="user"></param>
        /// <param name="ns"></param>
        public static void AddAuth(IAuthUser user, string ns= "http://www.bi7prk.com/")
        {
            if (dict.ContainsKey(user.UserName))
            {
                dict.Remove(user.UserName); //挤下线
            }
            dict.Add(user.UserName, user);
            _NS = ns;
        }

        /// <summary>
        /// 下线
        /// </summary>
        /// <param name="userName"></param>
        public static void Checkout(string userName)
        {
            if (dict.ContainsKey(userName))
            {
                dict.Remove(userName);
            }
        }

        /// <summary>
        /// 当前登陆的用户
        /// </summary>
        public static IAuthUser Current
        {
            get
            {
                var headers = OperationContext.Current.IncomingMessageHeaders;
                var userName = headers.GetHeader<string>("UserName", _NS);
                if (dict.ContainsKey(userName))
                {
                    return dict[userName];
                }
                return null;
            }
        }

        internal static bool Validate(string userName, string password)
        {
            if (dict.ContainsKey(userName))
            {
                return dict[userName].AuthKey.Equals(new Guid(password));
            }
            return false;
        }
    }
}