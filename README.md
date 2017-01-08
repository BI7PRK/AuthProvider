# AuthProvider

WCF用户认证的服务端及客户端扩展

服务端 Web.config

<code>
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

客户端 App.config

<code>
&lt;extensions&gt;<br />
&lt;behaviorExtensions&gt;<br />
&lt;add name=&quot;ClientUserValidate&quot; type=&quot;WCF.AuthProvider.Client.UserNameValidateBehaviorExtensionElement, WCF.AuthProvider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null&quot; /&gt;<br />
&lt;/behaviorExtensions&gt;<br />
&lt;/extensions&gt;
</code>
