using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProject_Models
{
    public class RatingList
    {
        public int RatingId { get; set; }

        public double EnjoymentScore { get; set; }

        public double SongLengthScore { get; set; }

        public double ArtistStyleScore { get; set; }

        public double AverageRating
        {
            get
            {
                var totalScore = EnjoymentScore + SongLengthScore + ArtistStyleScore;
                return totalScore / 3;
            }
        }
    }
}