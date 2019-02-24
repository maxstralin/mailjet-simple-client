# Mailjet Simple Client
> A simple, yet customisable, client for interacting with Mailjet

Note that currently only V3.1 is supported but you can easily do this yourself, see [Customise](#customise).

At the moment the code base is work in progress but contributions are very welcome still.

### Prerequisites

Mailjet account, with public/private key and/or token for SMS API (V4).

[How to get API keys](https://www.mailjet.com/support/what-are-the-api-key-and-secret-keys-how-should-i-use-them,109.htm)

### Installing

Coming soon: Nuget package.

For now, you'd need to download and install it manually into your solution.

### Usage
#### Dependency injection
> Coming soon

#### Send emails
> More to come
```C#
var emailClient = new MailjetEmailClient(options);
await emailClient.SendAsync(new EmailMessage());
await emailClient.SendAsync(new TemplateEmailMessage());
```

#### Customise
`MailjetSimpleClient` is the low-level class responsible for interacting with Mailjet. Pass anything implementing `IRequestFactory` into `SendRequestAsync` or extend it into a subclass, like `MailjetEmailClient`

## Authors

* [Max Strålin](https://github.com/maxstralin)

See also the list of [contributors](https://github.com/maxstralin/mailjet-simple-client/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details