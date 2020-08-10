using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverlayPOC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
             * Thank you, Discord devs, for introducing features that
             * barely have any security. Based on your response, I
             * assume you don't care about user security unless they
             * have a Nitro subscription or they're partnered.
             * 
             * You can only go so long before your platform goes down.
             * Please just care about user security for once.
             * 
             * Send inquiries to @glitchmasta47 on Twitter.
             */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
