using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WCF.AuthProvider.Client
{
    public class ClientMessageInspector :  IClientMessageInspector
    {
      

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {

        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(this);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
           
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            string wcfAddress = channel.Via.ToString();
           
            var userNameHeader = MessageHeader.CreateHeader("UserName", ClientAuthen._ns, ClientAuthen.UserName, false, "");
            var passwordHeader = MessageHeader.CreateHeader("Password", ClientAuthen._ns, ClientAuthen.AuthKey, false, "");
            request.Headers.Add(userNameHeader);
            request.Headers.Add(passwordHeader);
            //Console.WriteLine(request);
            return null;
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            throw new NotImplementedException();
        }

    }
}
