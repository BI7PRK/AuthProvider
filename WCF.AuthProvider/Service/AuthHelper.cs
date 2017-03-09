using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;

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
                
                if (dict == null)
                {
                    throw new FaultException("用户登陆失效");
                }
                try
                {
                    var headers = OperationContext.Current.IncomingMessageHeaders;
                    var userName = headers.GetHeader<string>("UserName", _NS);
                    if (string.IsNullOrEmpty(userName))
                    {
                        throw new FaultException("未提交用户名");
                    }
                    if (dict.ContainsKey(userName))
                    {
                        return dict[userName];
                    }
                }
                catch
                {
                    throw new FaultException("用户登陆失效");
                }
                return null;
            }
        }
        /// <summary>
        /// 用户是否在线
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool Any(string userName)
        {
            return dict != null && dict.ContainsKey(userName);
        }


        /// <summary>
        /// 用户是否在线
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool Any(int userId)
        {
            return dict != null && dict.Select(s => s.Value).Any(w => w.UserId == userId);
        }


        internal static CheckStatus Validate(string userName, string password)
        {
            if (dict == null)
            {
                return CheckStatus.ServiceError;
            }
            if (!dict.ContainsKey(userName))
            {
                return CheckStatus.InvalidUser;
            }
            if (!dict[userName].AuthKey.Equals(new Guid(password)))
            {
                return CheckStatus.InvalidPassword;
            }
            return CheckStatus.Success;
        }


    }
}