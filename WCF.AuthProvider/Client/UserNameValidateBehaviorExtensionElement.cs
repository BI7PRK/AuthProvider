using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace WCF.AuthProvider.Client
{
    public class UserNameValidateBehaviorExtensionElement: BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get
            {
                return typeof(UserNameValidateBehavior);
            }
        }


        protected override object CreateBehavior()
        {
            return new UserNameValidateBehavior();
        }
    }
}
