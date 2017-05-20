using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.AuthProvider.Client
{
    public class ClientAuthen
    {
        /// <summary>
        /// 在本地保存已通过认证的用户
        /// </summary>
        /// <param name="userName">登陆用户的唯一名称，默认为用户ID</param>
        /// <param name="authKey"></param>
        /// <param name="ns"></param>
        public ClientAuthen(string userName, string authKey, string ns= "http://www.bi7prk.com/")
        {
            UserName = userName;
            AuthKey = authKey;
            _ns = ns;
        }

        internal static string UserName { get; private set; }
        internal static string AuthKey { get; private set; }
        internal static string _ns { get; private set; }

    }
}
