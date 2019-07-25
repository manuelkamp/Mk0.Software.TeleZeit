using System;

namespace Mk0.Software.TeleZeit
{
    public class Zeit
    {
        private DateTime start, ende;
        private string tatigkeit;

        public Guid ID { get; }
        public DateTime Start { get { return start; } }
        public string StartString { get { return start.ToShortDateString() + ", " + start.ToShortTimeString() + " Uhr"; } }
        public DateTime Ende { get { return ende; } }
        public string EndeString { get { if(ende!=DateTime.MinValue) { return ende.ToShortDateString() + "," + ende.ToShortTimeString() + " Uhr"; } else { return ""; } } }
        public string Tatigkeit { get { return tatigkeit; } }
        public string TatigkeitString { get { if (tatigkeit != "") { return tatigkeit; } else { return "<Erfassung fehlt!>"; } } }

        public Zeit(DateTime start)
        {
            ID = Guid.NewGuid();
            this.start = start;
        }

        public Zeit(Guid id, DateTime start, string tatigkeit)
        {
            ID = id;
            this.start = start;
            this.tatigkeit = tatigkeit;
        }

        public Zeit(Guid id, DateTime start, DateTime ende, string tatigkeit)
        {
            ID = id;
            this.start = start;
            this.ende = ende;
            this.tatigkeit = tatigkeit;
        }

        public void AddEnde(DateTime ende)
        {
            this.ende = ende;
        }

        public void AddTatigkeit(string tatigkeit)
        {
            this.tatigkeit = tatigkeit;
            this.tatigkeit = this.tatigkeit.Replace("'", "\"");
        }
    }
}
