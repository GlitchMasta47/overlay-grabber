using System.Collections.Generic;
using System.Text.Json;

namespace OverlayPOC
{
    public class OverlayResponse
    {
        public int Port { get; set; }
        public bool Success { get; set; }
        public string ReleaseChannel { get; set; }
        public JsonElement StorageStates { get; set; }
        public JsonElement InitializePayload { get; set; }

        public OverlayResponse(int port)
        {
            Port = port;
        }

        public static Dictionary<string, string> ReleaseChannels = new Dictionary<string, string>()
        {
            // overlay still returns *.discordapp.com in READY event
            { "//canary.discordapp.com/api", "Canary" },
            { "//ptb.discordapp.com/api", "PTB" },
            { "//discordapp.com/api", "Stable" },
            // just in case overlay starts using *.discord.com instead
            { "//canary.discord.com/api", "Canary" },
            { "//ptb.discord.com/api", "PTB" },
            { "//discord.com/api", "Stable" }
        };
    }
}
