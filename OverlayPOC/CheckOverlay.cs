using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.WebSockets;
using Websocket.Client;
using System.Text.Json;

namespace OverlayPOC
{
    class CheckOverlay
    {
        public static void Check(int port, Action<OverlayResponse> callback)
        {
            OverlayResponse response = new OverlayResponse(port);
            WebsocketClient overlay = new WebsocketClient(new Uri($"ws://127.0.0.1:{port}/?v=1&encoding=json"), () =>
            {
                ClientWebSocket ws = new ClientWebSocket();
                ws.Options.SetRequestHeader("Origin", "https://discordapp.com");
                return ws;
            })
            {
                IsReconnectionEnabled = false
            };
            overlay.DisconnectionHappened.Subscribe(disconnect =>
            {
                if (disconnect.Exception != null)
                {
                    response.Success = false;
                    callback(response);
                }
            });
            overlay.MessageReceived.Subscribe(message =>
            {
                JsonElement msg = JsonDocument.Parse(message.Text).RootElement;
                if (msg.GetProperty("cmd").GetString() == "DISPATCH" && msg.GetProperty("evt").GetString() == "READY")
                {
                    response.ReleaseChannel = OverlayResponse.ReleaseChannels[msg.GetProperty("data").GetProperty("config").GetProperty("api_endpoint").GetString()];
                    overlay.Send("{\"cmd\":\"SUBSCRIBE\",\"args\":{},\"evt\":\"OVERLAY\",\"nonce\":\"discord-fix-your-software\"}");
                }
                else if (msg.GetProperty("cmd").GetString() == "SUBSCRIBE" && msg.GetProperty("data").GetProperty("evt").GetString() == "OVERLAY")
                {
                    overlay.Send("{\"cmd\":\"OVERLAY\",\"args\":{\"type\":\"CONNECT\",\"pid\":-1},\"nonce\":\"pid-validation-and-blocking-overlay-connections-if-overlay-is-disabled\"}");
                }
                else if (msg.GetProperty("cmd").GetString() == "DISPATCH" && msg.GetProperty("data").GetProperty("type").GetString() == "STORAGE_SYNC")
                {
                    // there's a few small bits of interesting information here but nothing worth a lot
                    response.StorageStates = msg.GetProperty("data").GetProperty("states");
                }
                else if (msg.GetProperty("cmd").GetString() == "DISPATCH" && msg.GetProperty("data").GetProperty("type").GetString() == "DISPATCH" && msg.GetProperty("data").GetProperty("payloads")[0].GetProperty("type").GetString() == "OVERLAY_INITIALIZE")
                {
                    // quality software
                    response.Success = true;
                    response.InitializePayload = msg.GetProperty("data").GetProperty("payloads")[0];
                    overlay.Stop(WebSocketCloseStatus.EndpointUnavailable,"");
                    callback(response);
                }
            });
            overlay.Start();
        }

        public static void CheckAllPorts(Action<List<OverlayResponse>> callback)
        {
            List<OverlayResponse> responses = new List<OverlayResponse>();
            for (var port = 6463; port < 6473; port++)
            {
                Check(port, response =>
                {
                    responses.Add(response);
                    if (responses.Count == 10)
                    {
                        callback(responses);
                    }
                });
            }
            return;
        }
    }
}
