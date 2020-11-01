# Vampire: The Masquerade Discord Dice Roller Bot
This is an unofficial Discord Bot for Vampire: The Masquerade fifth edition.

## Features
- Managing hunger
    - `!sethunger`
    - `!gainhunger`
- Rouse checks
    - `!rouse`
- Rolling dice
    - `!roll` 
- Rerolling previous rolls 
    - `!reroll`

## How do I use this?
This bot was just written for personal use so I have not taken any steps to package this bot.
You will need to build the bot yourself. 
1. Visit the [Discord Applications Portal](https://discordapp.com/developers/applications/).
2. Create a new application.
3. Name your application.
4. On the left-hand side, click Bot.
5. Click on `Add Bot` and confirm the popup.
6. On the left-hand side, click OAuth2.
7. Scroll down to `OAuth2 URL Generator` and under `Scops` tick bot.
8. Scroll down to `Bot Permissions` and select the `Send Messages` Permission.
9. Open the generated URL from the `OAuth2 URL Generator` and select a server.
10. Go back to the Discord Applications Portal.
11. Go to the Bot in the left-hand side pane.
12. Click the copy button in the Token section.
13. Add an environment variable named `DiscordToken` containing the Token on the system where you wish to host the bot.
14. Install the dotnet core SDK.
15. Clone this repository 
16. Build the bot with the commands `dotnet restore` and `dotnet build`
17. Run the bot with `dotnet run`
18. The bot should now appear as online on your server.
19. (optional) For pretty dice roll results that are not just numbers, add the emotes from the emoji directory the names should match up automatically. You can check if all emotes where found by running the bot command `!verifyemotes`. The bot caches the emote names so you need to run this command again if you change the dice emotes.

## How do the commands work?
`!sethunger 5` Set hunger to five. Hunger is managed per user. The user who runs the command gets the hunger.

`!gainhunger` Increase hunger by one.

`!rouse` Make a rousecheck hunger is added if the check fails.

`!roll 10` Roll a total of 10 dice. If the user has any hunger the appropriate amount of normal dice will be replaced with hunger dice.

`!reroll 1 4 5` Re-roll the first, the fourth and the fifth die in the previous dice roll.


