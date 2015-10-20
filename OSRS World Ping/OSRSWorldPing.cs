using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace OSRS_Ping {
    public partial class OSRSWorldPing : Form {
        public OSRSWorldPing() {
            InitializeComponent();
        }
        const int MAX_PINGS = 100;

        List<string> worldSelectPage = new List<string>(); // store all the world stats
        List<World> worlds = new List<World>(); 

        Dictionary<int, int> pings = new Dictionary<int, int>(); // temporarily store the world / ping

        BackgroundWorker bw = new BackgroundWorker();

        private void btnPing_Click(object sender, EventArgs e) {
            if(!bw.IsBusy) {
                worldSelectPage.Clear();
                pings.Clear();
                worlds.Clear();
                bw = new BackgroundWorker(); // multiple threads maybe
                bw.DoWork += bw_DoWork;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                bw.WorkerReportsProgress = true;
                bw.ProgressChanged += bw_ProgressChanged;
                bw.WorkerSupportsCancellation = true;
                bw.RunWorkerAsync();
                btnPing.Text = "Working...";
            }
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            lblProgress.Text = e.ProgressPercentage + " of " + e.UserState + " pings done";
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            try {
                string[] dataSplit;
                WebRequest request = WebRequest.Create("http://oldschool.runescape.com/slu");
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string strResponse = reader.ReadToEnd();
                dataSplit = strResponse.Split('\n'); // easier to split every line for searching
                for(int i = 0; i < dataSplit.Length; i++) {
                    if(dataSplit[i].Contains("e(3")) { // OSRS world stats (players, world activity, etc)
                        worldSelectPage.Add(dataSplit[i]);
                    }
                }
                string[] data;
                foreach(string g in worldSelectPage) {
                    data = g.Split(',');
                    worlds.Add(new World(int.Parse(Regex.Match(data[0], @"\d+").Value), Convert.ToInt32(data[4]), Convert.ToBoolean(data[1]), data[5], data[7], 0)); // worldID, type, players, location, canonical name, ping
                }
                foreach(var p in pings.ToArray()) { 
                    foreach(var k in worlds) {
                        int canonicalWorldID = int.Parse(Regex.Match(k.canonicalName, @"\d+").Value); // world ID in the canonical name (i.e. Old School 62)
                        if(p.Key == canonicalWorldID) {
                            k.ping = p.Value;
                            pings.Remove(p.Key);
                        }
                    }
                }
                dataGridView.Rows.Clear();
                foreach(var l in worlds) {
                    dataGridView.Rows.Add(l.worldID, l.players, l.location, l.isMembers == true ? "Members" : "Free", l.ping);
                }
                foreach(var p2 in pings) { // any worlds that are left are worlds that don't appear in the official world list
                    int worldID = int.Parse(p2.Key.ToString().Length == 1 ? "30" + p2.Key : "3" + p2.Key);
                    dataGridView.Rows.Add(worldID, (short)-1, "Unknown", "Unknown", p2.Value);
                }
                dataGridView.Sort(dataGridView.Columns[4], ListSortDirection.Ascending);
                btnPing.Text = "Get World Ping";
            } catch(Exception ex) {
                MessageBox.Show("Unable to get OSRS world data - " + ex.Message);
            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e) {
            for(int i = 1; i <= MAX_PINGS; i++) { // maybe 2 pings per world?
                try {
                    Ping ping = new Ping();
                    PingReply reply = ping.Send("oldschool" + i.ToString() + ".runescape.com");
                    if(reply.Status == IPStatus.Success) {
                        //e.Result = i.ToString() + "," + reply.RoundtripTime.ToString();
                        pings.Add(i, int.Parse(reply.RoundtripTime.ToString()));
                    }
                } catch(Exception) {
                    // pinged a non-existant server
                }
                bw.ReportProgress(i, MAX_PINGS);
            }
        }

        private void OSRSWorldPing_FormClosing(object sender, FormClosingEventArgs e) {
            if(bw.IsBusy) {
                bw.CancelAsync();
                bw.Dispose();
            }
        }

    }
}
