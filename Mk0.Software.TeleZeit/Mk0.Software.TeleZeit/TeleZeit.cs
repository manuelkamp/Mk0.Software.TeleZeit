using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Mk0.Tools.SQLiteTools;
using Mk0.Tools.TimeTools;

namespace Mk0.Software.TeleZeit
{
    public partial class TeleZeit : Form
    {
        private string db = "telezeit.mkz";
        private SQLiteConnection sql;
        private DateTime start, ende;
        private Zeit aktuelleZeit;
        private List<Zeit> zeiten;

        public TeleZeit()
        {
            InitializeComponent();
            Icon = Properties.Resources.time;
            notifyIcon.Icon = Properties.Resources.time;
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipTitle = "TeleZeit läuft hier weiter";
            notifyIcon.BalloonTipText = "Klicke doppelt auf das Symbol um TeleZeit wieder sichtbar zu machen.";
            Location = new Point(Properties.Settings.Default.lastx, Properties.Settings.Default.lasty);
            Height = Properties.Settings.Default.lasth;
            Width = Properties.Settings.Default.lastw;
            checkBox8H.Checked = Properties.Settings.Default.warnung;
            if (!File.Exists(db))
            {
                File.WriteAllBytes(db, Properties.Resources.telezeit);
            }
            sql = sql.SQLiteConnect(db);
            listViewZeiten.Columns[0].Width = 120;
            listViewZeiten.Columns[1].Width = 120;
            listViewZeiten.Columns[2].Width = listViewZeiten.Width - listViewZeiten.Columns[0].Width - listViewZeiten.Columns[1].Width - 35;
            ReadOldZeiten();

            StatusUpdate();
        }

