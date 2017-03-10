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
        /// <param name="user">默认标识键为 UserId</param>
        /// <param name="ns"></param>
        public static void AddAuth(IAuthUser user, string ns= "http://www.bi7prk.com/")
        {
            var strKey = user.UserId.ToString();
            if (dict.ContainsKey(strKey))
            {
                dict.Remove(strKey); //挤下线
            }
            dict.Add(strKey, user);
            _NS = ns;
        }

        /// <summary>
        /// 上线
        /// </summary>
        /// <param name="key">用户认证标识</param>
        /// <param name="user"></param>
        /// <param name="ns"></param>
        public static void AddAuth(string key, IAuthUser user, string ns = "http://www.bi7prk.com/")
        {
            if (dict.ContainsKey(key))
            {
                dict.Remove(key); //挤下线
            }
            dict.Add(key, user);
            _NS = ns;
        }

        /// <summary>
        /// 下线
        /// </summary>
        /// <param name="userKey">用户登陆标识键名</param>
        public static void Checkout(string userKey)
        {
            if (dict.ContainsKey(userKey))
            {
                dict.Remove(userKey);
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
        /// <summary>
        /// 用户是否在线
        /// </summary>
        /// <param name="userKey">用户登陆标识键名</param>
        /// <returns></returns>
        public static bool Any(string userKey)
        {
            return dict != null && dict.ContainsKey(userKey);
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

        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="userKey">用户登陆标识键名</param>
        /// <param name="password"></param>
        /// <returns></returns>
        internal static CheckStatus Validate(string userKey, string password)
        {
            if (dict == null)
            {
                return CheckStatus.ServiceError;
            }
            if (!dict.ContainsKey(userKey))
            {
                return CheckStatus.InvalidUser;
            }
            if (!dict[userKey].AuthKey.Equals(new Guid(password)))
            {
                return CheckStatus.InvalidPassword;
            }
            return CheckStatus.Success;
        }


    }
}