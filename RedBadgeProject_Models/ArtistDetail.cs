using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProject_Models
{
    public class ArtistDetail
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string Birthdate { get; set; }
        public List<string> NamessOfSongsbyArtist { get; set; } = new List<string>();
    }
}