        private void ReadOldZeiten()
        {
            listViewZeiten.Items.Clear();
            zeiten = new List<Zeit>();
            //alte zeiten aus db lesen
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM zeiten", sql);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                if (reader[reader.GetOrdinal("ende")].GetType() != typeof(DBNull))
                {
                    Guid xid = Guid.Parse(reader.GetString(reader.GetOrdinal("id")));
                    DateTime xstart = DateTime.Parse(reader.GetString(reader.GetOrdinal("start")));
                    DateTime xende = DateTime.Parse(reader.GetString(reader.GetOrdinal("ende")));
                    string xtat = "";
                    if (reader[reader.GetOrdinal("tatigkeit")].GetType() != typeof(DBNull))
                    {
                        xtat = reader.GetString(reader.GetOrdinal("tatigkeit"));
                    }
                    Zeit xzeit = new Zeit(xid, xstart, xende, xtat);
                    zeiten.Add(xzeit);
                }
                else
                {
                    //aktuelle zeit festlegen und zeiterfassung starten
                    Guid xid = Guid.Parse(reader.GetString(reader.GetOrdinal("id")));
                    DateTime xstart = DateTime.Parse(reader.GetString(reader.GetOrdinal("start")));
                    string xtat = "";
                    if (reader[reader.GetOrdinal("tatigkeit")].GetType() != typeof(DBNull))
                    {
                        xtat = reader.GetString(reader.GetOrdinal("tatigkeit"));
                    }
                    start = xstart;
                    aktuelleZeit = new Zeit(xid, xstart, xtat);
                    buttonStart.Enabled = false;
                    endeToolStripMenuItem.Enabled = false;
                    buttonEnde.Enabled = true;
                    endeToolStripMenuItem.Enabled = true;
                    timerRefresh.Start();
                    StatusUpdate();
                    zeiten.Add(aktuelleZeit);
                }
            }
            zeiten = zeiten.OrderByDescending(o => o.Start).ToList();
            foreach(Zeit z in zeiten)
            {
                ListViewItem li = new ListViewItem(new[] { z.StartString, z.EndeString, z.TatigkeitString })
                {
                    Tag = z
                };
                if (z.Ende==DateTime.MinValue)
                {
                    li.BackColor = Color.SteelBlue;
                }
                else if (z.Tatigkeit == "")
                {
                    li.BackColor = Color.LightCoral;
                }
                else
                {
                    li.BackColor = Color.MediumSeaGreen;
                }
                listViewZeiten.Items.Add(li);
            }
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            contextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void TeleZeit_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon.ContextMenuStrip = contextMenuStrip;
                ShowInTaskbar = false;
                WindowState = FormWindowState.Minimized;
                notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon.BalloonTipTitle = "TeleZeit läuft hier weiter";
                notifyIcon.BalloonTipText = "Klicke doppelt auf das Symbol um TeleZeit wieder sichtbar zu machen.";
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1500);
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            start = DateTime.Now.RoundDown(TimeSpan.FromMinutes(5));
            aktuelleZeit = new Zeit(start);
            buttonStart.Enabled = false;
            startToolStripMenuItem.Enabled = false;
            buttonEnde.Enabled = true;
            endeToolStripMenuItem.Enabled = true;
            StatusUpdate();
            sql.SQLiteExecute("INSERT INTO zeiten (id, start) VALUES ('" + aktuelleZeit.ID + "', '" + start.ToString() + "')");
            timerRefresh.Start();
            ReadOldZeiten();
        }

        private void StatusUpdate()
        {
            TimeSpan heute = new TimeSpan();
            TimeSpan heuteFiktiv = new TimeSpan();
            foreach(Zeit z in zeiten)
            {
                if(z.Start.Date == DateTime.Today && z.Ende != DateTime.MinValue)
                {
                    TimeSpan x = z.Ende.Subtract(z.Start);
                    heute = heute.Add(x);
                    heuteFiktiv = heuteFiktiv.Add(x);
                }
            }

            TimeSpan derzeit = new TimeSpan();
            TimeSpan derzeitFiktiv = new TimeSpan();
            if (start != DateTime.MinValue)
            {
                derzeit = DateTime.Now.Subtract(start);
                derzeitFiktiv = DateTime.Now.RoundUp(TimeSpan.FromMinutes(5)).Subtract(start);
                heute = heute.Add(derzeit);
                heuteFiktiv = heuteFiktiv.Add(derzeitFiktiv);
            }
            
            string heuteText = heute.Hours + "h " + heute.Minutes + "m";
            string heuteFiktivText = heuteFiktiv.Hours + "h " + heuteFiktiv.Minutes + "m";
            string derzeitText = derzeit.Hours + "h " + derzeit.Minutes + "m";
            string derzeitFiktivText = derzeitFiktiv.Hours + "h " + derzeitFiktiv.Minutes + "m";
            if (start != DateTime.MinValue)
            {
                toolStripStatusLabel.Text = "Zeiterfassung läuft seit " + start.ToShortDateString() + ", " + start.ToShortTimeString() + " Uhr. | Arbeitszeit heute/derzeit: " + heuteText + "/" + derzeitText;
            }
            else
            {
                toolStripStatusLabel.Text = "Zeiterfassung ist beendet. | Arbeitszeit heute: " + heuteText;
            }

            toolTip.SetToolTip(buttonStart, "Die Startzeit wäre " + DateTime.Now.RoundDown(TimeSpan.FromMinutes(5)).ToShortTimeString() + " | Arbeitszeit heute: " + heuteFiktivText);
            toolTip.SetToolTip(buttonEnde, "Die Endzeit wäre " + DateTime.Now.RoundUp(TimeSpan.FromMinutes(5)).ToShortTimeString() + " | Arbeitszeit heute/derzeit: " + heuteFiktivText + "/" + derzeitFiktivText);

            if (checkBox8H.Checked && timerRefresh.Enabled)
            {
                if (heute.Hours == 7 && heute.Minutes == 45)
                {
                    notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon.BalloonTipTitle = "8 Arbeitsstunden bald erreicht";
                    notifyIcon.BalloonTipText = "Sie erreichen in 15 Minuten ihre heutigen 8 Arbeitsstunden!";
                    notifyIcon.Visible = true;
                    notifyIcon.ShowBalloonTip(3500);
                    notifyIcon.Visible = false;
                }
                if (heute.Hours == 8 && heute.Minutes == 0)
                {
                    notifyIcon.BalloonTipIcon = ToolTipIcon.Warning;
                    notifyIcon.BalloonTipTitle = "8 Arbeitsstunden erreicht";
                    notifyIcon.BalloonTipText = "Sie haben heute bereits 8 Arbeitsstunden erreicht!";
                    notifyIcon.Visible = true;
                    notifyIcon.ShowBalloonTip(3500);
                    notifyIcon.Visible = false;
                }
            }
        }

        private void Ende_Click(object sender, EventArgs e)
        {
            ende = DateTime.Now.RoundUp(TimeSpan.FromMinutes(5));
            buttonEnde.Enabled = false;
            endeToolStripMenuItem.Enabled = false;
            buttonStart.Enabled = true;
            startToolStripMenuItem.Enabled = true;
            timerRefresh.Stop();
            toolStripStatusLabel.Text = "Zeiterfassung ist beendet.";
            aktuelleZeit.AddEnde(ende);

            sql.SQLiteExecute("UPDATE zeiten SET ende = '" + ende.ToString() + "' WHERE id = '" + aktuelleZeit.ID + "'");

            DialogResult res = MessageBox.Show("Folgende Zeit wurde erfasst:" + Environment.NewLine + "Start: " + start.ToShortDateString() + ", " + start.ToShortTimeString() + " Uhr" + Environment.NewLine + "Ende: " + ende.ToShortDateString() + ", " + ende.ToShortTimeString() + " Uhr" + Environment.NewLine + Environment.NewLine + "Wollen sie gleich Tätigkeiten dazu erfassen?", "TeleZeit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            switch (res)
            {
                case DialogResult.Yes:
                    Tatigkeit t = new Tatigkeit(aktuelleZeit);
                    t.ShowDialog(this);
                    aktuelleZeit.AddTatigkeit(t.Tatigkeittext);
                    sql.SQLiteExecute("UPDATE zeiten SET tatigkeit='" + aktuelleZeit.Tatigkeit + "' WHERE id = '" + aktuelleZeit.ID + "'");
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
            ReadOldZeiten();
        }

        private void Tätigkeit_Click(object sender, EventArgs e)
        {
            Zeit z = listViewZeiten.SelectedItems[0].Tag as Zeit;
            Tatigkeit t = new Tatigkeit(z);
            t.ShowDialog(this);
            z.AddTatigkeit(t.Tatigkeittext);
            sql.SQLiteExecute("UPDATE zeiten SET tatigkeit='" + z.Tatigkeit + "' WHERE id = '" + z.ID + "'");
            ReadOldZeiten();
        }

        private void Auswertung_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void TimerRefresh_Tick(object sender, EventArgs e)
        {
            StatusUpdate();
        }

        private void ListViewZeiten_Resize(object sender, EventArgs e)
        {
            listViewZeiten.Columns[2].Width = listViewZeiten.Width - listViewZeiten.Columns[0].Width - listViewZeiten.Columns[1].Width-35;
        }

        private void ListViewZeiten_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listViewZeiten.SelectedItems.Count!=0)
            {
                buttonTatigkeit.Enabled = true;
            }
            else
            {
                buttonTatigkeit.Enabled = false;
            }
        }

        private void ListViewZeiten_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listViewZeiten.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStripView.Show(Cursor.Position);
                }
            }
        }

        private void LöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zeit z = listViewZeiten.SelectedItems[0].Tag as Zeit;
            DialogResult res = MessageBox.Show("Wollen sie die erfasste Zeit wirklich löschen?", "TeleZeit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (res)
            {
                case DialogResult.Yes:
                    sql.SQLiteExecute("DELETE FROM zeiten WHERE id = '" + z.ID + "'");
                    ReadOldZeiten();
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }

        private void TeleZeit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!buttonStart.Enabled)
            {
                DialogResult res = MessageBox.Show("Eine Zeiterfassung läuft noch. Wollen sie die Zeiterfassung auch beenden?", "TeleZeit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (res)
                {
                    case DialogResult.Yes:
                        Ende_Click(new object(), new EventArgs());
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        break;
                }
            }
            Properties.Settings.Default.lastx = Location.X;
            Properties.Settings.Default.lasty = Location.Y;
            Properties.Settings.Default.lasth = Height;
            Properties.Settings.Default.lastw = Width;
            Properties.Settings.Default.warnung = checkBox8H.Checked;
            Properties.Settings.Default.Save();
            sql.SQLiteDisconnect(true);
        }
    }
}
