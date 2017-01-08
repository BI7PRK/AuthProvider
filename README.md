# AuthProvider

WCF用户认证的服务端及客户端扩展

服务端  Web.config

<pre><code>
&lt;extensions&gt;<br />
&lt;behaviorExtensions&gt;<br />
&lt;add name=&quot;UserNameValidateServiceBehavior&quot; type=&quot;WCF.AuthProvider.Service.UserValidateBehaviorExtensionElement, WCF.AuthProvider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null&quot; /&gt;<br />
&lt;/behaviorExtensions&gt;

....
&lt;behaviors&gt;<br />
  &lt;serviceBehaviors&gt;<br />
  &lt;behavior name=&quot;default_behavior&quot;&gt;<br />
&lt;/serviceBehaviors&gt;<br />
&lt;/behaviors&gt;
</code>
</pre>

客户端 App.config
<pre><code>
&lt;extensions&gt;<br />
&lt;behaviorExtensions&gt;<br />
&lt;add name=&quot;ClientUserValidate&quot; type=&quot;WCF.AuthProvider.Client.UserNameValidateBehaviorExtensionElement, WCF.AuthProvider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null&quot; /&gt;<br />
&lt;/behaviorExtensions&gt;<br />
&lt;/extensions&gt;
</code>
</pre>

```C#
//存储登陆用户的信息
public class LoginUser : IAuthUser
{
 ...
}
  
//在登陆服务的方法启用
WCF.AuthProvider.Service.AuthHelper.AddAuth(new LoginUser{ ... });
  
  
  //客户端用户传话保持
  // 登陆成功后调用
  // UserName 登陆的用户名
  // AuthKey 服务端颁发的认证标识
  new WCF.AuthProvider.Client.ClientAuthen(result.UserName, result.AuthKey.ToString());
  
  
```
