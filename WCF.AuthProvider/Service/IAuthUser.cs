using System;
using System.Runtime.Serialization;

namespace WCF.AuthProvider.Service
{
    /// <summary>
    /// 登陆用户接口
    /// </summary>
    public interface IAuthUser 
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [DataMember]
        int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        string UserName { get; set; }

        /// <summary>
        /// 认证键值
        /// </summary>
        [DataMember]
        Guid AuthKey { get; set; }

   
    }
}