using RedBadgeProject_Data;
using RedBadgeProject_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeProject_Services
{
    public class RatingService
    {
        private readonly Guid _userId;

        public RatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRating(RatingCreate model)
        {
            var entity =
                new Rating()
                {
                    EnjoymentScore = model.EnjoymentScore,
                    SongLengthScore = model.SongLengthScore,
                    ArtistStyleScore = model.ArtistStyleScore,
                    Description = model.Description,
                    SongId = model.SongId,
                    UserId = _userId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);

                var songEntity = ctx.Songs.Find(model.SongId);
                songEntity.RatingsForSong.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateRating(RatingUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(e => e.RatingId == model.RatingId);

                entity.EnjoymentScore = model.EnjoymentScore;
                entity.SongLengthScore = model.SongLengthScore;
                entity.ArtistStyleScore = model.ArtistStyleScore;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRating(int ratingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(e => e.RatingId == ratingId);

                ctx.Ratings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
