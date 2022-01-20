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

## Setup & usage

The core requirement to use the endpoints in the library is to have a Spartan token, that is provided by the Halo Infinite service. That being said, there are two ways to experiment with the library:

1. **Bring your own Spartan token**. That means that you can obtain it on your own through man-in-the-middle inspection of the app/game traffic, or by grabbing it from the [Halo Waypoint](https://halowaypoint.com) site. Read more on that in the [section below](#bring-your-own-token).
2. **Executing the full authentication flow yourself.** This is a bit more complex, but doable because Grunt API wraps all the required methods out-of-the-box. For details, see [section below](#authenticate-yourself).

### Bring your own token

If you want to bring your own token, you carry the responsibility of acquiring and getting an up-to-date version of the Spartan token (they do expire frequently).

## Endpoints

Complete list of endpoints can be obtained by querying the official Halo Infinite API:

```bash
https://settings.svc.halowaypoint.com/settings/hipc/e2a0a7c6-6efe-42af-9283-c2ab73250c48
```

The endpoint above does not require authentication and can be queried in the open.
