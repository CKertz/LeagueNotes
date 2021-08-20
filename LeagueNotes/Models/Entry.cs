using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueNotes.Models
{
    public class Entry
    {
        public string entry_id { get; set; }
        public string vod_link { get; set; }
        public string note_link { get; set; }
        public string match_history_link { get; set; }
    }
}
