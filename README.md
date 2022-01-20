<div align="center">
	<img alt="Grunt API logo" src="media/grunt-logo.png" width="200" height="200" />
	<h1>🪐 Grunt API</h1>
	<p>
		<b>The unofficial, reverse-engineered Halo Infinite web API</b>
	</p>
	<br>
</div>

Welcome to **Grunt API** - the unofficial way to use official Halo Infinite APIs. Here be **a lot of dragons** and this is not yet ready to be a standalone package, since the changes will be frequent and large. That said, you can use it as a test pad for your own explorations.

This API enables you to:

- Get stats on matches you played.
- Get your personal player stats.
- Track campaign progress.
- Track map popularity

And more!

>**Current stable package ETA:** February 2022

## Components

| Component | Description |
|:----------|:------------|
| `Grunt`   | The core library, written in C#, that wraps the Halo Infinite web APIs. |
| `Grunt.Zeta` | Experimental ground for the Grunt library. This will eventually become the Grunt CLI. |
| `Grunt.Librarian` | Tool used to auto-generate code stubs for Halo Infinite API endpoints. It's a very "brute"-ish way to generate the code, but it works for now. |

## Setup & usage

The core requirement to use the endpoints in the library is to have a Spartan token, that is provided by the Halo Infinite service. That being said, there are two ways to experiment with the library:

1. **Bring your own Spartan token**. That means that you can obtain it on your own through man-in-the-middle inspection of the app/game traffic, or by grabbing it from the [Halo Waypoint](https://halowaypoint.com) site. Read more on that in the [section below](#bring-your-own-token).
2. **Executing the full authentication flow yourself.** This is a bit more complex, but doable because Grunt API wraps all the required methods out-of-the-box. For details, see [section below](#authenticate-yourself).

### Bring your own token

If you want to bring your own token, you carry the responsibility of acquiring and getting an up-to-date version of the Spartan token (they do expire frequently). The easiest way to do that is by looking at the [Halo Waypoint site](https://halowaypoint.com) through the lens of your browser's Network Inspector.

Look for API calls that return JSON data, and in some of the request headers you will notice a particularly interesting one - `x-343-authorization-spartan`. That's what you need.

![Acquiring the Spartan token from the Halo Waypoint website](media/spartan-token.png) 

I'll say it again - this token is not long-lived and if you see calls failing with `401 Unauthorized`, that means you need a new token.

Some API calls are also requiring you include another header - `343-clearance`. This token is obtained through a separate API call that I am yet to document, but you can also grab it from the Halo Waypoint site. An example API call that you can watch for with the Synthwave event going on is this:

```bash
https://gamecms-hacs-origin.svc.halowaypoint.com/hi/Progression/file/ChallengeContent/ClientChallengeDefinitions/S1EventSynthwaveChallenges/Normal/NSynthwaveMedalRevive.json
```

If you look for it in the network inspector, you will get the `343-clearance` header as well. It's on my TODO list to document available endpoints and whether they require clearance or not.

Once you have the Spartan and clearance tokens, you are good to go, and can now call the API endpoints from Grunt.

```csharp
HaloInfiniteClient client = new(<YOUR_SPARTAN_TOKEN>, <YOUR_CLEARANCE_TOKEN>, <YOUR_XUID_REQUIRED_ONLY_FOR_SOME_CALLS>);

// Try getting actual Halo Infinite data.
Task.Run(async () =>
{
    var example = await client.StatsGetMatchStats("21416434-4717-4966-9902-af7097469f74");
    Console.WriteLine("You have data.");
}).GetAwaiter().GetResult();
```

## Endpoints

Complete list of endpoints can be obtained by querying the official Halo Infinite API:

```bash
https://settings.svc.halowaypoint.com/settings/hipc/e2a0a7c6-6efe-42af-9283-c2ab73250c48
```

The endpoint above does not require authentication and can be queried in the open.
