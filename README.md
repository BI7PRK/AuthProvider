# AuthProvider

WCF用户认证的服务端及客户端扩展

服务端  Web.config
```XML
<extensions>
<behaviorExtensions>
<add name="UserNameValidateServiceBehavior" type="WCF.AuthProvider.Service.UserValidateBehaviorExtensionElement, WCF.AuthProvider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />
</behaviorExtensions>

....
  <!-- 添加服务时 behaviorConfiguration 引用该配置名 -->
<behavior name="ValidateBehavior">
  <UserNameValidateServiceBehavior />
  <serviceMetadata httpGetEnabled="false" httpsGetEnabled="false" />
  <serviceDebug includeExceptionDetailInFaults="true" />
  <serviceThrottling maxConcurrentSessions="100000" />
  <dataContractSerializer maxItemsInObjectGraph="2147483647" />
</behavior>
```
客户端 App.config
```XML
<extensions>
  <behaviorExtensions>
  <add name="ClientUserValidate" type="WCF.AuthProvider.Client.UserNameValidateBehaviorExtensionElement, WCF.AuthProvider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />
  </behaviorExtensions>
</extensions>

<behaviors>
  <endpointBehaviors>
    <behavior name="UserValidate">
      <ClientUserValidate />
    </behavior>
  </endpointBehaviors>
</behaviors>

```

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
