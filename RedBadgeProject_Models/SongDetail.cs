using RedBadgeProject_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProject_Models
{
    public class SongDetail
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public string ArtistName { get; set; }

        public string GenreName { get; set; }

        public string AlbumName { get; set; }

        public string Date { get; set; }

        public List<RatingForListInSongDetail> RatingsForSong { get; set; } = new List<RatingForListInSongDetail>();

        public double AverageRating { get; set; }

        public bool IsRecommended { get; set; }
    }
}