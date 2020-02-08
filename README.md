# KanyeBot
Discord bot built with [Discord.NET](https://github.com/discord-net/Discord.Net) that consumes the [kanye.rest service](https://kanye.rest/) for enlightening the public.

## Building
Verify that the following dependencies are installed before attempting to build - [.NET Core 2.1](https://dotnet.microsoft.com/download/dotnet-core/2.1).

To build the bot, run the following command:
```bash
dotnet publish -c Release
```

## Usage
KanyeBot relies on the "DiscordToken" environment variable. This can be generated from the [Discord applications page.](https://discordapp.com/developers/applications)

The bot will respond to messages containing "kanye" and/or "west".
![Example](https://i.imgur.com/aS4JHOB.png)