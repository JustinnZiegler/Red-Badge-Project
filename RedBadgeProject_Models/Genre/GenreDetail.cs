using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProject_Models
{
    public class GenreDetail
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public List<string> SongTitlesInGenre { get; set; } = new List<string>();
    }
}