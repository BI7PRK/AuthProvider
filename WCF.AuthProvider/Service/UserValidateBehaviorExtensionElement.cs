using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace WCF.AuthProvider.Service
{
    public class UserValidateBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(UserValidateBehavior); }
        }
        protected override object CreateBehavior()
        {
            return new UserValidateBehavior();
        }
    }
}
