using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProject_Data
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        public string ArtistName { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        //[ForeignKey(nameof(Song))]
        //public int SongId { get; set; }

        //public virtual Song Song { get; set; }

        public List<Song> SongsByArtist { get; set; } = new List<Song>();

        public List<Album> Albums { get; set; } = new List<Album>();
    }
}
