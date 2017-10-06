using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Reflection;
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
        string path = Assembly.GetExecutingAssembly().Location;

        // define location of files to be read
        StringDictionary labs = new StringDictionary();
        string fileMessages = "messages.txt";

        public Form1()
        {
            InitializeComponent();
            fadeIn.Tick += new EventHandler(fadeIn_Tick);
            fadeOut.Tick += new EventHandler(fadeOut_Tick);
            wait.Tick += new EventHandler(wait_Tick);

            labs.Add("Daily Top Donor", "streamlabs\\session_top_donator.txt");
            labs.Add("Monthly Top Donor", "streamlabs\\monthly_top_donator.txt");
            labs.Add("Latest Sub", "streamlabs\\most_recent_subscriber.txt");
            labs.Add("Latest Cheer", "streamlabs\\most_recent_cheerer.txt");

            loop();
        }

        void loop()
        {
            while (true)
            {
                foreach (DictionaryEntry entry in labs)
                {
                    if (File.Exists(path + entry.Value))
                    {
                        StreamReader rdr = new StreamReader(path + entry.Value);
                        lblMessage.Text = entry.Key + ": " + rdr.ReadLine();
                        StartFade();
                    }
                }
                if (File.Exists(path + fileMessages))
                {
                    string[] lines = File.ReadAllLines(path + fileMessages);
                    foreach (string line in lines)
                    {
                        lblMessage.Text = line;
                        StartFade();
                    }
                }
            }
        }

        private void StartFade()
        {
            fadeIn.Enabled = true;
            fadeIn.Interval = 10;
            fadeIn.Start();
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
                    wait.Interval = 10000;
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
            }
        }

        private void wait_Tick(object sender, EventArgs e)
        {
            // maybe we want to shift some stuff here to take advantage of the 10s delay?
            fadeOut.Enabled = true;
            fadeOut.Interval = 10;
            fadeOut.Start();
        }
    }
}
