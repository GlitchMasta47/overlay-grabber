# Overlay Grabber
Simple Windows proof of concept for the Discord Overlay exploit. Named after Anarchy Grabber, a similar Discord exploit that can also be used to get user information.

## How does it work?
The Discord Game Overlay connects to the user's Discord client over a WebSocket server it creates for RPC. After investigating the data being sent between the client and the overlay on June 24, 2020, I found that one of the payloads being sent (`OVERLAY_INITIALIZE`) contained an almost complete dump of user information including:

- Username and discriminator (4 digits after the #)
- User ID
- User's email and phone number if they were linked
- **User's auth token (allows anybody to perform actions as that user)**
- User's analytics token (used by Discord for tracking analytics data)
- A list of all servers the user is in and:
  - The server's name, image, and ID
  - All channels in the server (including ones that the user doesn't have permission to see)
  - All members of the server and all roles they have, the color of their username, and server nickname if one is set
  - All emojis from the server
  - The server's explicit content filter setting and verification setting
  - The server's feature flags (whether or not it has access to announcement channels, server insights, welcome screens, etc.)
  - When the server was made and when the user joined the server
  - All server roles including color, permissions, and if it's pingable
  - How many server boosts the server has and what boost level the server is at
- The user's friends list, blocked list, and pending friend requests
- A list of every user that the client has ever interacted with
  - That user's name, discriminator, id, and profile picture
  - The user's online status and playing status (including rich presence info)
  - The custom note linked to that user
  - When their account was created
  - User flags (mostly badges on their profile, e.g. Nitro or HypeSquad Houses)
  - Mutual servers and friends (may require auth token usage)
- **Cached payment information if available including full name and billing address**
  - If not cached, can also be retrieved using the user's auth token
  
If this proof of concept didn't disconnect after receiving this data, it would also be forwarded all gateway events including **incoming messages in all channels and DMs**, status changes, etc. Unlike Anarchy Grabber, this exploit can't retrieve the user's password but it can still get a lot of information about the user without restarting Discord or leaving files behind.

## Building
Open this repository in Microsoft Visual Studio (this project was made in Visual Studio 2017 but newer versions should work fine) with C# tools installed and build from there.

## Pre-built Executables
Don't have Visual Studio? Go to the [releases](https://github.com/GlitchMasta47/overlay-grabber/releases) page and download the exe file.

## Potentially Dangerous Uses
Here's a very brief list of possible malicious uses for this exploit:

- Hidden in a game and sent to content creators
- "Free Nitro hack"
- Implemented in RAT toolkits and sold
- And many more

This exploit could easily be hidden in any application and while "never open apps you don't know about" is always something people know, a lot of people don't treat apps as dangerously as they could be.

## Why is this important?
Unlike many other similar exploits, this one doesn't read or write to the disk or inject code into Discord. As far as any antivirus scan would show, it only has local network activity and that's it. The ZIP file is only detected by [1/63 antiviruses](https://www.virustotal.com/gui/file/4ed01cb3d9fdc64e233e019fecaa38282aba5828eaca699c7576888b5c9e2429/detection) and the executable is only detected by [1/70 antiviruses](https://www.virustotal.com/gui/file/36868eddbf3c06c851421395c1735a380af7aea1dc51cedf5e9003d2d9f75a94/detection). These are insanely low numbers, and anybody running this with antiviruses installed are extremely unlikely to have it automatically deleted.

## License
This project is licensed with The Unlicense, meaning you're free to do anything with this project and the source code as you wish. This project could easily be made better by anybody else with more C# experience than I have, so I invite everyone who matches that description to fork this repository and make it more efficient.

## Note to Discord
How did you actually make a mistake this terrible? I recommend implementing or considering implementing the below list of basic fixes that would make this attack incredibly difficult if not impossible.

- [ ] When the user turns off "Enable in-game overlay" in their user settings, the client should block any attempted overlay connections
- [ ] When the overlay request comes in, verify that the process id sent is not only valid but is a game that Discord knows and (even better) a game that Discord has actually launched the overlay for
- [ ] Don't include the payment sources in the `OVERLAY_INITIALIZE` payload. There's literally no reason for the overlay to have access to this information.
- [ ] Actually care about your users, not just Nitro subscribers.
- [ ] Lock user tokens to a specific user agent so they can't just be put in a browser and work instantly. This doesn't completely remove the risk of token compromises, but it helps their security. Even better, if you detect an unauthorized usage of a user token immediately warn the user (potentially with your system messages functionality).

Thanks for actually reading this, if you even did. If you're a Discord staff member reading this, please [contact me](#contact) as I'd like to know your thoughts.

## Contact
Press inquiries or other general questions can be asked in [my Twitter DMs](https://twitter.com/messages/compose?recipient_id=714475628905512962), [on Telegram](https://t.me/glitchmasta47), or [through Keybase](https://keybase.io/glitchmasta47).
