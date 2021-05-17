using RedBadgeProject_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProject_Models
{
    public class AlbumDetail
    {
        public int AlbumId { get; set; }

        public string AlbumName { get; set; }

        public DateTime AlbumReleaseDate { get; set; }

        public List<Song> SongsByArtist { get; set; } = new List<Song>();
    }
}