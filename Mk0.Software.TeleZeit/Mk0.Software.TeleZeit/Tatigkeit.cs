using System.Windows.Forms;

namespace Mk0.Software.TeleZeit
{
    public partial class Tatigkeit : Form
    {
        public string Tatigkeittext;

        public Tatigkeit(Zeit aktuelleZeit)
        {
            InitializeComponent();
            Icon = Properties.Resources.time;
            label1.Text = "Start: " + aktuelleZeit.StartString;
            if (aktuelleZeit.EndeString != "") { label1.Text += " - Ende: " + aktuelleZeit.EndeString; }
            textBoxTatigkeit.Text = aktuelleZeit.Tatigkeit;
        }

        private void Tatigkeit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tatigkeittext = textBoxTatigkeit.Text.Trim();
        }
    }
}
