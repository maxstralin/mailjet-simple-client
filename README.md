# Mailjet Simple Client <img src="assets/LogoMJ_Yellow_RVB.png" alt="Mailjet Logo" title="Mailjet Logo" height="50px" />
> A simple, yet customisable, client for interacting with Mailjet

![](https://img.shields.io/travis/maxstralin/mailjet-simple-client.svg?style=flat-square)
<a href="https://www.nuget.org/packages/Mailjet.SimpleClient/" target="_blank"><img alt="Nuget package" title="Nuget package" src="https://img.shields.io/nuget/v/Mailjet.SimpleClient.svg?color=1081c2&label=Stable&style=flat-square" /></a>
<a href="https://www.nuget.org/packages/Mailjet.SimpleClient/" target="_blank"><img alt="Nuget package" title="Nuget package" src="https://img.shields.io/nuget/vpre/Mailjet.SimpleClient.svg?label=Latest&style=flat-square" /></a>
![](https://img.shields.io/github/license/maxstralin/mailjet-simple-client.svg?style=flat-square)

Note that currently transactional emails, V3.1, is supported but you can easily customise/add behaviour yourself, see [Customise](#customise).

At the moment the code base is work in progress but contributions are very welcome still.

## Prerequisites

- Mailjet account, with public/private key and/or token for SMS API (V4). [How to get API keys](https://www.mailjet.com/support/what-are-the-api-key-and-secret-keys-how-should-i-use-them,109.htm)
- Targets `.NET Standard 2.0`, meaning it works on
    -  .NET Core >= 2.0
    -  .NET Framework 4.6.1
    -  [and more...](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

## Installing

Currently in prelease

**Package Manager Console**

`Install-Package Mailjet.SimpleClient –IncludePrerelease`

**Nuget Package Manager**

Search for `Mailjet.SimpleClient`, ensure to tick "Include prerelease"

## Usage

- [Sending emails](https://github.com/maxstralin/mailjet-simple-client/wiki/Sending-emails)
- [Clients](https://github.com/maxstralin/mailjet-simple-client/wiki/Clients)
- [Working with multiple types of requests](https://github.com/maxstralin/mailjet-simple-client/wiki/Clients)

### Types of clients
Generally, if you're working with one type of request, e.g. only sending emails, then it's usually better to use a specific client for it.
If you're working with multiple types of requests, e.g. sending an email and updating a template, then it's better to use the generic `IMailjetSimpleClient.SendRequeststAsync()`.

See [Clients](https://github.com/maxstralin/mailjet-simple-client/wiki/Clients) and  [Working with multiple types of requests](https://github.com/maxstralin/mailjet-simple-client/wiki/Clients)

### Dependency injection
**Register clients**
```csharp
public void ConfigureServices(IServiceCollection services)
    {
        services.AddMailjetClients(opt =>
        {
            //Set up settings
            opt.EmailOptions.SandboxMode = true;
            opt.PrivateKey = "";
            opt.Token = "";
        });
    }
```

**Inject into controller/action**

`AddMailjetClient()` creates three services: `IMailjetOptions`, `IMailjetEmailClient`, and `IMailjetSimpleClient`, which can be injected as any other service throuh your controller's constructor or action parameters.

### Manual
#### Email client
```csharp
var emailClient = new MailjetEmailClient(new MailjetSimpleClient(), new MailjetOptions());
```

#### Low level client
```csharp
var simpleClient = new MailjetSimpleClient();
```

### Customise
Add your own implementations to the DI container as below.

```csharp
services.AddMailjetOptions(IMailjetOptions)
```

```csharp
services.AddMailjetSimpleClient<YourMailjetSimpleClient>()
```

```csharp
services.AddMailjetEmailClient<YourMailjetEmailClient>();
```

## Authors

* [Max Strålin](https://github.com/maxstralin)

See also the list of [contributors](https://github.com/maxstralin/mailjet-simple-client/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
