using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public List<Song> SongsByArtist { get; set; } = new List<Song>();
    }
}
