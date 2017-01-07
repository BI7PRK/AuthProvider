using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace WCF.AuthProvider.Service
{
    public class ServiceMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            //Console.WriteLine(request);
            var username = GetHeaderValue("UserName", AuthHelper._NS);
            var password = GetHeaderValue("Password", AuthHelper._NS);

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(username))
            {
                throw new FaultException("未知的用户");
            }

            if (!AuthHelper.Validate(username, password))
            {
                throw new FaultException("授权验证失败");
            }

            return null;//if success return null.
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {


        }

        private string GetHeaderValue(string name, string ns)
        {
            var headers = OperationContext.Current.IncomingMessageHeaders;
            var index = headers.FindHeader(name, ns);
            if (index > -1)
                return headers.GetHeader<string>(index);
            else
                return null;
        }
    }
}
