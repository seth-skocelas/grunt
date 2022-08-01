![Grunt logo](https://raw.githubusercontent.com/OpenSpartan/grunt/main/media/grunt-logo.png)

# 🪐 Grunt API - The Halo API Wrapper

_Your one-stop-shop for the official undocumented Halo API_

[![Stand With Ukraine](https://raw.githubusercontent.com/vshymanskyy/StandWithUkraine/main/badges/StandWithUkraine.svg)](https://den.dev/ukraine) [![Publish API Documentation](https://github.com/dend/grunt/actions/workflows/publish-api-docs.yml/badge.svg)](https://github.com/dend/grunt/actions/workflows/publish-api-docs.yml) [![Publish In-Repo NuGet Package](https://github.com/dend/grunt/actions/workflows/publish-inrepo-package.yml/badge.svg)](https://github.com/dend/grunt/actions/workflows/publish-inrepo-package.yml) [![Publish NuGet Package](https://github.com/dend/grunt/actions/workflows/publish-nuget-package.yml/badge.svg)](https://github.com/dend/grunt/actions/workflows/publish-nuget-package.yml)

Welcome to **Grunt API** - the unofficial way to use official undocumented Halo APIs. Here be **a lot of dragons** and this is not yet ready to be a standalone package, since the changes will be frequent and large. That said, you can use it as a test pad for your own explorations.

> **⚠️ WARNING **
>
> This API wraps the undocumented Halo Waypoint APIs and requires use of your account credentials/tokens. While 343 Industries has not yet raised any concerns over the use of these APIs, we cannot guarantee 343 Industries won't change their position (e.g. ban your account).
> 

This API enables you to:

- Get stats on matches you played.
- Get your personal player stats.
- Track your campaign progress.
- Track map and game mode popularity (see - [`openspartan-data-snapshots`](https://github.com/OpenSpartan/openspartan-data-snapshots)).

And more!

## Table of contents

- [Platform Support](#platform-support)
- [Components](#components)
- [Setup & usage](#setup--usage)
	- [Bring your own token](#bring-your-own-token)
	- [Authenticate yourself](#authenticate-yourself)
- [Endpoints](#endpoints)
- [Documentation](#documentation)
- [FAQ](#faq)
- [Contributions](#contributions)

## Platform Support

### .NET

[![NuGet download link for OpenSpartan.Grunt](https://img.shields.io/nuget/v/OpenSpartan.Grunt?label=NuGet)](https://www.nuget.org/packages/OpenSpartan.Grunt) [![NuGet download link for OpenSpartan.Grunt with download counter](https://img.shields.io/nuget/dt/OpenSpartan.Grunt)](https://www.nuget.org/packages/OpenSpartan.Grunt)

### Python

_In development_

### Node.js

_In development_

## Components

| Component | Description |
|:----------|:------------|
| [`Grunt`](https://github.com/dend/grunt/tree/main/Grunt/Grunt) | The core library, written in C#, that wraps the Halo Infinite web APIs. |
| [`Grunt.Zeta`](https://github.com/dend/grunt/tree/main/Grunt/Grunt.Zeta) | Experimental ground for the Grunt library. It's a project where wrapped APIs from Grunt are tested in a more real scenario. |
| [`Grunt.Librarian`](https://github.com/dend/grunt/tree/main/Grunt/Grunt.Librarian) | Tool used to auto-generate code stubs for Halo Infinite API endpoints. It's a very "brute"-ish way to produce the code, but it works for now. |

## Setup & usage

The core requirement to use the endpoints in the library is to have a Spartan token, that is provided by the Halo Infinite service.

>**⚠️ WARNING**
>
>The Spartan token is associated with _your identity_ and _your account_. **Do not share it** with anyone, under any circumstances. The API wrapper does not explicitly store it anywhere. It's your responsibility to make sure that it's secure and not available to anyone else.

There are two ways to experiment with the library:

1. **Bring your own Spartan token**. That means that you can obtain it on your own through man-in-the-middle inspection of the app/game traffic (what Julia Evans described [in her blog post](https://jvns.ca/blog/2022/03/10/how-to-use-undocumented-web-apis/)), or by grabbing it from the [Halo Waypoint](https://halowaypoint.com) site. Read more on that in the [section below](#bring-your-own-token).
2. **Executing the full authentication flow yourself.** This is a bit more complex, but doable because Grunt API wraps all the required methods out-of-the-box. You are still using your own identity and account, but will be generating a new Spartan token for your requests. For details, see [section below](#authenticate-yourself).

### Bring your own token

If you want to bring your own token, you carry the responsibility of acquiring and getting an up-to-date version of the Spartan token (they expire frequently). The easiest way to do that is by looking at the [Halo Waypoint site](https://halowaypoint.com) through the lens of your browser's Network Inspector.

Look for API calls that return JSON data, and in some of the request headers you will notice a particularly interesting one - `x-343-authorization-spartan`. That's what you need.

![Acquiring the Spartan token from the Halo Waypoint website](https://raw.githubusercontent.com/OpenSpartan/grunt/main/media/spartan-token.png) 

I'll say it again - this token is not long-lived and if you see calls failing with `401 Unauthorized`, that means you need a new token.

Some API calls are also requiring you include another header - `343-clearance`. This token is obtained through a separate API call, but you can also grab it from the Halo Waypoint site. If you look for it in the network inspector, you will get the `343-clearance` header as well.

Once you have the Spartan and clearance tokens, you are good to go, and can now [call the API endpoints from Grunt](https://docs.gruntapi.com/dotnet/api/openspartan.grunt.core/openspartan.grunt.core.haloinfiniteclient).

```csharp
HaloInfiniteClient client = new(<YOUR_SPARTAN_TOKEN>, <YOUR_CLEARANCE_TOKEN>, <YOUR_XUID_REQUIRED_ONLY_FOR_SOME_CALLS>);

// Try getting actual Halo Infinite data.
Task.Run(async () =>
{
    var example = await client.StatsGetMatchStats("21416434-4717-4966-9902-af7097469f74");
    Console.WriteLine("You have data.");
}).GetAwaiter().GetResult();
```

### Authenticate yourself

> **IMPORTANT**: The instructions below are using Visual Studio 2019, but are going to work with Visual Studio 2022, which you can [download for free](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=17).

If you want to automatically generate the Spartan token, you can do so with the help of Grunt API without having to worry about doing any of the REST API calls yourself. Before you get started, make sure that you [register an Azure Active Directory application](https://docs.microsoft.com/azure/active-directory/develop/quickstart-register-app). You will need it in order to log in with your Microsoft account, that will be used to generate the token. Because this is just for you, you can use `https://localhost` as the redirect URI when you create the application, unless you're thinking of productizing whatever you're building.

With the application created, in the `Grunt.Zeta` project create a `client.json` file, that has the following contents:

```json
{
  "client_id": "<YOUR_CLIENT_ID_FROM_AAD>",
  "client_secret": "<YOUR_SECRET_FROM_AAD>",
  "redirect_url": "<YOUR_REDIRECT_URI_FROM_AAD>"
}
```

When you add the configuration file to your project, make sure that it's `Build Action` is set to `None` and `Copy to Output Directory` is `Copy if newer`.

![Configuration file for Grunt.Zeta](https://raw.githubusercontent.com/OpenSpartan/grunt/main/media/grunt-zeta-config.png)

With the file there, you can now run through the authentication flow, that is powered by Grunt's helper methods:

```csharp
ConfigurationReader clientConfigReader = new();
var clientConfig = clientConfigReader.ReadConfiguration<ClientConfiguration>("client.json");

XboxAuthenticationClient manager = new();
var url = manager.GenerateAuthUrl(clientConfig.ClientId, clientConfig.RedirectUrl);

HaloAuthenticationClient haloAuthClient = new();

OAuthToken currentOAuthToken = null;

var ticket = new XboxTicket();
var haloTicket = new XboxTicket();
var extendedTicket = new XboxTicket();

var xblToken = string.Empty;
var haloToken = new SpartanToken();

if (System.IO.File.Exists("tokens.json"))
{
    Console.WriteLine("Trying to use local tokens...");
    // If a local token file exists, load the file.
    currentOAuthToken = clientConfigReader.ReadConfiguration<OAuthToken>("tokens.json");
}
else
{
    currentOAuthToken = RequestNewToken(url, manager, clientConfig);
}

Task.Run(async () =>
{
    ticket = await manager.RequestUserToken(currentOAuthToken.AccessToken);
    if (ticket == null)
    {
        // There was a failure to obtain the user token, so likely we need to refresh.
        currentOAuthToken = await manager.RefreshOAuthToken(clientConfig.ClientId, currentOAuthToken.RefreshToken, clientConfig.RedirectUrl, clientConfig.ClientSecret);
        if (currentOAuthToken == null)
        {
            Console.WriteLine("Could not get the token even with the refresh token.");
            currentOAuthToken = RequestNewToken(url, manager, clientConfig);
        }
        ticket = await manager.RequestUserToken(currentOAuthToken.AccessToken);
    }
}).GetAwaiter().GetResult();

Task.Run(async () =>
{
    haloTicket = await manager.RequestXstsToken(ticket.Token);
}).GetAwaiter().GetResult();

Task.Run(async () =>
{
    extendedTicket = await manager.RequestXstsToken(ticket.Token, false);
}).GetAwaiter().GetResult();

if (ticket != null)
{
    xblToken = manager.GetXboxLiveV3Token(haloTicket.DisplayClaims.Xui[0].Uhs, haloTicket.Token);
}

Task.Run(async () =>
{
    haloToken = await haloAuthClient.GetSpartanToken(haloTicket.Token);
    Console.WriteLine("Your Halo token:");
    Console.WriteLine(haloToken.Token);
}).GetAwaiter().GetResult();

HaloInfiniteClient client = new(haloToken.Token, extendedTicket.DisplayClaims.Xui[0].Xid);

// Test getting the clearance for local execution.
string localClearance = string.Empty;
Task.Run(async () =>
{
    var clearance = (await client.SettingsGetClearance("RETAIL", "UNUSED", "222249.22.06.08.1730-0")).Result;
    if (clearance != null)
    {
        localClearance = clearance.FlightConfigurationId;
        client.ClearanceToken = localClearance;
        Console.WriteLine($"Your clearance is {localClearance} and it's set in the client.");
    }
    else
    {
        Console.WriteLine("Could not obtain the clearance.");
    }
}).GetAwaiter().GetResult();

// Try getting actual Halo Infinite data.
Task.Run(async () =>
{
    var example = await client.StatsGetMatchStats("21416434-4717-4966-9902-af7097469f74");
    Console.WriteLine("You have stats.");
}).GetAwaiter().GetResult();
```

The code above will try to read tokens locally and refresh them, if available.

> **👋 NOTE**
>
>This is worth additional investigation, but it seems that if the clearance (`343-clearance` header) is used, it needs to be activated at least once with the game before the API access is granted. That is, you need to launch the game at the latest build on your account before you can start querying the API. If you are running into issues with the API and are getting `403 Forbidden` errors, make sure that you start Halo Infinite at least once before retrying.

Once you have the Spartan token, you are good to go and can start issuing API requests. Keep in mind that the Spartan token does expire, so you will need to refresh it along other tokens as well.

## Endpoints

Complete list of endpoints can be obtained by querying the official Halo Infinite API, that also helpfully contains all the metadata and requirements for each:

```bash
https://settings.svc.halowaypoint.com/settings/hipc/e2a0a7c6-6efe-42af-9283-c2ab73250c48
```

The endpoint above does not require authentication and can be queried in the open. You can also peruse an offline version of the API response [in the library](https://github.com/dend/grunt/blob/main/Grunt/Grunt/endpoints.json).

## Documentation

You can read the docs on the [Grunt docs website](https://docs.grunt.com).

## FAQ

**Q1: Is this in any way endorsed by 343 Industries or Microsoft?**

No. Not at all. This is something that I've put together myself by inspecting network traffic. This project is not funded, supported, or otherwise endorsed by either 343 Industries or Microsoft.

**Q2: Something is broken and my production site that uses your library doesn't work. Can you help?**

Don't use any of this code in production. It's nowhere near stable, and will never be.

**Q3: Some API endpoint is not working anymore or returns an unexpected result. What's up with that?**

[Open an issue](https://github.com/dend/grunt/issues) so that I can investigate.

**Q4: How do I contact the author?**

[Open an issue](https://github.com/dend/grunt/issues) or reach out [on Twitter](https://twitter.com/denniscode).

**Q5: Can this be used for commercial purposes?**

_Absolutely not_. This project is exploratory in nature. It has no guarantees, implied or otherwise, of your ability to consume the API. It does not give you any permission to use this in commercial projects, and neither does it guarantee API access or stability. If you are looking at building something serious using the Halo API, you need to reach out to [343 Industries](https://www.343industries.com/studio).

## Contributions

Contributions are welcome, but please first [open an issue](https://github.com/dend/grunt/issues) so that we can discuss before writing any code.
