<table>
<tr>
<td width="20%">
    <img src="https://github.com/e455a81e-d3ba-41a2-bc6d-7aafb1d9a5cd/V5_Discord_Bot/raw/master/Images/darkpack_black_logo.png">
</td>
<td>
<h1>Vampire: The Masquerade Discord Dice Roller Bot</h1>
<h3>Unofficial Discord Bot for Vampire: The Masquerade fifth edition.</h3>
</td>
</tr>
</table>

*"Portions of the materials are the copyrights and trademarks of Paradox Interactive AB, and are used with permission.
All rights reserved. For more information please visit [worldofdarkness.com](https://worldofdarkness.com/)."*

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

## How do the commands work?

`!sethunger 5` Set hunger to five. Hunger is managed per user. The user who runs the command gets the hunger.

`!gainhunger` Increase hunger by one.

`!rouse` Make a rousecheck hunger is added if the check fails.

`!roll 10` Roll a total of 10 dice. If the user has any hunger the appropriate amount of normal dice will be replaced with hunger dice. 

![](https://github.com/LariscusObscurus/V5_Discord_Bot/raw/master/Images/roll.png)

`!reroll 1 4 5` Re-roll the first, the fourth and the fifth die in the previous dice roll.

## How do I use this bot?
I am currently not hosting the bot for public consumption so you will need to do that on your own.
You can host your own bot by following these steps:
1. Visit the [Discord Applications Portal](https://discordapp.com/developers/applications/).
2. Create a new application.
3. Name your application.
4. On the left-hand side, click Bot.
5. Click on `Add Bot` and confirm the popup.
6. On the left-hand side, click OAuth2.
7. Scroll down to `OAuth2 URL Generator` and under `Scopes` tick `bot`.
8. Scroll down to `Bot Permissions` and select the `Send Messages` Permission.
9. Open the generated URL from the `OAuth2 URL Generator` and select a server.
10. Go back to the Discord Applications Portal.
11. Go to the Bot in the left-hand side pane.
12. Click the copy button in the Token section. <img src="https://github.com/LariscusObscurus/V5_Discord_Bot/raw/master/Images/Token.png">
13. Add an environment variable named `DiscordToken` containing the Token on the system where you wish to host the bot.
14. Install the [dotnet core runtime](https://dotnet.microsoft.com/download).
15. Download the newest release of this Bot.
16. Extract the files and run the 'V5_Discord_Bot.exe'.
17. The bot should now appear as online on your server.
18. (optional) For pretty dice roll results that are not just numbers, add the emotes from the ![emoji directory](https://github.com/LariscusObscurus/V5_Discord_Bot/tree/master/Emojis). The names should match up automatically. You can check if all emotes where found by running the bot command `!verifyemotes`. 
    The bot caches the emote names so you need to run this command again if you change the dice emotes.
    
    ![](https://github.com/LariscusObscurus/V5_Discord_Bot/raw/master/Images/verify.png)
