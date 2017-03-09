using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.AuthProvider.Service
{
    internal enum CheckStatus
    {
        [Description("未知用户")]
        InvalidUser,
        [Description("用户已在别处登陆")]
        InvalidPassword,
        [Description("Success")]
        Success,
        [Description("服务异常")]
        ServiceError
    }
}
