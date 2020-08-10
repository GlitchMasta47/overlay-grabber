# Overlay Grabber
Simple Windows proof of concept for the Discord Overlay exploit. Named after Anarchy Grabber, a similar Discord exploit that can also be used to get user information.

# Building
Open this repository in Microsoft Visual Studio (this project was made in 2017 but newer versions should work fine) with C# tools installed and build from there.

# Pre-built Executables
Don't have Visual Studio? Go to the [releases](https://github.com/GLitchMasta47/overlay-grabber/releases) page and download the exe file.

# License
This project is licensed with The Unlicense, meaning you're free to do anything with this project and the source code as you wish. This project could easily be made better by anybody else with more C# experience than I have, so I invite everyone who matches that description to fork this repository and make it more efficient.

# Note to Discord
How did you actually make a mistake this terrible. I recommend the implementing the below list of basic fixes that would make this attack incredibly difficult if not impossible.

- [ ] When the user turns off "Enable in-game overlay" in their user settings, the client should block any attempted overlay connections
- [ ] When the overlay request comes in, verify that the process id sent is not only valid but is a game that Discord knows and (even better) a game that Discord has actually launched the overlay for
- [ ] Don't include the payment sources in the `OVERLAY_INITIALIZE` payload. There's literally no reason for the overlay to have access to this information.
- [ ] Actually care about your users, not just Nitro subscribers.
- [ ] Lock user tokens to a specific user agent so they can't just be put in a browser and work instantly. This doesn't completely remove the risk of token compromises, but it helps their security. Even better, if you detect an unauthorized usage of a user token immediately warn the user (potentially with your system messages functionality).

Thanks for actually reading this, if you even did. If you're a Discord staff member reading this, please [contact me](#contact) as I'd like to know your thoughts.

# Contact
Press inquiries or other general questions can be asked in [my Twitter DMs](https://twitter.com/messages/compose?recipient_id=714475628905512962), [on Telegram](https://t.me/glitchmasta47), or [through Keybase](https://keybase.io/glitchmasta47).
