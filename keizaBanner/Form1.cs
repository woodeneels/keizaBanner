using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace keizaBanner
{
    public partial class Form1 : Form
    {
        // nasty variable soup pls no judge
        Timer fadeIn = new Timer();
        Timer fadeOut = new Timer();
        Timer wait = new Timer();
        int r = 0;
        int g = 0;
        int b = 0;
        int fade = 0;
        int delay = 0;
        int msg = 0;
        int max = 0;
        int scrollDiff = 0;
        int scrollPos = 0;
        string path = AppDomain.CurrentDomain.BaseDirectory;
        string fullMsg = "";
        bool scrollDone = true;

        // define location of files to be read
        //StringDictionary labs = new StringDictionary();
        string fileMessages = "messages.txt";
        List<KeyValuePair<string, string>> labs = new List<KeyValuePair<string, string>>();

        // create an array of messages
        List<string> messages = new List<string>();

        public Form1()
        {
            InitializeComponent();
            fadeIn.Tick += new EventHandler(fadeIn_Tick);
            fadeOut.Tick += new EventHandler(fadeOut_Tick);
            wait.Tick += new EventHandler(wait_Tick);

            labs.Add(new KeyValuePair<string, string>("Daily Top Donor", "alerts\\session_top_donator.txt"));
            labs.Add(new KeyValuePair<string, string>("Monthly Top Donor", "alerts\\monthly_top_donator.txt"));
            labs.Add(new KeyValuePair<string, string>("Latest Sub", "alerts\\most_recent_subscriber.txt"));
            labs.Add(new KeyValuePair<string, string>("Latest Cheer", "alerts\\most_recent_cheerer.txt"));
            labs.Add(new KeyValuePair<string, string>("Latest Donor", "alerts\\most_recent_donator.txt"));

            fadeIn.Enabled = true;
            fadeIn.Interval = 10;
            fadeIn.Start();
        }

        private int maxChars(string s)
        {
            int i = s.Length;

            while (TextRenderer.MeasureText(s, lblMessage.Font).Width > lblMessage.Width)
            {
                i--;
                s = s.Substring(0, s.Length - 1);
            }

            return i;
        }

        private void fadeIn_Tick(object sender, EventArgs e)
        {
            fade++;
            if (fade <= 500)
            {
                r += 5;
                g += 5;
                b += 5;
                lblMessage.ForeColor = Color.FromArgb(255, r, g, b);

                if (r == 255)
                {
                    fade = 0;
                    r = 255;
                    g = 255;
                    b = 255;
                    fadeIn.Stop();
                    fadeIn.Enabled = false;
                    wait.Enabled = true;
                    wait.Interval = 500;
                    wait.Start();
                }
            }
        }

        private void fadeOut_Tick(object sender, EventArgs e)
        {
            fade++;
            if (fade <= 500)
            {
                r -= 5;
                g -= 5;
                b -= 5;
                lblMessage.ForeColor = Color.FromArgb(255, r, g, b);
            }

            if (r == 0)
            {
                fade = 0;
                r = 0;
                g = 0;
                b = 0;
                fadeOut.Stop();
                fadeOut.Enabled = false;

                try
                {
                    string msgTxt = messages[msg];
                    if (TextRenderer.MeasureText(msgTxt, lblMessage.Font).Width > lblMessage.Width)
                    {
                        max = maxChars(msgTxt);
                        lblMessage.Text = msgTxt.Substring(0, max);
                        fullMsg = msgTxt;
                        scrollDiff = msgTxt.Length - max;
                        scrollDone = false;
                    }
                    else { lblMessage.Text = msgTxt; }
                }
                catch { lblMessage.Text = "~wigglywoo~wigglywoo~wigglywoo~"; }

                msg++;
                if (msg >= messages.Count)
                    msg = 0;

                fadeIn.Enabled = true;
                fadeIn.Interval = 10;
                fadeIn.Start();
            }
        }

        private void wait_Tick(object sender, EventArgs e)
        {
            if (delay == 0)
            {
                messages.Clear();
                foreach (var entry in labs)
                {
                    if (File.Exists(path + entry.Value))
                    {
                        using (StreamReader rdr = new StreamReader(path + entry.Value))
                        {
                            string msg = rdr.ReadLine();
                            messages.Add(entry.Key + ": " + (msg == null ? "None" : msg));
                        }
                    }
                }
                if (File.Exists(path + fileMessages))
                {
                    string[] lines = File.ReadAllLines(path + fileMessages);
                    foreach (string line in lines)
                    {
                        messages.Add(line);
                    }
                }
            }
            delay++;

            if (delay >= 20 && scrollDone)
            {
                delay = 0;
                wait.Stop();
                wait.Enabled = false;
                fadeOut.Enabled = true;
                fadeOut.Interval = 10;
                fadeOut.Start();
            }

            if (!scrollDone && delay >= 8) // four seconds for the front of the message
            {
                scrollPos++;
                string m = fullMsg.Substring(scrollPos, max);
                if (TextRenderer.MeasureText(m, lblMessage.Font).Width > lblMessage.Width)
                {
                    max = maxChars(m);
                    m = fullMsg.Substring(scrollPos, max);
                }
                    lblMessage.Text = m;

                if ((scrollPos + m.Length) >= fullMsg.Length)
                {
                    scrollDone = true;
                    delay = 12; // give us four seconds to appreciate the end of our message
                }
            }
        }
    }
}
